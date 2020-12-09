using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{	
    /// <summary>
    /// The Update function is responsible to keep the camera on top of the character
    /// </summary>
    void Update ()
    {
        transform.position = new Vector3(PlayerController.Pos.x, PlayerController.Pos.y + 5, PlayerController.Pos.z);
    }
}
