using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MusicSaveVolumeScript : MonoBehaviour
{
    [SerializeField] Slider MusicSlider;
    [SerializeField] Slider EffectsSlider;

    public float SaveMusic { get; set; }
    public float SaveEffect { get; set;  }


    private void Start()
    {
        loaging();
    }
    public void Save()
    {
        GarageController.savePlayerStats.Music = this.SaveMusic;
        GarageController.savePlayerStats.Effects = this.SaveEffect;
        ButtonClassSave.SaveToPlayerPrefs<SavePlayerStats>(GarageController.savePlayerStats, "SavePlayerStats");
    }
    public void loaging()
    {
        GarageController.savePlayerStats = ButtonClassSave.LoadFromPlayerPrefs<SavePlayerStats>(GarageController.savePlayerStats, "SavePlayerStats");
        this.SaveMusic = GarageController.savePlayerStats.Music;
        this.SaveEffect = GarageController.savePlayerStats.Effects;
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
