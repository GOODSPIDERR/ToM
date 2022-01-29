using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;
    private CinemachineBasicMultiChannelPerlin _perlin;
    private float _duration = 0f;
    private float _currentAmplitude = 0f;
    private float _actualTimer = 0f;

    private void Awake()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _perlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    
    
    private void Update()
    {
        _perlin.m_AmplitudeGain = _currentAmplitude;
        
        if (_currentAmplitude > 0f) //Not the most efficient way to do this. Figure out a more efficient solution later
        {
            _currentAmplitude -= _actualTimer * Time.deltaTime;
        }
        else
        {
            _currentAmplitude = 0f;
        }
    }

    public void Shake(float amplitude, float frequency, float duration)
    {
        _currentAmplitude = amplitude;
        _perlin.m_FrequencyGain = frequency;
        _duration = duration;
        _actualTimer = amplitude / duration;
    }
    
    
}