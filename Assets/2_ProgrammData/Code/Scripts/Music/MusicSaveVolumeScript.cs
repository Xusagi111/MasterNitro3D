using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MusicSaveVolumeScript : MonoBehaviour
{
    [SerializeField] Slider MusicSlider;
    [SerializeField] Slider EffectsSlider;
    SaveMusicStats saveMusicStats = new SaveMusicStats();
    public float SaveMusic { get; set; }
    public float SaveEffect { get; set;  }

    private void Start()
    {
        loaging();
    }
    public void Save()
    {
        saveMusicStats.Music = this.SaveMusic;
        saveMusicStats.Effects = this.SaveEffect;
        ButtonClassSave.SaveToPlayerPrefs<SaveMusicStats>(saveMusicStats, "SaveMusicStats");
    }
    public void loaging()
    {
        saveMusicStats = ButtonClassSave.LoadFromPlayerPrefs<SaveMusicStats>(saveMusicStats, "SaveMusicStats");
        this.SaveMusic = saveMusicStats.Music;
        this.SaveEffect = saveMusicStats.Effects;
        GetMusicSlider(MusicSlider);
        GetEffectSlider(EffectsSlider);
        
    }
    public void SetMusicSlider(Slider MusicSlider)
    {
        this.SaveMusic = MusicSlider.value;
    }
    public void  GetMusicSlider(Slider MusicSlider)
    {
        this.MusicSlider.value = this.SaveMusic;
    }

    public void SetEffectSlider(Slider EffectsSlider)
    {
        SaveEffect = EffectsSlider.value;
    }
    public void GetEffectSlider(Slider EffectsSlider)
    {
        this.EffectsSlider.value = this.SaveEffect;
    }
}
