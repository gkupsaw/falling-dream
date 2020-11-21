using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace FallingDream.Player
{
    public class SimplePlayerMovement : MonoBehaviour
    {
        [Header("Standard Settings")]
        public bool IsMoving;
        public float Speed = 0.05f;
        public float MaxDisplacement = 10f;
        public float LeanFactor = .1f;
        public float MaxLeanDeg = 45;

        void Start()
        {
            PositionCalculate(0, 0);
        }

        void Update()
        {
            float SpeedNormed = Speed * Time.deltaTime;

            float deltaX = 0;
            float deltaZ = 0;
            float deltaLeanX = 0;
            float deltaLeanZ = 0;

            float posX = gameObject.transform.position.x;
            float posZ = gameObject.transform.position.z;
            float rotateX = gameObject.transform.rotation.eulerAngles.x;
            float rotateZ = gameObject.transform.rotation.eulerAngles.z;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (posX < MaxDisplacement)
                {
                    IsMoving = true;
                    deltaX = SpeedNormed;
                }

                if (rotateZ < MaxLeanDeg)
                {
                    deltaLeanZ = LeanFactor;
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (posX > -MaxDisplacement)
                {
                    IsMoving = true;
                    deltaX = -SpeedNormed;
                }

                if (rotateZ > 360 - MaxLeanDeg)
                {
                    deltaLeanZ = -LeanFactor;
                }
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (posZ < MaxDisplacement)
                {
                    IsMoving = true;
                    deltaZ = SpeedNormed;
                }

                if (rotateX < MaxLeanDeg)
                {
                    deltaLeanX = LeanFactor;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (posZ > -MaxDisplacement)
                {
                    IsMoving = true;
                    deltaZ = -SpeedNormed;
                }

                if (rotateX > 360 - MaxLeanDeg)
                {
                    deltaLeanX = -LeanFactor;
                }
            }


            if (deltaX != 0 || deltaZ != 0)
            {
                gameObject.transform.position = PositionCalculate(deltaX, deltaZ);
            } else
            {
                IsMoving = false;
            }

            // if (rotateX != 0f)
            // {
            //     // we need weird conditions bc 0 < rotateX < 360
            //     if (rotateX > 45f)
            //     {
            //         // deltaLeanX = Mathf.Min(360f, rotateX + (LeanFactor));
            //         deltaLeanX += LeanFactor;
            //     } else
            //     {
            //         // deltaLeanX = Mathf.Max(0f, rotateX - (LeanFactor));
            //         deltaLeanX += -LeanFactor;
            //     }
            // }

            // if (rotateZ != 0f)
            // {
            //     // we need weird conditions bc 0 < rotateX < 360
            //     if (rotateZ > 45f)
            //     {
            //         if (deltaLeanZ + LeanFactor + rotateZ > 360)
            //         {
            //             deltaZ = -rotateZ;
            //         } else
            //         {
            //             deltaLeanZ += LeanFactor;
            //         }
            //     } else
            //     {
            //         if (deltaLeanZ - LeanFactor + rotateZ < 0)
            //         {
            //             deltaZ = rotateZ;
            //         } else
            //         {
            //             deltaLeanZ -= LeanFactor;
            //         }
            //     }
            // }

            deltaLeanX = GetDeltaLean(rotateX, deltaLeanX);
            deltaLeanZ = GetDeltaLean(rotateZ, deltaLeanZ);

            Debug.Log(rotateX);
            Debug.Log(rotateZ);

            if (deltaLeanX != 0 || deltaLeanZ != 0)
            {
                LeanPlayer(deltaLeanX, 0, deltaLeanZ);
            }
        }

        private Vector3 PositionCalculate(float deltaX, float deltaZ)
        {
            return gameObject.transform.position + new Vector3(deltaX, 0, deltaZ);
        }

        private void LeanPlayer(float x, float y, float z)
        {
            // float adjustedX = (x > 0f && x < MaxLeanDeg) || (x > 360f - MaxLeanDeg && x < 360f)
            gameObject.transform.Rotate(x, y, z, Space.Self);
        }

        // private float GetDeltaLean()
        // {
        //     float rotateX = gameObject.transform.rotation.eulerAngles.x;
        //     float rotateZ = gameObject.transform.rotation.eulerAngles.z;
        //     float deltaLeanZ = 0;
        //     float deltaLeanX = 0;

        //     if (Input.GetKey(KeyCode.RightArrow) && (rotateZ < MaxLeanDeg))
        //     {
        //         deltaLeanZ = LeanFactor;
        //     }
        //     else if (Input.GetKey(KeyCode.LeftArrow) && (rotateZ > 360 - MaxLeanDeg))
        //     {
        //         deltaLeanZ = -LeanFactor;
        //     }

        //     if (Input.GetKey(KeyCode.UpArrow) && (rotateX < MaxLeanDeg))
        //     {
        //         deltaLeanX = LeanFactor;
        //     }
        //     else if (Input.GetKey(KeyCode.DownArrow) && (rotateX > 360 - MaxLeanDeg))
        //     {
        //         deltaLeanX = -LeanFactor;
        //     }


        //     return GetAutoLean(deltaLeanX);
        // }

        private float GetAutoLean(float currRot, float currDeltaLean)
        {
            // do stuff iff player not moved and rot != 0
            float deltaLean = currDeltaLean;

            if (currDeltaLean == 0 && currRot != 0)
            {
                // we need weird conditions bc 0deg < rotateX < 360deg
                if (currRot > 45f)
                {
                    // we add lean in the positive direction
                    if (currDeltaLean + LeanFactor + currRot > 360f)
                    {
                        // if it overshoots, then make the rotation 0
                        deltaLean = -currRot;
                    } else
                    {
                        deltaLean += LeanFactor;
                    }
                } else
                {
                    // we add lean in the negative direction
                    if (currDeltaLean - LeanFactor + currRot < 0f)
                    {
                        deltaLean = -currRot;
                    } else
                    {
                        deltaLean -= LeanFactor;
                    }
                }
            }

            return deltaLean;
        }
    }
}