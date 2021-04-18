// written by nick bautista

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSliders : MonoBehaviour
{
    public MusicPlayerScript musicPlayer;
    public float volume;
    public Slider mainSlider;
    // Start is called before the first frame update
    void Awake()
    {
        if(PlayerPrefs.HasKey("MusicVolume"))
        {
            volume = PlayerPrefs.GetFloat("MusicVolume");
            mainSlider.value = volume;
        }
        else
        {
            volume = .5f;
            mainSlider.value = volume;
            PlayerPrefs.SetFloat("MusicVolume",volume);
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        updateVolume();
    }*/

    void updateVolume()
    {
        volume = mainSlider.value;
        musicPlayer.updateMusic(volume);
    }
}
