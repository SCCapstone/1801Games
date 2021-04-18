using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class SoundPlayerScript : MonoBehaviour
{
    public AudioManager sounds;
    public Slider soundSlider;
    public float soundVolume;
    //public float coinVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        soundSlider.onValueChanged.AddListener(delegate {ValueChangeCheck ();});
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");    
    }

    public void ValueChangeCheck() 
    {
        updateSounds();
    }

    void Awake()
    {
        if(PlayerPrefs.HasKey("SoundVolume"))
        {
            soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
        }
        else
        {
            soundSlider.value = .5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //updateSounds(); 
    }

    public void updateSounds() 
    {
        float volume = soundSlider.value;
        soundVolume = soundSlider.value;
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
        //PlayerPrefs.Save();   
        //sounds.updateVolume();

    }
}
