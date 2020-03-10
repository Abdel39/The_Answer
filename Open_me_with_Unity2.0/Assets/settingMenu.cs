using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSourceMenu;
    private static float _volume;
    public Slider _slider;

    public void Start()
    {
        _slider.value = audioSourceMenu.volume;
    }

    public void setVolume(float volume)
    {
        Debug.Log(volume);
        audioSourceMenu.volume = volume;
        _volume = volume;

    }

    public static float getVolume()
    {
        return _volume;
    }
}
