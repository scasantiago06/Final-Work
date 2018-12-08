using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static GameScreens currentScreen;
    
    /// <summary>
    /// This property return a variable that is responsible to save the current screen
    /// </summary>
    public static GameScreens GameScreen
    {
        get
        {
            return currentScreen;
        }
        set
        {
            currentScreen = value;
        }
    }

    /// <summary>
    /// In the Start Function i assign the "currentScreen" variable
    /// </summary>
    private void Start()
    {
        currentScreen = GameScreens.MainMenu;
    }

    /// <summary>
    /// In the "Update" Function is controlled the music that it will be reproduced
    /// according to the game scene
    /// </summary>
    private void Update()
    {
        switch (currentScreen)
        {
            case GameScreens.MainMenu:
                AudioManager.Instance.PlayMusic(0);
                currentScreen = GameScreens.Default;
                break;
            case GameScreens.Level_1:
                AudioManager.Instance.PlayMusic(1);
                currentScreen = GameScreens.Default;
                break;
            case GameScreens.Level_2:
                AudioManager.Instance.PlayMusic(2);
                currentScreen = GameScreens.Default;
                break;
            case GameScreens.Level_3:
                AudioManager.Instance.PlayMusic(3);
                currentScreen = GameScreens.Default;
                break;
            case GameScreens.Default:
                break;
        }
    }
}

public enum GameScreens { MainMenu, Level_1, Level_2, Level_3, Credits, Default}
