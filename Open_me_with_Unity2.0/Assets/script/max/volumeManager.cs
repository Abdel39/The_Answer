using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeManager : MonoBehaviour
{
    public AudioSource audioSource;
    private static float currentVolume=10.0f;
    public Slider slider;
    public bool IamSettingSlider=false;
    // Start is called before the first frame update
    void Start()
    {
        if (IamSettingSlider && slider !=null)
        {
            slider.value = audioSource.volume;
        }

        audioSource.volume = currentVolume;
    }

    public void setVolumeWithSlider()
    {
        currentVolume = slider.value;
        audioSource.volume = currentVolume;
    }

    
}
