using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour, IReactableObject
{
    public void React()
    {
        gameObject.SetActive(false);

        if (gameObject.CompareTag("Star"))
        {
            PlayerInfo.TotalStars += 1;
        }
        else if (gameObject.CompareTag("Cubie"))
        {
            PlayerInfo.TotalCubies += 1;
        }
    }
}
