using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeManager : MonoBehaviour
{
    public AudioSource audioSource;
    private static float currentVolume;
    public Slider slider;
    public bool IamSettingSlider=false;
    // Start is called before the first frame update
    void Start()
    {
        if (IamSettingSlider && slider !=null)
        {
            if (currentVolume == null)// c est la premiere fois
            {
                currentVolume = audioSource.volume;
            }
            slider.value = currentVolume;
            
        }

       
        audioSource.volume = currentVolume;
    }

    public void setVolumeWithSlider()
    {
        currentVolume = slider.value;
        audioSource.volume = currentVolume;
    }

    
}
