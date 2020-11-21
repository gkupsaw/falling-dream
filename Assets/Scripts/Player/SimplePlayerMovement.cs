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
        public float LeanFactor = 1f;
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

            // Debug.Log(rotateX);
            // Debug.Log(deltaLeanX);
            if (deltaLeanX == 0f && rotateX != 0f)
            {
                // we need weird conditions bc 0 < rotateX < 360
                if (rotateX > 45f)
                {
                    deltaLeanX = Mathf.Min(360f, rotateX + (LeanFactor / 100f));
                } else
                {
                    deltaLeanX = Mathf.Max(0f, rotateX - (LeanFactor / 100f));
                }
            }

            if (deltaLeanZ == 0f && rotateZ != 0f)
            {
                // we need weird conditions bc 0 < rotateX < 360
                if (rotateZ > 45f)
                {
                    deltaLeanZ = Mathf.Min(0f, rotateZ + (LeanFactor / 100f));
                } else
                {
                    deltaLeanZ = Mathf.Min(0f, rotateZ - (LeanFactor / 100f));
                }
            }

            if (deltaLeanX != 0 || deltaLeanZ != 0)
            {
                // LeanPlayer(deltaLeanX, 0, deltaLeanZ);
            }
        }

        private Vector3 PositionCalculate(float deltaX, float deltaZ)
        {
            return gameObject.transform.position + new Vector3(deltaX, 0, deltaZ);
        }

        private void LeanPlayer(float x, float y, float z)
        {
            gameObject.transform.Rotate(x, y, z, Space.Self);
        }
    }
}