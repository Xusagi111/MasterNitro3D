using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MusicSaveVolumeScript : MonoBehaviour
{
    public float SaveMusic { get; set; }
    public float SaveEffect { get; set;  }
    [SerializeField] Slider MusicSlider;
    [SerializeField] Slider EffectsSlider;
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
        SaveMusicState(GarageController.savePlayerStats.Music);
        SaveEffectState( GarageController.savePlayerStats.Effects);
        GetMusicSlider(MusicSlider);
        GetEffectSlider(EffectsSlider);
        
    }
    public void SetMusicSlider(Slider MusicSlider)
    {
        SaveMusic = this.MusicSlider.value;
        SaveMusicState(SaveMusic);
    }
    public float SaveMusicState(float SaveMusic)
    {
        return this.SaveMusic = SaveMusic;
        
    }
    public void  GetMusicSlider(Slider MusicSlider)
    {
        this.MusicSlider.value = SaveMusic;
    }

    public void SetEffectSlider(Slider EffectsSlider)
    {
        SaveEffect = this.EffectsSlider.value;
        SaveEffectState(SaveEffect);
    }
    public float SaveEffectState(float SaveEffect)
    {
        return this.SaveEffect = SaveEffect;
        
    }
    public void GetEffectSlider(Slider EffectsSlider)
    {
        this.EffectsSlider.value = SaveEffect;
    }
   
}
