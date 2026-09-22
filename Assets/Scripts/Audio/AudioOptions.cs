using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioOptions : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider sliderMusic;
    public Slider sliderSounds;
    void Start()
    {
        sliderMusic.onValueChanged.AddListener(MusicVolume);
        sliderSounds.onValueChanged.AddListener(SoundsVolume);
    }
    
    public void MusicVolume(float value)
    {
        mixer.SetFloat("MusicVol", value);
    }

    public void SoundsVolume(float value)
    {
        mixer.SetFloat("SoundsVol", value);
    }
}
