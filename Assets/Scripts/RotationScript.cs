using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public bool isRotating = true;
    public float rotationSpeed;

    /// <summary>
    /// The update is used for rotate the object that contains this script constantly
    /// </summary>
    void Update ()
    {
        if (isRotating)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
