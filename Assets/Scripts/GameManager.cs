using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static GameScreens currentScreen;

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

    private void Start()
    {
        currentScreen = GameScreens.MainMenu;
    }

    private void Update()
    {
        switch (currentScreen)
        {
            case GameScreens.MainMenu:
                AudioManager.Instance.PlayMusic(0);
                currentScreen = GameScreens.o;
                break;
            case GameScreens.Level_1:
                AudioManager.Instance.PlayMusic(1);
                currentScreen = GameScreens.o;
                break;
            case GameScreens.Level_2:
                AudioManager.Instance.PlayMusic(2);
                currentScreen = GameScreens.o;
                break;
            case GameScreens.Level_3:
                AudioManager.Instance.PlayMusic(3);
                currentScreen = GameScreens.o;
                break;
            case GameScreens.o:
                break;
        }
    }
}

public enum GameScreens { MainMenu, Level_1, Level_2, Level_3, o}