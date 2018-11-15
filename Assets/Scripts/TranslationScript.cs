using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationScript : MonoBehaviour
{
    public bool rightMovement = true;
    public float movementSpeed;
    public float movementRate;
    private float moveTimer;

    private void Update()
    {
        moveTimer += Time.deltaTime;

        if (rightMovement)
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }

        if (moveTimer >= movementRate)
        {
            if (rightMovement)
            {
                rightMovement = false;
            }
            else if (!rightMovement)
            {
                rightMovement = true;
            }
            moveTimer = 0;
        }
    }
}
