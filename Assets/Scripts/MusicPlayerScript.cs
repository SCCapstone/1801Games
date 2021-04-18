using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicPlayerScript : MonoBehaviour
{
    public AudioSource AudioSource;
    public MainTheme mainTheme;
    public AudioSource bgMusic;
    public Slider bgmVolumeSlider;
    public Slider sfxVolumeSlider;
    public float musicVolume;
    //public float coinVolume = 1f;


    // Start is called before the first frame update
    void Awake()
    {
        bgMusic = mainTheme.mainTheme;
        if(PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            bgMusic.volume = musicVolume;
        }
        else
        {
            musicVolume = 0.5f;
            PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        }   
    }

    public void updateMusic(float volume) {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        musicVolume = volume;
        mainTheme.UpdateMusic(musicVolume);
        bgMusic.volume = musicVolume;
    }
}
