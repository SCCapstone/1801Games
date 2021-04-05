// Written by Bradley Williamson
// Edited by Tariq Scott 
// AudioManager.cs has the controls for all in-game sounds. 

using UnityEngine.Audio;
using System;
using UnityEngine;

public class MainTheme : MonoBehaviour
{

    public static MainTheme isPlaying;
    public AudioSource mainTheme;
    public float musicVolume;
    // Start is called before the first frame update
    void Awake() //Awake is called right before start
    {

        if(isPlaying == null)
        {
           DontDestroyOnLoad(transform.gameObject); 
           isPlaying = this;
        }
        else if(isPlaying != this)
        {
            Destroy(transform.gameObject);
        }
        if(PlayerPrefs.HasKey("MusicVolume"))
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        else
            musicVolume = 0.5f;

        mainTheme.volume = musicVolume;
    }

    public void PlayTheme()
    {
        if(mainTheme.isPlaying)
            return;
        mainTheme.Play();
    }
}

