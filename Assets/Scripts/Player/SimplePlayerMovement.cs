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

        void Start()
        {
            PositionCalculate(0, 0);
        }

        void Update()
        {
            float deltaX = 0;
            float deltaZ = 0;

            if (Input.GetKey(KeyCode.RightArrow) && gameObject.transform.position.x < MaxDisplacement)
            {
                IsMoving = true;
                deltaX = Speed;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && gameObject.transform.position.x > -MaxDisplacement)
            {
                IsMoving = true;
                deltaX = -Speed;
            }

            if (Input.GetKey(KeyCode.UpArrow) && gameObject.transform.position.z < MaxDisplacement)
            {
                IsMoving = true;
                deltaZ = Speed;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && gameObject.transform.position.z > -MaxDisplacement)
            {
                IsMoving = true;
                deltaZ = -Speed;
            }


            if (deltaX != 0 || deltaZ != 0)
            {
                gameObject.transform.position = PositionCalculate(deltaX, deltaZ);
            } else {
                IsMoving = false;
            }
        }

        private Vector3 PositionCalculate(float deltaX, float deltaZ)
        {
            return gameObject.transform.position + new Vector3(deltaX, 0, deltaZ);
        }
    }
}