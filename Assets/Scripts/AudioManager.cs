// Written by Bradley Williamson
// Edited by Tariq Scott 
// AudioManager.cs has the controls for all in-game sounds. 

using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public float volume;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake() //Awake is called right before start
    {

        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) 
        {
           s.volume = PlayerPrefs.GetFloat("SoundVolume");
           s.source = gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;
           s.source.volume = PlayerPrefs.GetFloat("SoundVolume");
           s.source.pitch = s.pitch;
           s.source.loop = s.loop;
        }
    }

    void Start() {
        //Play("Theme");
    }

    void Update()
    {
        updateVolume();
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void updateVolume()
    {
        foreach(Sound s in sounds)
        {
            s.source.volume = PlayerPrefs.GetFloat("SoundVolume");
        }
    }
}
