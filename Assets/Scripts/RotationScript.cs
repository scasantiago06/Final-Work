using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public bool isRotating = true;
    public float rotationSpeed;

    // Update is called once per frame
    void Update ()
    {
        if (isRotating)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
