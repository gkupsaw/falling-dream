using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FallingDream.Player;

namespace FallingDream.Camera
{
    public class SimpleCameraMovement : MonoBehaviour
    {
        public GameObject FollowingObject;
        public float CameraOffset = 30f;

        private Vector3 _yVec;

        void Start()
        {
            _yVec = new Vector3(0, CameraOffset, 0);
        }

        void Update()
        {
            gameObject.transform.position = FollowingObject.transform.position + _yVec;
        }
    }
}