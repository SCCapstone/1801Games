using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayerScript : MonoBehaviour
{
    public AudioSource AudioSource;
    public float musicVolume = 1f;
    //public float coinVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = musicVolume;
    }

    public void updateMusic(float volume) {
        musicVolume = volume;
    }
}
