using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SirenController : MonoBehaviour
{
    public AudioSource _audio;
    public Light _light;

    private Coroutine volumeUpInJob;
    private Coroutine IntensityBlinkInJob;

    private float currentVolume;
    private float currentIntensity;
    private float maxVolume = 100f;
    private float maxIntensity = 80f;
    private float blinkTimeSec = 5f;
    private float volumeChengeTimeSec = 5f;

    public void SirenOn()
    {
        _audio.Play();
        volumeUpInJob = StartCoroutine(VolumeUp());
        IntensityBlinkInJob = StartCoroutine(intensityWorking());

    }

    public void SirenOff()
    {

        StartCoroutine(VolumeDown());
        _light.intensity = 0;
    }

    private IEnumerator VolumeUp()
    {
        for (int i = 1; i <= 100; i++)
        {
            _audio.volume = (float)Math.Round(i/100f, 2);
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator VolumeDown()
    {
        StopCoroutine(volumeUpInJob);

        for (int i = 100; i > 0; i--)
        {
            _audio.volume = i / 100;
            yield return new WaitForSeconds(1);
        }

        _audio.Stop();
    }

    private IEnumerator intensityWorking()
    {
        while (true)
        {
            for (int i = 0; i <= maxIntensity; i++)
            {
                _light.intensity = i;
                yield return new WaitForSeconds(0.01f);
            }

            for (int i = Mathf.RoundToInt(maxIntensity); i > 0 ; i--)
            {
                _light.intensity = i;
                yield return new WaitForSeconds(0.01f);
            }
        }
        for (int i = 1; i <= 60; i++)
        {
            _light.intensity = i;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
