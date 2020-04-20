using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CameraShake : MonoBehaviour {

    public float ShakeDuration = 0.3f;          // Temps de shake
    public float ShakeAmplitude = 1.2f;         
    public float ShakeFrequency = 2.0f;         
    
    public float ShakeElapsedTime = 0f;
    public PlayerMotor player;
    
    
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

   
    void Start()
    {
        // Recupère le profil
        if (VirtualCamera != null)
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    
    void Update()
    {
        
        
        if (player.candash)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                ShakeElapsedTime = ShakeDuration;
            }
        }
        
        
        
        // TODO: Replace with your trigger
        if (Input.GetKey(KeyCode.S))
        {
            ShakeElapsedTime = ShakeDuration;
        }

        // If the Cinemachine componet is not set, avoid update
        if (VirtualCamera != null && virtualCameraNoise != null)
        {
            // If Camera Shake effect is still playing
            if (ShakeElapsedTime > 0)
            {
                // Set Cinemachine Camera Noise parameters
                virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
                virtualCameraNoise.m_FrequencyGain = ShakeFrequency;

                // Update Shake Timer
                ShakeElapsedTime -= Time.deltaTime;
            }
            else
            {
                // If Camera Shake effect is over, reset variables
                virtualCameraNoise.m_AmplitudeGain = 0f;
                ShakeElapsedTime = 0f;
            }
        }
    }
}