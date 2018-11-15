using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameScreens { MainMenu, Level_1, Level_2, Level_3, Level_4, Level_5, Level_6, Level_7, Level_8, Level_9, Level_10}

    public GameScreens currentScreen;

    private void Start()
    {
        currentScreen = GameScreens.MainMenu;
    }

    private void Update()
    {
        switch (currentScreen)
        {
            case GameScreens.Level_1:

                break;
            case GameScreens.Level_2:

                break;
            case GameScreens.Level_3:

                break;
            case GameScreens.Level_4:

                break;
        }
    }
}