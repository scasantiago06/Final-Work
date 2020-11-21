using UnityEngine;

/// <summary>
/// This class is responsible to save the music and FX
/// volume, and send the saved value.
/// </summary>
public class Settings 
{
    public static float MusicVolume
    {
        get
        {
            return PlayerPrefs.GetFloat("MusicVolume");
        }
        set
        {
            if(value >= 0 && value <= 1)
                PlayerPrefs.SetFloat("MusicVolume", value);
        }
    }

    public static float FXVolume
    {
        get
        {
            return PlayerPrefs.GetFloat("FXVolume");
        }
        set
        {
            if (value >= 0 && value <= 1)
                PlayerPrefs.SetFloat("FXVolume", value);
        }
    }
}