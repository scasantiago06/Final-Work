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

        if (gameObject.name == "Star1")
            UIManager.Instance.ChangeScene("Level 2");
        if (gameObject.name == "Star2")
            UIManager.Instance.ChangeScene("Level 3");
        if (gameObject.name == "Star3")
            UIManager.Instance.ChangeScene("Credits");
    }
}
