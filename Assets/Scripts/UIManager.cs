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

    /// <summary>
    /// A property for return the music slider
    /// </summary>   
    public Slider MusicSlider
    {
        get
        {
            return musicSlider;
        }
    }

    /// <summary>
    /// A property for return the effects slider
    /// </summary>   
    public Slider FXSLider
    {
        get
        {
            return fXSlider;
        }
    }

    /// <summary>
    /// Here are initialize all the variables that need find the object
    /// </summary>   
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

    /// <summary>
    /// this function is used to modify the text that shows the total number of stars collected 
    /// </summary> 
    /// <param name="amountStars"></param>
    public void ModifyCollectablesText(int amountStars)
    {
        starText.text = amountStars.ToString();
    }

    /// <summary>
    /// this function is used to modify the text that shows the total deaths 
    /// </summary> 
    /// <param name="amountStars"></param>
    public void ModifyDeathText(int amountDeaths)
    {
        deathText.text = amountDeaths.ToString();
    }

    /// <summary>
    /// this function is used to active and desactive the object passed as parameter and play 
    /// the sound of the button
    /// </summary> 
    /// <param name="UIObject"></param>
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

    /// <summary>
    /// this function is used to load the scene passed as a parameter 
    /// the sound of the button
    /// </summary> 
    /// <param name="sceneToLoad"></param>
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

    /// <summary>
    /// This function is responsible to quit the game when is called
    /// </summary> 
    public void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// This function modify the slider and call the method for change the volume
    /// </summary> 
    public void MusicSliderModification()
    {
        Settings.MusicVolume = musicSlider.value;
        AudioManager.Instance.ChangeVolume();
    }

    /// <summary>
    /// This function modify the slider and call the method for change the volume
    /// </summary> 
    public void FXSliderModification()
    {
        Settings.FXVolume = fXSlider.value;
        AudioManager.Instance.ChangeVolume();
        AudioManager.Instance.PlayButtonSound();
    }

    /// <summary>
    /// This function is not used
    /// </summary> 
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
