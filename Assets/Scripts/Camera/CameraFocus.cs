using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    [Header("Focused Object")]
    public GameObject FocusedObject;

    void Start()
    {
        gameObject.transform.LookAt(FocusedObject.transform);
    }

    
    void Update()
    {
        gameObject.transform.LookAt(FocusedObject.transform);
    }
}
