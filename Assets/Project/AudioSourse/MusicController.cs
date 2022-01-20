using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Events;

public class MusicController : MonoBehaviour
{
    public AudioMixerGroup Mixer;
    private void Awake()
    {

    }

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
        {
            Mixer.audioMixer.SetFloat("MusicVolume", 0);
        }
        else
        {
            Mixer.audioMixer.SetFloat("MusicVolume", -80);
        }
    }
    public void ToggleSounds(bool enabled)
    {
        if (enabled)
        {
            Mixer.audioMixer.SetFloat("SoundsVolume", 0);
        }
        else
        {
            Mixer.audioMixer.SetFloat("SoundsVolume", -80);
        }
    }
    public void MusicLevel(float volume)
    {
        Mixer.audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }
    public void SoundsLevel(float volume)
    {
        Mixer.audioMixer.SetFloat("SoundsVolume", Mathf.Log10(volume) * 20);
    }
}
