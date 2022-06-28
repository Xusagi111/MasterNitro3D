using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
    public AudioMixerGroup Mixer;
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
