using System;
using UnityEngine;
using Yodo1.MAS;

public class YodoAnalitycs : MonoBehaviour // Реклама
{
    // Start is called before the first frame update
    private Yodo1U3dBannerAdView bannerAdView;
    public static YodoAnalitycs instance;
    public static event Action OnReset;
    public EnumIdToBuy enumIdToBuy { get; set; }
    private void Awake()
    {
        if (instance != null )
        {
            Destroy(instance);
        }
        instance = this;
    }
    void Start()
    {
        Yodo1AdBuildConfig config = new Yodo1AdBuildConfig().enableUserPrivacyDialog(true);
        Yodo1U3dMas.SetAdBuildConfig(config);
        Yodo1U3dMas.InitializeSdk();
      
        InitializeRewardedAds();

        //InitializeInterstitialAds();
        //this.RequestBanner();
        //if (Yodo1U3dMas.IsInterstitialAdLoaded())
        //{
        //    Debug.Log("Interstitial Ad Loaded");
        //}
        if (Yodo1U3dMas.IsRewardedAdLoaded())
        {
            Debug.Log("Rewarded Ad Loaded");
        }
    }
    private void InitializeInterstitialAds()
    {
        Yodo1U3dMasCallback.Interstitial.OnAdOpenedEvent += OnInterstitialAdOpenedEvent;
        Yodo1U3dMasCallback.Interstitial.OnAdClosedEvent += OnInterstitialAdClosedEvent;
        Yodo1U3dMasCallback.Interstitial.OnAdErrorEvent += OnInterstitialAdErorEvent;
      
    }

    private void OnInterstitialAdOpenedEvent()
    {
        Debug.Log("[Yodo1 Mas] Межстраничное объявление открыто");
    }

    private void OnInterstitialAdClosedEvent()
    {
        Debug.Log("[Yodo1 Mas] Межстраничное объявление закрыто");
    }

    private void OnInterstitialAdErorEvent(Yodo1U3dAdError adError)
    {
        Debug.Log("[Yodo1 Mas] Ошибка межстраничной рекламы -" + adError.ToString());
    }

    public void ShowInterstitial()
    {
        if (!AdsAndIAP.isRemoveADS)
        {
            bool isLoaded = Yodo1U3dMas.IsInterstitialAdLoaded();
            if (isLoaded)
            {
                Yodo1U3dMas.ShowInterstitialAd();
            }
        }
    }


    private void InitializeRewardedAds()
    {
        // Добавить события
        Yodo1U3dMasCallback.Rewarded.OnAdOpenedEvent += OnRewardedAdOpenedEvent;
        Yodo1U3dMasCallback.Rewarded.OnAdClosedEvent += OnRewardedAdClosedEvent;
        Yodo1U3dMasCallback.Rewarded.OnAdReceivedRewardEvent += OnAdReceivedRewardEvent;//Используется.
        Yodo1U3dMasCallback.Rewarded.OnAdErrorEvent += OnRewardedAdErorEvent;
    }

    private void OnRewardedAdOpenedEvent()
    {
        Debug.Log("[Yodo1 Mas] Объявление о вознаграждении открыто");
    }

    private void OnRewardedAdClosedEvent()
    {
        //GameManager.Reward = false;
        //PlayerPrefs.SetString("Reward", GameManager.Reward.ToString());
    }
    //Что получает пользователь при просмотре рекламы.
    private void OnAdReceivedRewardEvent() //TODO Подредактировать
    {
        var SaveClass = FindObjectOfType<GarageController>();
        var DataPresent = FindObjectOfType<UpdatePresentPanel>();
        SaveClass.SetValueSavePlayerStats(enumIdToBuy, true, DataPresent.Money, DataPresent.Diamond);
    }

    private void OnRewardedAdErorEvent(Yodo1U3dAdError adError)
    {
        
    }

    public void ShowReward() //запуск рекламы
    {
        Debug.Log("Show reward");
        if (Debug.isDebugBuild)
        {
            Yodo1EditorAds.RewardedVideoSampleAdEditor.SetActive(true);
        }
        if (!AdsAndIAP.isRemoveADS)
        {
            bool isLoaded = Yodo1U3dMas.IsRewardedAdLoaded();
            if (isLoaded)
            {
                Yodo1U3dMas.ShowRewardedAd();
            }
        }
        else
        {
            Debug.Log("No ads");
            OnAdReceivedRewardEvent();
        }
    }
    private void OnApplicationPause(bool pause)
    {
        /*if (!pause)
        {
            this.RequestBanner();
        }*/
    }

    private void RequestBanner()
    {
        // Clean up banner before reusing
        if (bannerAdView != null)
        {
            bannerAdView.Destroy();
        }

        
        bannerAdView = new Yodo1U3dBannerAdView(Yodo1U3dBannerAdSize.Banner, Yodo1U3dBannerAdPosition.BannerBottom | Yodo1U3dBannerAdPosition.BannerHorizontalCenter);
        // Load banner ads, the banner ad will be displayed automatically after loaded
        bannerAdView.LoadAd();
       // bannerAdView.Show();
    }
}
