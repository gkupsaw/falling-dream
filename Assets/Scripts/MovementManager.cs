using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public GameObject Character;

    private Transform _characterPosition;
    private float _charRadian;
    private float _charRadius;

    // Start is called before the first frame update
    void Start()
    {
        _charRadian = 0;
        _charRadius = 10;

        _characterPosition = Character.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)){
            _charRadian += 0.01f * (10 / _charRadius);
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            _charRadian -= 0.01f * (10 / _charRadius);
        }

        PositionCalculate(_charRadian, _charRadius);
    }

    private void PositionCalculate(float radian, float radius)
    {
        float xPos = radius * (float)Math.Cos(radian);
        float zPos = radius * (float)Math.Sin(radian);

        _characterPosition.position = new Vector3(xPos, 0, zPos);
    }
}
