using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("State")]
    public bool IsMoving;

    [Header("Standard Settings")]
    public float StandardSpeed;
    public float StandardRadius;
    public float MinRadius;
    public float MaxRadius;

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
        IsMoving = false;

        if (Input.GetKey(KeyCode.RightArrow)){
            CharRadian += 0.002f * (10 / CharRadius);
            IsMoving = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)){
            CharRadian -= 0.002f * (10 / CharRadius);
            IsMoving = true;
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
