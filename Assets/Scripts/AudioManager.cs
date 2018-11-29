using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]
    //audioSources[0] for Music, audioSource[1] for FX
    AudioSource[] audioSources;
    [SerializeField]
    //audioClip[0] for MainMenu music, audioClip[1] for Level 1 music, audioClip[2] for Level 2 music, audioClip[3] for Level 3 music, audioClip[4] for press button sound
    AudioClip[] audioClips;

    private void Start()
    {
        audioSources = new AudioSource[2];
        audioClips = new AudioClip[5]; 

        for(int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
            audioSources[i].volume = .5f;

            if (i == 0)
            {
                audioSources[i].loop = true;
                audioSources[i].volume = 1;
            }
        }

        audioClips[0] = Resources.Load<AudioClip>("Audios/Space Cadet");
        audioClips[1] = Resources.Load<AudioClip>("Audios/Farm Frolics");
        audioClips[2] = Resources.Load<AudioClip>("Audios/Mission Plausible");
        audioClips[3] = Resources.Load<AudioClip>("Audios/Night at the Beach");
        audioClips[4] = Resources.Load<AudioClip>("Audios/Pressed Button");

        audioSources[1].clip = audioClips[4];

        PlayMusic(0);
    }

    public void PlayMusic(int scene)
    {
        switch (scene)
        {
            case 0:
                audioSources[0].clip = audioClips[0];
                break;
            case 1:
                audioSources[0].clip = audioClips[1];
                break;
            case 2:
                audioSources[0].clip = audioClips[2];
                break;
            case 3:
                audioSources[0].clip = audioClips[3];
                break;
        }
        audioSources[0].Play();
    }

    public void PlayButtonSound()
    {
        audioSources[1].Play();
    }

    //public void ModifyVolume()
    //{
    //    audioSources[0].volume = UIManager.Instance.MusicSlider.value;
    //}
}