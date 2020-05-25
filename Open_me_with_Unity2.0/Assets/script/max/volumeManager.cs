using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine;

public class volumeManager : MonoBehaviour
{
    public AudioSource audioSource;
    private static float currentVolume=-1f;
    public Slider slider;
    public bool IamSettingSlider=false;
    // Start is called before the first frame update
    void Start()
    {
        

        if (IamSettingSlider && slider !=null)
        {
            if (currentVolume == -1f)// c est la premiere fois
            {
                UnityEngine.Debug.Log("here");
                currentVolume = 0.5f;
                
            }
            slider.value = currentVolume;
            
        }

       
        audioSource.volume = currentVolume;
    }

    public void setVolumeWithSlider()
    {
        if (currentVolume >=0f)
        {
            currentVolume = slider.value;
            audioSource.volume = currentVolume;
        }
       
    }

    
}
