using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace FallingDream.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("State")]
        public bool IsMovingCircular;
        public bool IsMovingRadius;
        public bool IsMoving
        {
            get
            {
                return IsMovingCircular || IsMovingRadius;
            }
        }

        [Header("Standard Settings")]
        public float StandardSpeed;
        public float StandardRadius;
        public float MinRadius;
        public float MaxRadius;
        public float CurrentCircularSpeed
        {
            get
            {
                return StandardSpeed * (StandardRadius / CharRadius);
            }
        }
        public float CurrentRadiusSpeed
        {
            get
            {
                return StandardSpeed * 10;
            }
        }

        [Header("Position Properties")]
        public float CharRadian;
        public float CharRadius;

        void Start()
        {
            CharRadian = 0;
            CharRadius = 10;

            PositionCalculate(CharRadian, CharRadius);
        }

        void Update()
        {
            IsMovingCircular = false;
            IsMovingRadius = false;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                CharRadian += CurrentCircularSpeed;
                IsMovingCircular = true;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                CharRadian -= CurrentCircularSpeed;
                IsMovingCircular = true;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                CharRadius -= CurrentRadiusSpeed;
                if (CharRadius < MinRadius)
                {
                    CharRadius = MinRadius;
                }
                IsMovingRadius = true;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                CharRadius += CurrentRadiusSpeed;
                if (CharRadius > MaxRadius)
                {
                    CharRadius = MaxRadius;
                }
                IsMovingRadius = true;
            }

            gameObject.transform.position = PositionCalculate(CharRadian, CharRadius);
        }

        private Vector3 PositionCalculate(float radian, float radius)
        {
            float xPos = radius * (float)Math.Cos(radian);
            float zPos = radius * (float)Math.Sin(radian);

            return new Vector3(xPos, 0, zPos);
        }
    }
}