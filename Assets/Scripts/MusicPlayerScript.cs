using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayerScript : MonoBehaviour
{
    public AudioSource AudioSource;
    public float musicVolume;
    //public float coinVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.Play();
        if(PlayerPrefs.HasKey("MusicVolume"))
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        else
            musicVolume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = musicVolume;
    }

    public void updateMusic(float volume) {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        musicVolume = volume;
        AudioSource.volume = musicVolume;
    }
}
