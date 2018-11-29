using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    Text starText;
    Text deathText;
    [SerializeField]
    Slider musicSlider;
    Slider fXSlider;
    GameObject musicOff;
    GameObject musicOn;
    GameObject effectsOff;
    GameObject effectsOn;
    GameObject optionsPanel;

    public Slider MusicSlider
    {
        get
        {
            return musicSlider;
        }
    }

    public Slider FXLider
    {
        get
        {
            return fXSlider;
        }
    }

    private void Awake()
    {
        if (GameObject.Find("TotalStars") != null)
            starText = GameObject.Find("TotalStars").GetComponent<Text>();
        if (GameObject.Find("TotalDeaths") != null)
            deathText = GameObject.Find("TotalDeaths").GetComponent<Text>();

        if (GameObject.Find("MusicSlider") != null)
            musicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();

        if (GameObject.Find("FXSlider") != null)
            fXSlider = GameObject.Find("FXSlider").GetComponent<Slider>();

        if (GameObject.Find("MusicOff") != null)
        {
            musicOff = GameObject.Find("MusicOff");
            musicOff.SetActive(false);
        }
        if (GameObject.Find("MusicOn") != null)
            musicOn = GameObject.Find("MusicOn");

        if (GameObject.Find("EffectsOff") != null)
        {
            effectsOff = GameObject.Find("EffectsOff");
            effectsOff.SetActive(false);
        }
        if (GameObject.Find("EffectsOn") != null)
            effectsOn = GameObject.Find("EffectsOn");

        if (GameObject.Find("OptionsPanel") != null)
        {
            optionsPanel = GameObject.Find("OptionsPanel");
            optionsPanel.SetActive(false);
        }
    }

    public void ModifyCollectablesText(int amountCubies, int amountStars)
    {
        starText.text = amountStars.ToString();
    }

    public void ModifyDeathText(int amountDeaths)
    {
        deathText.text = amountDeaths.ToString();
    }

    public void ActiveDesactiveUIObjects(GameObject UIObject)
    {
        AudioManager.Instance.PlayButtonSound();
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

        if (sceneToLoad.Contains("Menu"))
            GameManager.GameScreen = GameScreens.MainMenu;
        else if (sceneToLoad.Contains("1"))
            GameManager.GameScreen = GameScreens.Level_1;
        else if(sceneToLoad.Contains("2"))
            GameManager.GameScreen = GameScreens.Level_2;
        else if (sceneToLoad.Contains("3"))
            GameManager.GameScreen = GameScreens.Level_3;

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MusicSliderModification()
    {
        if (musicSlider.value == 0)
        {
            ActiveDesactiveUIObjects(musicOff);
            ActiveDesactiveUIObjects(musicOn);
        }
        else if (musicSlider.value > 0)
        {
            if (!musicOn.gameObject.activeInHierarchy)
            {
                ActiveDesactiveUIObjects(musicOff);
                ActiveDesactiveUIObjects(musicOn);
            }
        }
    }

    public void FXSliderModification()
    {
        if (fXSlider.value == 0)
        {
            ActiveDesactiveUIObjects(effectsOff);
            ActiveDesactiveUIObjects(effectsOn);
        }
        else if (fXSlider.value > 0)
        {
            if (!effectsOn.gameObject.activeInHierarchy)
            {
                ActiveDesactiveUIObjects(effectsOff);
                ActiveDesactiveUIObjects(effectsOn);
            }
        }
    }
}
