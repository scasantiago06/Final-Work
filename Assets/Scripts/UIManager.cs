using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    Text starText;
    Text deathText;
    Slider musicSlider;
    Slider fXSlider;
    GameObject optionsPanel;

    public Slider MusicSlider
    {
        get
        {
            return musicSlider;
        }
    }

    public Slider FXSLider
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

        if (GameObject.Find("OptionsPanel") != null)
        {
            optionsPanel = GameObject.Find("OptionsPanel");
            optionsPanel.SetActive(false);
        }
    }

    private void Start()
    {
        //musicSlider.value = Settings.MusicVolume;
        //fXSlider.value = Settings.FXVolume;
    }

    public void ModifyCollectablesText(int amountStars)
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
        else if (sceneToLoad.Contains("Credits"))
            GameManager.GameScreen = GameScreens.Credits;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MusicSliderModification()
    {
        Settings.MusicVolume = musicSlider.value;
        AudioManager.Instance.ChangeVolume();
    }

    public void FXSliderModification()
    {
        Settings.FXVolume = fXSlider.value;
        AudioManager.Instance.ChangeVolume();
        AudioManager.Instance.PlayButtonSound();
    }

    public void MuteAudio(bool i)
    {
        if (i)
        {
            if (musicSlider.value != 0)
                musicSlider.value = 0;
            else
                musicSlider.value = .5f;
        }
        else
        {
            if (fXSlider.value != 0)
                fXSlider.value = 0;
            else
                fXSlider.value = .5f;
        }
    }
}