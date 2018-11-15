using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{	
	void Update ()
    {
        transform.position = new Vector3(PlayerController.Pos.x, PlayerController.Pos.y + 5, PlayerController.Pos.z);
    }
}
