using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    static Text starText;
    static Text deathText;

    private void Awake()
    {
        starText = GameObject.Find("TotalStars").GetComponent<Text>();
        deathText = GameObject.Find("TotalDeaths").GetComponent<Text>();
    }

    public static void ModifyCollectablesText(int amountCubies, int amountStars)
    {
        starText.text = amountStars.ToString();
    }

    public static void ModifyDeathText(int amountDeaths)
    {
        deathText.text = amountDeaths.ToString();
    }
    
    public void ActiveDesactiveUIObjects(GameObject UIObject)
    {
        if (UIObject.activeInHierarchy)
        {
            UIObject.SetActive(false);
        }
        else
        {
            UIObject.SetActive(true);
        }
    }

    public void ChangeScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
