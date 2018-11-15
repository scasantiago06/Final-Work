using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    static Text cubieText;
    static Text starText;
    static Text deathText;

    private void Awake()
    {
        cubieText = GameObject.Find("TotalCubies").GetComponent<Text>();
        starText = GameObject.Find("TotalStars").GetComponent<Text>();
        deathText = GameObject.Find("TotalDeaths").GetComponent<Text>();
    }

    public static void ModifyCollectablesText(int amountCubies, int amountStars)
    {
        cubieText.text = amountCubies.ToString();
        starText.text = amountStars.ToString();
    }

    public static void ModifyDeathText(int amountDeaths)
    {
        deathText.text = amountDeaths.ToString();
    }

    public void ChangeScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
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
}
