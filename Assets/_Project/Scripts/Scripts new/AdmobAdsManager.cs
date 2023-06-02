using GoogleMobileAds.Api;
//using GoogleMobileAds.Api.Mediation.AppLovin;
using GoogleMobileAds.Common;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Facebook.Unity;

[Serializable]
public class AdmobId
{
    public string ADMOB_APP_ID;
    public string
        ADMOB_INTERTITIAL_AD_ID_HIGH_ECPM, ADMOB_INTERTITIAL_AD_ID_MEDIUM_ECPM, ADMOB_INTERTITIAL_AD_ID_LOW_ECPM,

        //ADMOB_VIDEO_AD_ID_HIGH_ECPM, ADMOB_VIDEO_AD_ID_MEDIUM_ECPM, ADMOB_VIDEO_AD_ID_LOW_ECPM,

        ADMOB_BANNER_AD_ID_HIGH__ECPM, ADMOB_BANNER_AD_ID_MEDIUM__ECPM, ADMOB_BANNER_AD_ID_LOW__ECPM,

        ADMOB_MEDIUMBANNER_AD_ID_HIGH__ECPM, ADMOB_MEDIUMBANNER_AD_ID_MEDIUM__ECPM, ADMOB_MEDIUMBANNER_AD_ID_LOW__ECPM,

        ADMOB_REWARDED_AD_ID_High_ECPM, ADMOB_REWARDED_AD_ID_Medium_ECPM, ADMOB_REWARDED_AD_ID_Low_ECPM,

        ADMOB_REWARDED_INTERSTITIAL_AD_ID_High_ECPM, ADMOB_REWARDED_INTERSTITIAL_AD_ID_Medium_ECPM, ADMOB_REWARDED_INTERSTITIAL_AD_ID_Low_ECPM;

    public string ADMOB_APPOPEN_ID;
}


public class AdmobAdsManager : MediationHandler
{
    public bool enableTestAds;
    [HideInInspector]
    public bool rewardedInterstitialLoaded;

    private static RewardUserDelegate NotifyReward;
    private bool ForeGroundedAD = false;

    //public static Event MediumECPM;
    //public static Event LowECPM;

    ///private static RewardInterstitialUserDelegate NotifyRewardedInterstitial;

    public AdmobId AndroidAdmob_ID = new AdmobId();
    public AdmobId IosAndroid_ID = new AdmobId();
    public AdmobId TestAdmob_ID = new AdmobId();
    [HideInInspector]
    public AdmobId ADMOB_ID = new AdmobId();

    #region InterstialAds

    [HideInInspector]
    public InterstitialAd interstitial;
    [HideInInspector]
    public InterstitialAd interstitial2;
    [HideInInspector]
    public InterstitialAd interstitial3;

    public delegate void MediumECPM();
    public static event MediumECPM mediumECPM;

    public delegate void LowECPM();
    public static event LowECPM lowEcpm;

    public static bool Interstitial_High = true, Interstitial_Medium, Interstitial_Low;
    #endregion

    //#region VideoAds
    //[HideInInspector]
    //public InterstitialAd videoAd;
    //[HideInInspector]
    //public InterstitialAd videoAd2;
    //[HideInInspector]
    //public InterstitialAd videoAd3;

    //public delegate void VideoMediumECPM();
    //public static event VideoMediumECPM videomediumEcpm;

    //public delegate void VideoLowECPM();
    //public static event VideoLowECPM videoLowEcpm;

    //public static bool Video_High_Ecpm = true, Video_Medium_Ecpm, Video_Low_Ecpm;
    //#endregion

    #region SmallBanner
    [HideInInspector]
    public BannerView SmallBanner_High_ECPM;
    [HideInInspector]
    public BannerView SmallBanner_Medium_ECPM;
    [HideInInspector]
    public BannerView SmallBanner_Low_ECPM;

    public delegate void SmallBannerLowECPM();
    public static event SmallBannerLowECPM SmallBannerLowEcpm;
    public delegate void SmallBannerMediumEcpm();
    public static event SmallBannerMediumEcpm SmallBannerMediumECPM;

    public static bool SmallBanner_High_Ecpm = true, SmallBanner_Medium_Ecpm = false, SmallBanner_LowEcpm = false;
    #endregion

    #region SmalAdaptiveBanner
    [HideInInspector]
    public BannerView SmallAdaptiveBannerhighEcpm;
    [HideInInspector]
    public BannerView SmallAdaptiveBannerMediumEcpm;
    [HideInInspector]
    public BannerView SmallAdaptiveBannerLowEcpm;

    public delegate void SmallAdaptiveBannerMediumECPM();
    public static event SmallAdaptiveBannerMediumECPM SmallAdaptivebannerMediumEcpm;

    public delegate void SmallAdaptiveBannerLowECPM();
    public static event SmallAdaptiveBannerLowECPM SmallAdaptivebannerLowEcpm;

    public static bool smallAdaptiveBanner_High_Ecpm = true, SmallAdaptiveBanner_Medium_Ecpm = false, SmallAdaptiveBanner_Low_Ecpm = false;

    #endregion

    #region SmallSmartBanner

    [HideInInspector]
    public BannerView SmallSmartBannerHighEcpm;
    [HideInInspector]
    public BannerView SmallSmartBannermediumEcpm;
    [HideInInspector]
    public BannerView SmallSmartBannerLowEcpm;

    public delegate void SmallSmartBannerMediumECPM();
    public static event SmallSmartBannerMediumECPM SmallsmartBannermediumEcpm;

    public delegate void SmallSmartBannerLowECPM();
    public static event SmallSmartBannerLowECPM SmallsmartBannerLowEcpm;

    public static bool SmallSmartBanner_High_Ecpm = true, SmallSmartBanner_Medium_Ecpm = false, SmallSmartBanner_Low_Ecpm = false;
    #endregion

    #region MediumBanner
    [HideInInspector]
    public BannerView MediumBannerHighEcpm;
    [HideInInspector]
    public BannerView MediumBannerMediumEcpm;
    [HideInInspector]
    public BannerView MediumBannerLowEcpm;

    public delegate void MediumBannerLowECPM();
    public static event MediumBannerLowECPM MediumbannerLowEcpm;

    public delegate void MediumBannerMediumECPM();
    public static event MediumBannerMediumECPM MediumbannerMediumEcpm;

    public static bool MediumBanner_High_Ecpm = true, MediumBanner_Medium_Ecpm = false, MediumBanner_Low_Ecpm = false;
    #endregion

    #region Rewardedads
    [HideInInspector]
    public RewardedAd rewardBasedVideoHighEcpm;
    [HideInInspector]
    public RewardedAd rewardBasedVideoMediumEcpm;
    [HideInInspector]
    public RewardedAd rewardBasedVideoLowEcpm;

    public delegate void RewardVideoMediumEcpm();
    public static event RewardVideoMediumEcpm RewardVideoMediumECPM;

    public delegate void RewardVideoLowEcpm();
    public static event RewardVideoLowEcpm RewardVideoLowECPM;

    public static bool RewardVideo_High_ECPM = true, RewardVideo_Medium_Ecpm = false, RewardVideo_Low_Ecpm = false;


    #endregion

    #region RewardedInterstitialAds

    [HideInInspector]
    public RewardedInterstitialAd rewardedInterstitialAdHighECPM, rewardedInterstitialAdMediumECPM, rewardedInterstitialAdLowECPM;

    public delegate void RewardInterstitialMediumEcpm();
    public static event RewardInterstitialMediumEcpm RewardInterstitialMediumECPM;

    public delegate void RewardInterstitialLowEcpm();
    public static event RewardInterstitialLowEcpm RewardInterstitialLowECPM;

    public static bool RewardInterstitial_High_ECPM = true, RewardInterstitial_Medium_Ecpm = false, RewardInterstitial_Low_Ecpm = false;

    [HideInInspector]
    public bool rewardedInterstitialHighECPMLoaded, rewardedInterstitialMediumECPMLoaded, rewardedInterstitialLowECPMLoaded;

    #endregion

    #region App Open

    [HideInInspector]
    public AppOpenAd Appopenad;
    private DateTime loadTime;
    private bool isShowingAd = false;
    #endregion

    public static bool isSmallBannerLoaded = false;
    bool isSmallAdaptiveBannerLoaded = false;
    bool isSmallSmartBannerLoaded = false;
    public static bool isMediumBannerLoaded = false;
    bool isAdmobInitialized = false, isAdmobBannerInitialized = false;
    public bool firstTime;
    private bool isMBannerBeingDisplayed = false, IsSBannerBeingDisplayed = false;

    public GameObject Adbreakloading;

    //public Text callBackText;
    void Awake()
    {
        if (Adbreakloading)
            Adbreakloading.SetActive(false);

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        DontDestroyOnLoad(this.gameObject);
        if (enableTestAds)
        {
            ADMOB_ID = TestAdmob_ID;
        }
        else
        {
#if UNITY_ANDROID
            ADMOB_ID = AndroidAdmob_ID;
#elif UNITY_IOS
        ADMOB_ID = IosAndroid_ID;
#endif
        }

        if (Constants.GetBoolpref(Constants.Lowenddevice))
        {
            Debug.Log("GG >> System Memory is less than or equal to 2000, Not Showing Ads");
            adsStatus = AdType.NOAds;
        }
        else
        {
            Debug.Log("GG >> System Memory is greater than 2000, Showing Ads");
            adsStatus = AdType.Ads;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        if (Constants.GetBoolpref(Constants.Lowenddevice))
        {
            Debug.Log("GG >> System Memory is less than for ads, Not Showing Ads");
            return;
        }

        if (adsStatus == AdType.NOAds || Application.internetReachability != NetworkReachability.ReachableViaCarrierDataNetwork && Application.internetReachability != NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            Debug.Log("User_Without_Internet");
            return;
        }
        else
        {
            Init();
        }
    }

    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.Escape))
    //    {
    //        Application.Quit();
    //    }
    //}

    private void Init()
    {
        AdmobGA_Helper.GA_Log(AdmobGAEvents.Initializing);
        //AppLovin.Initialize();
        MobileAds.Initialize((initStatus) =>
        {
            Logging.Log("GG >> Admob:AttemptingInit");
            Dictionary<string, AdapterStatus> map = initStatus.getAdapterStatusMap();
            foreach (KeyValuePair<string, AdapterStatus> keyValuePair in map)
            {
                string className = keyValuePair.Key;
                AdapterStatus status = keyValuePair.Value;
                switch (status.InitializationState)
                {
                    case AdapterState.NotReady:
                        // The adapter initialization did not complete.
                        Logging.Log("GG >> Adapter: " + status.Description + " not ready.Name=" + className);
                        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork | Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
                        {
                            AdmobGA_Helper.GA_Log(AdmobGAEvents.AdaptersNotInitialized);
                        }
                        else
                        {
                            AdmobGA_Helper.GA_Log(AdmobGAEvents.AdapterNotReadyNoInternet);
                        }
                        return;
                        //      Logging.Log("Adapert is :: "+(AdmobGAEvents.AdaptersNotInitialized) + className);
                        break;
                    case AdapterState.Ready:
                        // The adapter was successfully initialized.
                        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork | Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
                        {
                            Logging.Log("GG >> Adapter: " + className + " is initialized.");
                            AdmobGA_Helper.GA_Log(AdmobGAEvents.Initialized);
#if UNITY_ANDROID
                            MediationAdapterConsent(className);
#endif
                        }
                        else
                        {
                            // AdmobGA_Helper.GA_Log(AdmobGAEvents.offlineInit);
                        }

                        break;
                }
            }
#if UNITY_EDITOR
            CreateAdsObjects();
            LoadInterstitial();
            LoadSmallBanner();
            LoadMediumBanner();
            LoadAppOpenAd();
#endif
        });
#if UNITY_IOS
        MobileAds.SetiOSAppPauseOnBackground(true);    
#endif
    }
    /// <summary>
    /// Send User Consent in Open Bidding Adapters Consent
    /// </summary>
    void MediationAdapterConsent(string AdapterClassname)
    {
        if (AdapterClassname.Contains("ExampleClass"))
        {
            isAdmobInitialized = true;
            isAdmobBannerInitialized = true;
        }
        if (AdapterClassname.Contains("MobileAds"))
        {
            isAdmobInitialized = true;
            isAdmobBannerInitialized = true;
            Logging.Log("GG >> Admob Consent has been sent");

            CreateAdsObjects();
            LoadInterstitial();
            LoadSmallBanner();
            LoadMediumBanner();
            LoadAppOpenAd();
        }
        //if (AdapterClassname.Contains("AppLovin"))
        //{
        //    AppLovin.SetHasUserConsent(true);
        //    AppLovin.SetIsAgeRestrictedUser(false);
        //    Logging.Log("GG >> AppLovin Consent has been sent");
        //}
    }

    /// <summary>
    /// Create Ads objects.
    /// </summary>
    private void CreateAdsObjects()
    {

        this.interstitial = new InterstitialAd(ADMOB_ID.ADMOB_INTERTITIAL_AD_ID_HIGH_ECPM);
        this.interstitial2 = new InterstitialAd(ADMOB_ID.ADMOB_INTERTITIAL_AD_ID_MEDIUM_ECPM);
        this.interstitial3 = new InterstitialAd(ADMOB_ID.ADMOB_INTERTITIAL_AD_ID_LOW_ECPM);

        //this.videoAd = new InterstitialAd(ADMOB_ID.ADMOB_VIDEO_AD_ID_HIGH_ECPM);
        //this.videoAd2 = new InterstitialAd(ADMOB_ID.ADMOB_VIDEO_AD_ID_MEDIUM_ECPM);
        //this.videoAd3 = new InterstitialAd(ADMOB_ID.ADMOB_VIDEO_AD_ID_LOW_ECPM);

        this.rewardBasedVideoHighEcpm = new RewardedAd(ADMOB_ID.ADMOB_REWARDED_AD_ID_High_ECPM);
        this.rewardBasedVideoMediumEcpm = new RewardedAd(ADMOB_ID.ADMOB_REWARDED_AD_ID_Medium_ECPM);
        this.rewardBasedVideoLowEcpm = new RewardedAd(ADMOB_ID.ADMOB_REWARDED_AD_ID_Low_ECPM);

        //  this.smal = new BannerView(ADMOB_ID.ADMOB_BANNER_AD_ID_HIGH__ECPM, AdSize.SmartBanner, AdPosition.Center);
        //   this.MediumBanner = new BannerView(ADMOB_ID.ADMOB_MEDIUMBANNER_AD_ID_HIGH__ECPM, AdSize.MediumRectangle, AdPosition.BottomLeft);



    }

    #region Ads Events Bind
    #region BindSmallBannerEvents
    private void BindSmallBannerEvents()
    {

        // INTERSTITIAL EVENTS...//

        this.SmallBanner_High_ECPM.OnAdLoaded += SmallBanner_HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.SmallBanner_High_ECPM.OnAdFailedToLoad += SmallBanner_HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.SmallBanner_High_ECPM.OnAdOpening += SmallBanner_HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.SmallBanner_High_ECPM.OnAdClosed += SmallBanner_HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        //this.SmallBanner.OnAdLeavingApplication += SmallBanner_HandleOnAdLeavingApplication;
    }

    private void BindSmallBannerEvents2()
    {

        // INTERSTITIAL EVENTS...//

        this.SmallBanner_Medium_ECPM.OnAdLoaded += SmallBanner_HandleOnAdLoaded2;
        // Called when an ad request failed to load.
        this.SmallBanner_Medium_ECPM.OnAdFailedToLoad += SmallBanner_HandleOnAdFailedToLoad2;
        // Called when an ad is shown.
        this.SmallBanner_Medium_ECPM.OnAdOpening += SmallBanner_HandleOnAdOpened2;
        // Called when the user returned from the app after an ad click.
        this.SmallBanner_Medium_ECPM.OnAdClosed += SmallBanner_HandleOnAdClosed2;
        // Called when the ad click caused the user to leave the application.
        //this.SmallBanner.OnAdLeavingApplication += SmallBanner_HandleOnAdLeavingApplication;
    }

    private void BindSmallBannerEvents3()
    {

        // INTERSTITIAL EVENTS...//

        this.SmallBanner_Low_ECPM.OnAdLoaded += SmallBanner_HandleOnAdLoaded3;
        // Called when an ad request failed to load.
        this.SmallBanner_Low_ECPM.OnAdFailedToLoad += SmallBanner_HandleOnAdFailedToLoad3;
        // Called when an ad is shown.
        this.SmallBanner_Low_ECPM.OnAdOpening += SmallBanner_HandleOnAdOpened3;
        // Called when the user returned from the app after an ad click.
        this.SmallBanner_Low_ECPM.OnAdClosed += SmallBanner_HandleOnAdClosed3;
        // Called when the ad click caused the user to leave the application.
        //this.SmallBanner.OnAdLeavingApplication += SmallBanner_HandleOnAdLeavingApplication;
    }
    #endregion

    #region bindSmallADaptiveBannerEvent
    private void BindSmallAdaptiveBannerEvents()
    {

        this.SmallAdaptiveBannerhighEcpm.OnAdLoaded += this.HandleAdLoaded;
        this.SmallAdaptiveBannerhighEcpm.OnAdFailedToLoad += this.HandleAdFailedToLoad;
        this.SmallAdaptiveBannerhighEcpm.OnAdOpening += this.HandleAdOpened;
        this.SmallAdaptiveBannerhighEcpm.OnAdClosed += this.HandleAdClosed;
        this.SmallAdaptiveBannerhighEcpm.OnPaidEvent += this.HandleAdLeftApplication;
    }
    private void BindSmallAdaptiveBannerEvents2()
    {

        this.SmallAdaptiveBannerMediumEcpm.OnAdLoaded += this.HandleAdLoaded2;
        this.SmallAdaptiveBannerMediumEcpm.OnAdFailedToLoad += this.HandleAdFailedToLoad2;
        this.SmallAdaptiveBannerMediumEcpm.OnAdOpening += this.HandleAdOpened2;
        this.SmallAdaptiveBannerMediumEcpm.OnAdClosed += this.HandleAdClosed2;
        this.SmallAdaptiveBannerMediumEcpm.OnPaidEvent += this.HandleAdLeftApplication2;
    }
    private void BindSmallAdaptiveBannerEvents3()
    {

        this.SmallAdaptiveBannerLowEcpm.OnAdLoaded += this.HandleAdLoaded3;
        this.SmallAdaptiveBannerLowEcpm.OnAdFailedToLoad += this.HandleAdFailedToLoad3;
        this.SmallAdaptiveBannerLowEcpm.OnAdOpening += this.HandleAdOpened3;
        this.SmallAdaptiveBannerLowEcpm.OnAdClosed += this.HandleAdClosed3;
        this.SmallAdaptiveBannerLowEcpm.OnPaidEvent += this.HandleAdLeftApplication3;
    }
    #endregion

    #region bindSmallSmartBannerEvent
    private void BindSmallSmartBannerEvents()
    {

        this.SmallSmartBannerHighEcpm.OnAdLoaded += this.SmartBanner_HandleAdLoaded;
        this.SmallSmartBannerHighEcpm.OnAdFailedToLoad += this.SmartBanner_HandleAdFailedToLoad;
        this.SmallSmartBannerHighEcpm.OnAdOpening += this.SmartBanner_HandleAdOpened;
        this.SmallSmartBannerHighEcpm.OnAdClosed += this.SmartBanner_HandleAdClosed;
        this.SmallSmartBannerHighEcpm.OnPaidEvent += this.SmartBanner_HandleAdLeftApplication;
    }

    private void BindSmallSmartBannerEvents2()
    {

        this.SmallSmartBannermediumEcpm.OnAdLoaded += this.SmartBanner_HandleAdLoaded2;
        this.SmallSmartBannermediumEcpm.OnAdFailedToLoad += this.SmartBanner_HandleAdFailedToLoad2;
        this.SmallSmartBannermediumEcpm.OnAdOpening += this.SmartBanner_HandleAdOpened2;
        this.SmallSmartBannermediumEcpm.OnAdClosed += this.SmartBanner_HandleAdClosed2;
        this.SmallSmartBannermediumEcpm.OnPaidEvent += this.SmartBanner_HandleAdLeftApplication2;
    }
    private void BindSmallSmartBannerEvents3()
    {

        this.SmallSmartBannerLowEcpm.OnAdLoaded += this.SmartBanner_HandleAdLoaded3;
        this.SmallSmartBannerLowEcpm.OnAdFailedToLoad += this.SmartBanner_HandleAdFailedToLoad3;
        this.SmallSmartBannerLowEcpm.OnAdOpening += this.SmartBanner_HandleAdOpened3;
        this.SmallSmartBannerLowEcpm.OnAdClosed += this.SmartBanner_HandleAdClosed3;
        this.SmallSmartBannerLowEcpm.OnPaidEvent += this.SmartBanner_HandleAdLeftApplication3;
    }
    #endregion

    #region BindmediumBanner
    private void BindMediumBannerEvents()
    {

        // INTERSTITIAL EVENTS...//

        this.MediumBannerHighEcpm.OnAdLoaded += MediumBanner_HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.MediumBannerHighEcpm.OnAdFailedToLoad += MediumBanner_HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.MediumBannerHighEcpm.OnAdOpening += MediumBanner_HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.MediumBannerHighEcpm.OnAdClosed += MediumBanner_HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        //this.MediumBanner.OnAdLeavingApplication += MediumBanner_HandleOnAdLeavingApplication;
    }

    private void BindMediumBannerEvents2()
    {

        // INTERSTITIAL EVENTS...//

        this.MediumBannerMediumEcpm.OnAdLoaded += MediumBanner_HandleOnAdLoaded2;
        // Called when an ad request failed to load.
        this.MediumBannerMediumEcpm.OnAdFailedToLoad += MediumBanner_HandleOnAdFailedToLoad2;
        // Called when an ad is shown.
        this.MediumBannerMediumEcpm.OnAdOpening += MediumBanner_HandleOnAdOpened2;
        // Called when the user returned from the app after an ad click.
        this.MediumBannerMediumEcpm.OnAdClosed += MediumBanner_HandleOnAdClosed2;
        // Called when the ad click caused the user to leave the application.
        //this.MediumBanner.OnAdLeavingApplication += MediumBanner_HandleOnAdLeavingApplication;
    }
    private void BindMediumBannerEvents3()
    {

        // INTERSTITIAL EVENTS...//

        this.MediumBannerLowEcpm.OnAdLoaded += MediumBanner_HandleOnAdLoaded3;
        // Called when an ad request failed to load.
        this.MediumBannerLowEcpm.OnAdFailedToLoad += MediumBanner_HandleOnAdFailedToLoad3;
        // Called when an ad is shown.
        this.MediumBannerLowEcpm.OnAdOpening += MediumBanner_HandleOnAdOpened3;
        // Called when the user returned from the app after an ad click.
        this.MediumBannerLowEcpm.OnAdClosed += MediumBanner_HandleOnAdClosed3;
        // Called when the ad click caused the user to leave the application.
        //this.MediumBanner.OnAdLeavingApplication += MediumBanner_HandleOnAdLeavingApplication;
    }
    #endregion

    #region BindIntertitialEvent
    private void BindIntertitialEvents()
    {

        // INTERSTITIAL EVENTS...//

        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;

        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        //this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;
    }
    private void BindIntertitial2Events()
    {

        // INTERSTITIAL EVENTS...//

        this.interstitial2.OnAdLoaded += HandleOnAdLoaded2;
        // Called when an ad request failed to load.
        this.interstitial2.OnAdFailedToLoad += HandleOnAdFailedToLoad2;

        // Called when an ad is shown.
        this.interstitial2.OnAdOpening += HandleOnAdOpened2;
        // Called when the ad is closed.
        this.interstitial2.OnAdClosed += HandleOnAdClosed2;
        // Called when the ad click caused the user to leave the application.
        //this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;
    }
    private void BindIntertitial3Events()
    {

        // INTERSTITIAL EVENTS...//

        this.interstitial3.OnAdLoaded += HandleOnAdLoaded3;
        // Called when an ad request failed to load.
        this.interstitial3.OnAdFailedToLoad += HandleOnAdFailedToLoad3;

        // Called when an ad is shown.
        this.interstitial3.OnAdOpening += HandleOnAdOpened3;
        // Called when the ad is closed.
        this.interstitial3.OnAdClosed += HandleOnAdClosed3;
        // Called when the ad click caused the user to leave the application.
        //this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;
    }

    #endregion

    //#region BindVideoEvent
    //private void BindVideoEvents()
    //{
    //    // VIDEO AD EVENTS...//

    //    this.videoAd.OnAdLoaded += Video_HandleOnAdLoaded;
    //    // Called when an ad request failed to load.
    //    this.videoAd.OnAdFailedToLoad += Video_HandleOnAdFailedToLoad;

    //    // Called when an ad is shown.
    //    this.videoAd.OnAdOpening += Video_HandleOnAdOpened;
    //    // Called when the ad is closed.
    //    this.videoAd.OnAdClosed += Video_HandleOnAdClosed;
    //    // Called when the ad click caused the user to leave the application.
    //    //this.videoAd.OnAdLeavingApplication += Video_HandleOnAdLeavingApplication;
    //}

    //private void BindVideo2Events()
    //{
    //    // VIDEO AD EVENTS...//

    //    this.videoAd2.OnAdLoaded += Video_HandleOnAdLoaded2;
    //    // Called when an ad request failed to load.
    //    this.videoAd2.OnAdFailedToLoad += Video_HandleOnAdFailedToLoad2;

    //    // Called when an ad is shown.
    //    this.videoAd2.OnAdOpening += Video_HandleOnAdOpened2;
    //    // Called when the ad is closed.
    //    this.videoAd2.OnAdClosed += Video_HandleOnAdClosed2;
    //    // Called when the ad click caused the user to leave the application.
    //    //this.videoAd.OnAdLeavingApplication += Video_HandleOnAdLeavingApplication;
    //}
    //private void BindVideo3Events()
    //{
    //    // VIDEO AD EVENTS...//

    //    this.videoAd3.OnAdLoaded += Video_HandleOnAdLoaded3;
    //    // Called when an ad request failed to load.
    //    this.videoAd3.OnAdFailedToLoad += Video_HandleOnAdFailedToLoad3;

    //    // Called when an ad is shown.
    //    this.videoAd3.OnAdOpening += Video_HandleOnAdOpened3;
    //    // Called when the ad is closed.
    //    this.videoAd3.OnAdClosed += Video_HandleOnAdClosed3;
    //    // Called when the ad click caused the user to leave the application.
    //    //this.videoAd.OnAdLeavingApplication += Video_HandleOnAdLeavingApplication;
    //}

    //#endregion

    #region BindRewardedEvents
    private void BindRewardedEvents()
    {
        //.....REWARDED ADS EVENTS.......//
        //// Get singleton reward based video ad reference.
        //this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Called when an ad request has successfully loaded.
        rewardBasedVideoHighEcpm.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideoHighEcpm.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideoHighEcpm.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        //rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;

        rewardBasedVideoHighEcpm.OnAdFailedToShow += HandleRewardedAdFailedToShow;


        // Called when the user should be rewarded for watching a video.
        rewardBasedVideoHighEcpm.OnUserEarnedReward += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideoHighEcpm.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        //rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
    }
    private void BindRewardedEvents2()
    {
        //.....REWARDED ADS EVENTS.......//
        //// Get singleton reward based video ad reference.
        //this.rewardBasedVideo = RewardBasedVideoAd.Instance;
        Logging.Log("GG >>BindRewarded2");
        // Called when an ad request has successfully loaded.
        rewardBasedVideoMediumEcpm.OnAdLoaded += HandleRewardBasedVideoLoaded2;
        // Called when an ad request failed to load.
        rewardBasedVideoMediumEcpm.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad2;
        // Called when an ad is shown.
        rewardBasedVideoMediumEcpm.OnAdOpening += HandleRewardBasedVideoOpened2;
        // Called when the ad starts to play.
        //rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;

        rewardBasedVideoMediumEcpm.OnAdFailedToShow += HandleRewardedAdFailedToShow2;


        // Called when the user should be rewarded for watching a video.
        rewardBasedVideoMediumEcpm.OnUserEarnedReward += HandleRewardBasedVideoRewarded2;
        // Called when the ad is closed.
        rewardBasedVideoMediumEcpm.OnAdClosed += HandleRewardBasedVideoClosed2;
        // Called when the ad click caused the user to leave the application.
        //rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
    }
    private void BindRewardedEvents3()
    {
        //.....REWARDED ADS EVENTS.......//
        //// Get singleton reward based video ad reference.
        //this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Called when an ad request has successfully loaded.
        rewardBasedVideoLowEcpm.OnAdLoaded += HandleRewardBasedVideoLoaded3;
        // Called when an ad request failed to load.
        rewardBasedVideoLowEcpm.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad3;
        // Called when an ad is shown.
        rewardBasedVideoLowEcpm.OnAdOpening += HandleRewardBasedVideoOpened3;
        // Called when the ad starts to play.
        //rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;

        rewardBasedVideoLowEcpm.OnAdFailedToShow += HandleRewardedAdFailedToShow3;


        // Called when the user should be rewarded for watching a video.
        rewardBasedVideoLowEcpm.OnUserEarnedReward += HandleRewardBasedVideoRewarded3;
        // Called when the ad is closed.
        rewardBasedVideoLowEcpm.OnAdClosed += HandleRewardBasedVideoClosed3;
        // Called when the ad click caused the user to leave the application.
        //rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
    }
    #endregion

    #region BindRewardedInterstitialEvents
    private void adLoadCallbackHighECPM(RewardedInterstitialAd ad, AdFailedToLoadEventArgs error)
    {
        if (error == null)
        {
            rewardedInterstitialAdHighECPM = ad;

            rewardedInterstitialAdHighECPM.OnAdFailedToPresentFullScreenContent += RewardedInterstitialHandleAdFailedToPresentHighECPM;
            rewardedInterstitialAdHighECPM.OnAdDidPresentFullScreenContent += RewardedInterstitialHandleAdDidPresentHighECPM;
            rewardedInterstitialAdHighECPM.OnAdDidDismissFullScreenContent += RewardedInterstitialHandleAdDidDismissHighECPM;
            rewardedInterstitialAdHighECPM.OnPaidEvent += RewardedInterstitialHandlePaidEventHighECPM;
            Logging.Log("GG >> Admob:riad:Loaded_H_ECPM");
            rewardedInterstitialHighECPMLoaded = true;
        }
        else
        {
            // Handle the error.
            Debug.LogFormat("Failed to load the ad. (reason: {0})", error.LoadAdError.GetMessage());
            bool isPrinted = false;
            MobileAdsEventExecutor.ExecuteInUpdate(() =>
            {
                riAdStatus = AdLoadingStatus.NoInventory;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:riad:NoInventory_H_Ecpm :: " + error.ToString());
                }

                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialNoInventory_H_ECPM);
                RewardInterstitial_High_ECPM = false;
                RewardInterstitial_Medium_Ecpm = true;
                RewardInterstitial_Low_Ecpm = false;
                if (RewardInterstitialMediumECPM != null)
                {
                    RewardInterstitialMediumECPM();
                }
            });
            isPrinted = false;
            return;
        }

    }

    private void adLoadCallbackMediumECPM(RewardedInterstitialAd ad, AdFailedToLoadEventArgs error)
    {
        if (error == null)
        {
            rewardedInterstitialAdMediumECPM = ad;

            rewardedInterstitialAdMediumECPM.OnAdFailedToPresentFullScreenContent += RewardedInterstitialHandleAdFailedToPresentMediumECPM;
            rewardedInterstitialAdMediumECPM.OnAdDidPresentFullScreenContent += RewardedInterstitialHandleAdDidPresentMediumECPM;
            rewardedInterstitialAdMediumECPM.OnAdDidDismissFullScreenContent += RewardedInterstitialHandleAdDidDismissMediumECPM;
            rewardedInterstitialAdMediumECPM.OnPaidEvent += RewardedInterstitialHandlePaidEventMediumECPM;
            Logging.Log("GG >> Admob:riad:Loaded_M_ECPM");
            rewardedInterstitialMediumECPMLoaded = true;
        }
        else
        {
            // Handle the error.
            Debug.LogFormat("Failed to load the ad. (reason: {0})", error.LoadAdError.GetMessage());

            bool isPrinted = false;
            MobileAdsEventExecutor.ExecuteInUpdate(() =>
            {
                riAdStatus = AdLoadingStatus.NoInventory;

                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:riad:NoInventory_M_Ecpm :: " + error.ToString());
                }

                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialNoInventory_M_ECPM);
                RewardInterstitial_High_ECPM = false;
                RewardInterstitial_Medium_Ecpm = false;
                RewardInterstitial_Low_Ecpm = true;
                if (RewardInterstitialLowECPM != null)
                {
                    RewardInterstitialLowECPM();
                }
            });
            isPrinted = false;
            return;
        }

    }

    private void adLoadCallbackLowECPM(RewardedInterstitialAd ad, AdFailedToLoadEventArgs error)
    {
        if (error == null)
        {
            rewardedInterstitialAdLowECPM = ad;

            rewardedInterstitialAdLowECPM.OnAdFailedToPresentFullScreenContent += RewardedInterstitialHandleAdFailedToPresentLowECPM;
            rewardedInterstitialAdLowECPM.OnAdDidPresentFullScreenContent += RewardedInterstitialHandleAdDidPresentLowECPM;
            rewardedInterstitialAdLowECPM.OnAdDidDismissFullScreenContent += RewardedInterstitialHandleAdDidDismissLowECPM;
            rewardedInterstitialAdLowECPM.OnPaidEvent += RewardedInterstitialHandlePaidEventLowECPM;
            Logging.Log("GG >> Admob:riad:Loaded_L_ECPM");
            rewardedInterstitialLowECPMLoaded = true;
        }
        else
        {
            // Handle the error.
            Debug.LogFormat("Failed to load the ad. (reason: {0})", error.LoadAdError.GetMessage());
            bool isPrinted = false;
            MobileAdsEventExecutor.ExecuteInUpdate(() =>
            {
                riAdStatus = AdLoadingStatus.NoInventory;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:riad:NoInventory_L_Ecpm :: " + error.ToString());
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialNoInventory_L_ECPM);
                RewardInterstitial_High_ECPM = true;
                RewardInterstitial_Medium_Ecpm = false;
                RewardInterstitial_Low_Ecpm = false;
            });
            isPrinted = false;
            return;
        }

    }
    #endregion

    #region BindAppopenevents
    private void BindAppOpenEvents()
    {
        Appopenad.OnAdDidDismissFullScreenContent += HandleAdDidDismissFullScreenContent;
        Appopenad.OnAdFailedToPresentFullScreenContent += HandleAdFailedToPresentFullScreenContent;
        Appopenad.OnAdDidPresentFullScreenContent += HandleAdDidPresentFullScreenContent;
        Appopenad.OnAdDidRecordImpression += HandleAdDidRecordImpression;
        Appopenad.OnPaidEvent += HandleAppopenPaidEvent;

    }
    #endregion

    /// <summary>
    /// Bind Ads events to receive Ads Data.
    /// </summary>


    #endregion
    #region Load Ads
    public override void LoadSmallBanner()
    {
        if (!isAdmobInitialized || Noads() || IsSmallBannerReady() || smallBannerStatus == AdLoadingStatus.Loading || adsStatus == AdType.NOAds)
        {
            return;
        }
        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork | Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            if (SmallBanner_High_Ecpm)
            {
                Logging.Log("GG >> Admob:smallBanner:LoadRequest_H_Ecpm");

                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadSmallBanner_H_Ecpm);
                SmallBannerMediumECPM += LoadSmallBanner;
                this.SmallBanner_High_ECPM = new BannerView(ADMOB_ID.ADMOB_BANNER_AD_ID_HIGH__ECPM, AdSize.Banner, AdPosition.Top);
                BindSmallBannerEvents();
                // Create an empty ad request.
                AdRequest request = new AdRequest.Builder().Build();

                // Load the banner with the request.
                this.SmallBanner_High_ECPM.LoadAd(request);
                //this.SmallBanner_High_ECPM.Hide();
            }
            else if (SmallBanner_Medium_Ecpm)
            {
                Logging.Log("GG >> Admob:smallBanner:LoadRequest_M_Ecpm");

                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadSmallBanner_M_Ecpm);
                SmallBannerLowEcpm += LoadSmallBanner;
                this.SmallBanner_Medium_ECPM = new BannerView(ADMOB_ID.ADMOB_BANNER_AD_ID_MEDIUM__ECPM, AdSize.Banner, AdPosition.Top);
                BindSmallBannerEvents2();
                // Create an empty ad request.
                AdRequest request = new AdRequest.Builder().Build();

                // Load the banner with the request.
                this.SmallBanner_Medium_ECPM.LoadAd(request);
                //this.SmallBanner_Medium_ECPM.Hide();
            }
            else if (SmallBanner_LowEcpm)
            {
                Logging.Log("GG >> Admob:smallBanner:LoadRequest_L_Ecpm");

                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadSmallBanner_L_Ecpm);
                this.SmallBanner_Low_ECPM = new BannerView(ADMOB_ID.ADMOB_BANNER_AD_ID_LOW__ECPM, AdSize.Banner, AdPosition.Top);
                BindSmallBannerEvents3();
                // Create an empty ad request.
                AdRequest request = new AdRequest.Builder().Build();

                // Load the banner with the request.
                this.SmallBanner_Low_ECPM.LoadAd(request);
                //this.SmallBanner_Low_ECPM.Hide();

            }

        }
    }

    public override void LoadSmallAdaptiveBanner()
    {
        if (Noads() || IsSmallAdaptiveBannerReady() || smallAdaptiveBannerStatus == AdLoadingStatus.Loading || adsStatus == AdType.NOAds)
        {
            return;
        }
        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork | Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            if (smallAdaptiveBanner_High_Ecpm)
            {
                Logging.Log("GG >> Admob:smallAdaptiveBanner:LoadRequest_H_Ecpm");
                SmallAdaptivebannerMediumEcpm += LoadSmallAdaptiveBanner;
                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadSmallAdaptiveBanner_H_Ecpm);
                if (this.SmallAdaptiveBannerhighEcpm != null)
                {
                    this.SmallAdaptiveBannerhighEcpm.Destroy();
                }
                AdSize adaptiveSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

                this.SmallAdaptiveBannerhighEcpm = new BannerView(ADMOB_ID.ADMOB_BANNER_AD_ID_HIGH__ECPM, adaptiveSize, AdPosition.Top);


                BindSmallAdaptiveBannerEvents();
                // Create an empty ad request.
                AdRequest adRequest = new AdRequest.Builder().Build();

                // Load the banner with the request.
                this.SmallAdaptiveBannerhighEcpm.LoadAd(adRequest);
                //this.SmallAdaptiveBannerhighEcpm.Hide();
            }
            else if (SmallAdaptiveBanner_Medium_Ecpm)
            {
                Logging.Log("GG >> Admob:smallAdaptiveBanner:LoadRequest_M_Ecpm");
                SmallAdaptivebannerLowEcpm += LoadSmallAdaptiveBanner;
                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadSmallAdaptiveBanner_M_Ecpm);
                if (this.SmallAdaptiveBannerMediumEcpm != null)
                {
                    this.SmallAdaptiveBannerMediumEcpm.Destroy();
                }
                AdSize adaptiveSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

                this.SmallAdaptiveBannerMediumEcpm = new BannerView(ADMOB_ID.ADMOB_BANNER_AD_ID_MEDIUM__ECPM, adaptiveSize, AdPosition.Top);


                BindSmallAdaptiveBannerEvents2();
                // Create an empty ad request.
                AdRequest adRequest = new AdRequest.Builder().Build();

                // Load the banner with the request.
                this.SmallAdaptiveBannerMediumEcpm.LoadAd(adRequest);
                //  this.SmallAdaptiveBannerMediumEcpm.Hide();

            }
            else if (SmallAdaptiveBanner_Low_Ecpm)
            {
                Logging.Log("GG >> Admob:smallAdaptiveBanner:LoadRequest_L_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadSmallAdaptiveBanner_L_Ecpm);
                if (this.SmallAdaptiveBannerLowEcpm != null)
                {
                    this.SmallAdaptiveBannerLowEcpm.Destroy();
                }
                AdSize adaptiveSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

                this.SmallAdaptiveBannerLowEcpm = new BannerView(ADMOB_ID.ADMOB_BANNER_AD_ID_LOW__ECPM, adaptiveSize, AdPosition.Top);


                BindSmallAdaptiveBannerEvents3();
                // Create an empty ad request.
                AdRequest adRequest = new AdRequest.Builder().Build();

                // Load the banner with the request.
                this.SmallAdaptiveBannerLowEcpm.LoadAd(adRequest);
                //this.SmallAdaptiveBannerLowEcpm.Hide();
            }

        }
    }

    public void LoadSmallSmartBanner()
    {
        if (Noads() || IsSmallSmartBannerReady() || smallSmartBannerStatus == AdLoadingStatus.Loading || adsStatus == AdType.NOAds)
        {
            return;
        }
        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork | Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            if (SmallSmartBanner_High_Ecpm)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:LoadRequest");
                SmallsmartBannermediumEcpm += LoadSmallBanner;
                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadSmallSmartBanner_H_Ecpm);
                if (this.SmallSmartBannerHighEcpm != null)
                {
                    this.SmallSmartBannerHighEcpm.Destroy();
                }


                this.SmallSmartBannerHighEcpm = new BannerView(ADMOB_ID.ADMOB_BANNER_AD_ID_HIGH__ECPM, AdSize.SmartBanner, AdPosition.Top);


                BindSmallSmartBannerEvents();
                // Create an empty ad request.
                AdRequest adRequest = new AdRequest.Builder().Build();

                // Load the banner with the request.
                this.SmallSmartBannerHighEcpm.LoadAd(adRequest);
                //this.SmallSmartBannerHighEcpm.Hide();
            }
            else if (SmallSmartBanner_Medium_Ecpm)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:LoadRequest_M_Ecpm");
                SmallsmartBannerLowEcpm += LoadSmallBanner;
                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadSmallSmartBanner_M_Ecpm);
                if (this.SmallSmartBannerLowEcpm != null)
                {
                    this.SmallSmartBannerLowEcpm.Destroy();
                }


                this.SmallSmartBannerLowEcpm = new BannerView(ADMOB_ID.ADMOB_BANNER_AD_ID_LOW__ECPM, AdSize.SmartBanner, AdPosition.Top);


                BindSmallSmartBannerEvents2();
                // Create an empty ad request.
                AdRequest adRequest = new AdRequest.Builder().Build();

                // Load the banner with the request.
                this.SmallSmartBannerLowEcpm.LoadAd(adRequest);
                // this.SmallSmartBannerLowEcpm.Hide();
            }
            else if (SmallSmartBanner_Low_Ecpm)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:LoadRequest_L_Ecpm");

                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadSmallSmartBanner_L_Ecpm);
                if (this.SmallSmartBannermediumEcpm != null)
                {
                    this.SmallSmartBannermediumEcpm.Destroy();
                }


                this.SmallSmartBannermediumEcpm = new BannerView(ADMOB_ID.ADMOB_BANNER_AD_ID_MEDIUM__ECPM, AdSize.SmartBanner, AdPosition.Top);


                BindSmallSmartBannerEvents3();
                // Create an empty ad request.
                AdRequest adRequest = new AdRequest.Builder().Build();

                // Load the banner with the request.
                this.SmallSmartBannermediumEcpm.LoadAd(adRequest);
                //   this.SmallSmartBannermediumEcpm.Hide();
            }

        }
    }

    public override void LoadMediumBanner()
    {
        if (!isAdmobInitialized || Noads() || IsMediumBannerReady() || mediumBannerStatus == AdLoadingStatus.Loading || adsStatus == AdType.NOAds)
        {
            return;
        }
        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork | Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            if (MediumBanner_High_Ecpm)
            {
                Logging.Log("GG >> Admob:mediumBanner:LoadRequest_H_Ecpm");
                MediumbannerMediumEcpm += LoadMediumBanner;
                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadMediumBanner_H_Ecpm);
#if !UNITY_EDITOR
            //AdSize adSize = new AdSize(width, height);
            this.MediumBannerHighEcpm = new BannerView(ADMOB_ID.ADMOB_MEDIUMBANNER_AD_ID_HIGH__ECPM, AdSize.MediumRectangle, AdPosition.BottomLeft);
#endif
#if UNITY_EDITOR
                this.MediumBannerHighEcpm = new BannerView(ADMOB_ID.ADMOB_MEDIUMBANNER_AD_ID_HIGH__ECPM, AdSize.MediumRectangle, AdPosition.BottomLeft);
#endif
                BindMediumBannerEvents();
                // Create an empty ad request.
                AdRequest request = new AdRequest.Builder().Build();

                // Load the banner with the request.
                this.MediumBannerHighEcpm.LoadAd(request);
                //this.MediumBannerHighEcpm.Hide();
            }
            else if (MediumBanner_Medium_Ecpm)
            {
                Logging.Log("GG >> Admob:mediumBanner:LoadRequest_M_Ecpm");
                MediumbannerLowEcpm += LoadMediumBanner;
                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadMediumBanner_M_Ecpm);
#if !UNITY_EDITOR
            //AdSize adSize = new AdSize(width, height);
            this.MediumBannerMediumEcpm = new BannerView(ADMOB_ID.ADMOB_MEDIUMBANNER_AD_ID_MEDIUM__ECPM, AdSize.MediumRectangle, AdPosition.BottomLeft);
#endif
#if UNITY_EDITOR
                this.MediumBannerMediumEcpm = new BannerView(ADMOB_ID.ADMOB_MEDIUMBANNER_AD_ID_MEDIUM__ECPM, AdSize.MediumRectangle, AdPosition.BottomLeft);
#endif
                BindMediumBannerEvents2();
                // Create an empty ad request.
                AdRequest request = new AdRequest.Builder().Build();

                // Load the banner with the request.
                this.MediumBannerMediumEcpm.LoadAd(request);
                // this.MediumBannerMediumEcpm.Hide();
            }
            else if (MediumBanner_Low_Ecpm)
            {
                Logging.Log("GG >> Admob:mediumBanner:LoadRequest_L_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadMediumBanner_L_Ecpm);
#if !UNITY_EDITOR
            //AdSize adSize = new AdSize(width, height);
            this.MediumBannerLowEcpm = new BannerView(ADMOB_ID.ADMOB_MEDIUMBANNER_AD_ID_LOW__ECPM, AdSize.MediumRectangle, AdPosition.BottomLeft);
#endif
#if UNITY_EDITOR
                this.MediumBannerLowEcpm = new BannerView(ADMOB_ID.ADMOB_MEDIUMBANNER_AD_ID_LOW__ECPM, AdSize.MediumRectangle, AdPosition.BottomLeft);
#endif
                BindMediumBannerEvents3();
                // Create an empty ad request.
                AdRequest request = new AdRequest.Builder().Build();

                // Load the banner with the request.
                this.MediumBannerLowEcpm.LoadAd(request);
                // this.MediumBannerLowEcpm.Hide();
            }

        }
    }



    /// <summary>
    /// Load Interstitial Ad
    /// </summary>
    public override void LoadInterstitial()
    {
        if (!isAdmobInitialized || IsInterstitialAdReady() || iAdStatus == AdLoadingStatus.Loading || Noads() || Constants.adsRemoteConfigStatus == "0" || adsStatus == AdType.NOAds)
        {
            return;
        }
        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork | Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {

            if (Interstitial_High)
            {
                Logging.Log("GG >> Admob:iad:LoadRequest_H_Ecpm");
                mediumECPM += LoadInterstitial;
                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadInterstitialHighAd);
                BindIntertitialEvents();
                // Create an empty ad request.

                AdRequest request = new AdRequest.Builder().Build();
                // Load the interstitial with the request.
                this.interstitial.LoadAd(request);
                iAdStatus = AdLoadingStatus.Loading;

            }
            else if (Interstitial_Medium)
            {
                Logging.Log("GG >> Admob:iad:LoadRequest_M_Ecpm");
                lowEcpm += LoadInterstitial;
                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadInterstitialMediumAd);
                BindIntertitial2Events();
                // Create an empty ad request.

                AdRequest request = new AdRequest.Builder().Build();
                // Load the interstitial with the request.
                this.interstitial2.LoadAd(request);
                iAdStatus = AdLoadingStatus.Loading;
            }
            else if (Interstitial_Low)
            {
                Logging.Log("GG >> Admob:iad:LoadRequest_L_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadInterstitialLowAd);
                BindIntertitial3Events();
                // Create an empty ad request.

                AdRequest request = new AdRequest.Builder().Build();
                // Load the interstitial with the request.
                this.interstitial3.LoadAd(request);
                iAdStatus = AdLoadingStatus.Loading;
            }

        }
    }

    /// <summary>
    /// Load Video Ad
    /// </summary>
    //public override void LoadVideo()
    //{
    //    if (!isAdmobInitialized || IsVideoAdReady() || vAdStatus == AdLoadingStatus.Loading || Noads() || Constants.adsRemoteConfigStatus == "0" || adsStatus == AdType.NOAds)
    //    {
    //        return;
    //    }
    //    if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork | Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
    //    {

    //        if (Video_High_Ecpm)
    //        {
    //            Logging.Log("GG >> Admob:vad:LoadRequest_H_ECPM");
    //            videomediumEcpm += LoadVideo;
    //            AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadVideoAd_High_ECPM);
    //            BindVideoEvents();
    //            // Create an empty ad request.
    //            AdRequest request = new AdRequest.Builder().Build();
    //            // Load the interstitial with the request.
    //            this.videoAd.LoadAd(request);
    //            vAdStatus = AdLoadingStatus.Loading;
    //        }
    //        else if (Video_Medium_Ecpm)
    //        {
    //            Logging.Log("GG >> Admob:vad:LoadRequest_M_ECPM");
    //            videoLowEcpm += LoadVideo;
    //            AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadVideoAd_Medium_ECPM);
    //            BindVideo2Events();
    //            // Create an empty ad request.
    //            AdRequest request = new AdRequest.Builder().Build();
    //            // Load the interstitial with the request.
    //            this.videoAd2.LoadAd(request);
    //            vAdStatus = AdLoadingStatus.Loading;

    //        }
    //        else if (Video_Low_Ecpm)
    //        {
    //            Logging.Log("GG >> Admob:vad:LoadRequest_L_ECPM");
    //            AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadVideoAd_Low_ECPM);
    //            BindVideo3Events();
    //            // Create an empty ad request.
    //            AdRequest request = new AdRequest.Builder().Build();
    //            // Load the interstitial with the request.
    //            this.videoAd3.LoadAd(request);
    //            vAdStatus = AdLoadingStatus.Loading;
    //        }

    //    }
    //}

    /// <summary>
    /// Load Rewarded Ad
    /// </summary>
    public override void LoadRewardedVideo()
    {
        if (!isAdmobInitialized || Noads() || IsRewardedAdReady() || rAdStatus == AdLoadingStatus.Loading || Constants.adsRemoteConfigStatus == "0")
        {
            return;
        }
        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            if (RewardVideo_High_ECPM)
            {
                RewardVideoMediumECPM += LoadRewardedVideo;
                RewardVideoLowECPM -= LoadRewardedVideo;
                Logging.Log("GG >> Admob:rad:LoadRequest_H_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadRewardedAd_H_Ecpm);
                BindRewardedEvents();
                // Create an empty ad request. 
                AdRequest request = new AdRequest.Builder().Build();
                // Load the rewarded video ad with the request.
                this.rewardBasedVideoHighEcpm.LoadAd(request);
                rAdStatus = AdLoadingStatus.Loading;
            }
            else if (RewardVideo_Medium_Ecpm)
            {
                RewardVideoMediumECPM -= LoadRewardedVideo;
                RewardVideoLowECPM += LoadRewardedVideo;
                Logging.Log("GG >> Admob:rad:LoadRequest_M_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadRewardedAd_M_Ecpm);
                BindRewardedEvents2();
                // Create an empty ad request. 
                AdRequest request = new AdRequest.Builder().Build();
                // Load the rewarded video ad with the request.
                this.rewardBasedVideoMediumEcpm.LoadAd(request);
                rAdStatus = AdLoadingStatus.Loading;
            }
            else if (RewardVideo_Low_Ecpm)
            {

                Logging.Log("GG >> Admob:rad:LoadRequest_L_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadRewardedAd_L_Ecpm);
                BindRewardedEvents3();
                // Create an empty ad request. 
                AdRequest request = new AdRequest.Builder().Build();
                // Load the rewarded video ad with the request.
                this.rewardBasedVideoLowEcpm.LoadAd(request);
                rAdStatus = AdLoadingStatus.Loading;
            }

        }

    }

    public /*override*/ void LoadRewardedInterstitial()
    {
        if (!isAdmobInitialized || IsRewardedInterstitialAdReady() || riAdStatus == AdLoadingStatus.Loading || Constants.adsRemoteConfigStatus == "0")
        {
            return;
        }

        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            if (RewardInterstitial_High_ECPM)
            {
                RewardInterstitialMediumECPM += LoadRewardedInterstitial;
                RewardInterstitialLowECPM -= LoadRewardedInterstitial;
                Logging.Log("GG >> Admob:riad:LoadRequest_H_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadRewardedInterstitialAd_H_ECPM);
                // Create an empty ad request.
                AdRequest request = new AdRequest.Builder().Build();
                // Load the rewarded ad with the request.
                RewardedInterstitialAd.LoadAd(ADMOB_ID.ADMOB_REWARDED_INTERSTITIAL_AD_ID_High_ECPM, request, adLoadCallbackHighECPM);
                riAdStatus = AdLoadingStatus.Loading;
            }
            if (RewardInterstitial_Medium_Ecpm)
            {
                RewardInterstitialMediumECPM -= LoadRewardedInterstitial;
                RewardInterstitialLowECPM += LoadRewardedInterstitial;
                Logging.Log("GG >> Admob:riad:LoadRequest_M_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadRewardedInterstitialAd_M_ECPM);
                // Create an empty ad request.
                AdRequest request = new AdRequest.Builder().Build();
                // Load the rewarded ad with the request.
                RewardedInterstitialAd.LoadAd(ADMOB_ID.ADMOB_REWARDED_INTERSTITIAL_AD_ID_Medium_ECPM, request, adLoadCallbackMediumECPM);
                riAdStatus = AdLoadingStatus.Loading;
            }
            if (RewardInterstitial_Low_Ecpm)
            {
                Logging.Log("GG >> Admob:riad:LoadRequest_L_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.LoadRewardedInterstitialAd_L_ECPM);
                // Create an empty ad request.
                AdRequest request = new AdRequest.Builder().Build();
                // Load the rewarded ad with the request.
                RewardedInterstitialAd.LoadAd(ADMOB_ID.ADMOB_REWARDED_INTERSTITIAL_AD_ID_Low_ECPM, request, adLoadCallbackLowECPM);
                riAdStatus = AdLoadingStatus.Loading;
            }

        }

    }

    public override bool IsSmallBannerReady()
    {
        return isSmallBannerLoaded;
    }

    public override bool IsSmallAdaptiveBannerReady()
    {

        return isSmallAdaptiveBannerLoaded;
    }

    public override bool IsSmallSmartBannerReady()
    {
        return isSmallSmartBannerLoaded;
    }

    public override bool IsMediumBannerReady()
    {
        return isMediumBannerLoaded;
    }


    /// <summary>
    /// Check is rAd already loaded
    /// </summary>
    public override bool IsRewardedAdReady()
    {
        if (RewardVideo_High_ECPM)
        {
            if (this.rewardBasedVideoHighEcpm != null)
                return this.rewardBasedVideoHighEcpm.IsLoaded();
            else
                return false;
        }
        else if (RewardVideo_Medium_Ecpm)
        {
            if (this.rewardBasedVideoMediumEcpm != null)
                return this.rewardBasedVideoMediumEcpm.IsLoaded();
            else
                return false;
        }
        else
        {
            if (this.rewardBasedVideoLowEcpm != null)
                return this.rewardBasedVideoLowEcpm.IsLoaded();
            else
                return false;
        }

    }

    public override bool IsRewardedInterstitialAdReady()
    {
        if (this.rewardedInterstitialAdHighECPM != null)
        {
            if (rewardedInterstitialHighECPMLoaded)
            {
                return true;
            }
        }
        if (this.rewardedInterstitialAdMediumECPM != null)
        {
            if (rewardedInterstitialMediumECPMLoaded)
            {
                return true;
            }
        }
        if (this.rewardedInterstitialAdLowECPM != null)
        {
            if (rewardedInterstitialLowECPMLoaded)
            {
                return true;
            }
        }
        return false;


    }

    public override void LoadAppOpenAd()
    {
        if (IsAdAvailable)
        {
            return;
        }

        Debug.Log("Loading the app open ad.");
        // Create our request used to load the ad.
        AdRequest request = new AdRequest.Builder().Build();

        // Load an app open ad for portrait orientation
        AppOpenAd.LoadAd(ADMOB_ID.ADMOB_APPOPEN_ID, ScreenOrientation.Landscape, request, ((appOpenAd, error) =>
        {
            if (error != null)
            {
                // Handle the error.
                Debug.LogFormat("Failed to load the ad. (reason: {0})", error.LoadAdError.GetMessage());
                return;
            }

            // App open ad is loaded.
            Appopenad = appOpenAd;
            Debug.Log("App open ad loaded");

            // TODO: Keep track of time when the ad is loaded.
            loadTime = DateTime.UtcNow;
        }));
    }


    #endregion
    public override void SetSmallBannerPosition(AdPosition position)
    {
        hideSmallBanner();
        try
        {
            if (Noads() || !isAdmobInitialized || !isAdmobBannerInitialized)
            {
                return;
            }
            if (SmallBanner_High_Ecpm)
            {
                Logging.Log("GG >> Admob:smallBanner:ShowCall_H_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowSmallBanner_H_Ecpm);
                if (SmallBanner_High_ECPM != null)
                {
                    IsSBannerBeingDisplayed = true;
                    Logging.Log("GG >> Admob:smallBanner:WillDisplay_H_Ecpm");
                    // this.SmallBanner_High_ECPM.Hide();

                    //  this.SmallBanner_High_ECPM.Show();
                    this.SmallBanner_High_ECPM.SetPosition(position);
                }
                else
                {
                    Debug.Log("SmallBanner_High_Ecpm NULL");
                }

            }
            else if (SmallBanner_Medium_Ecpm)
            {
                Logging.Log("GG >> Admob:smallBanner:ShowCall_M_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowSmallBanner_M_Ecpm);
                if (SmallBanner_Medium_ECPM != null)
                {
                    IsSBannerBeingDisplayed = true;
                    Logging.Log("GG >> Admob:smallBanner:WillDisplay_M_Ecpm");
                    // this.SmallBanner_Medium_ECPM.Hide();

                    //this.SmallBanner_Medium_ECPM.Show();
                    this.SmallBanner_Medium_ECPM.SetPosition(position);
                }
                else
                {
                    Debug.Log("SmallBanner_Medium_Ecpm NULL");
                }
            }
            else if (SmallBanner_LowEcpm)
            {
                Logging.Log("GG >> Admob:smallBanner:ShowCall_L_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowSmallBanner_L_Ecpm);
                if (SmallBanner_Low_ECPM != null)
                {
                    IsSBannerBeingDisplayed = true;
                    Logging.Log("GG >> Admob:smallBanner:WillDisplay_L_Ecpm");
                    // this.SmallBanner_Low_ECPM.Hide();

                    // this.SmallBanner_Low_ECPM.Show();
                    this.SmallBanner_Low_ECPM.SetPosition(position);
                }
                else
                {
                    Debug.Log("SmallBanner_LowEcpm NULL");
                    LoadSmallBanner();
                }
            }

        }
        catch (Exception error)
        {
            Logging.Log("Small Banner Error: " + error);
        }

    }

    #region Show Ads
    public override void HideSmallBannerEvent()
    {
        if (!isAdmobBannerInitialized)
            return;
        if (IsSBannerBeingDisplayed)
            Logging.Log("GG >> Admob:smallBanner:Hide");
        if (this.SmallBanner_High_ECPM != null)
        {
            this.SmallBanner_High_ECPM.Hide();
            IsSBannerBeingDisplayed = false;
        }
        // }
        //else if (SmallBanner_Medium_Ecpm)
        //{
        if (this.SmallBanner_Medium_ECPM != null)
        {
            this.SmallBanner_Medium_ECPM.Hide();
            IsSBannerBeingDisplayed = false;
        }
        //  }
        //else if (SmallBanner_LowEcpm)
        //{
        if (this.SmallBanner_Low_ECPM != null)
        {
            this.SmallBanner_Low_ECPM.Hide();
            IsSBannerBeingDisplayed = false;
        }
        //  }


    }
    public override void HideSmallAdaptiveBannerEvent()
    {
        if (!isAdmobBannerInitialized)
            return;

        if (this.SmallAdaptiveBannerhighEcpm != null)
        {
            Logging.Log("GG >> Admob:smallAdaptiveBanner:Hide");
            this.SmallAdaptiveBannerhighEcpm.Hide();
        }
        //  }
        //else if (SmallAdaptiveBanner_Medium_Ecpm)
        //{
        if (this.SmallAdaptiveBannerMediumEcpm != null)
        {
            Logging.Log("GG >> Admob:smallAdaptiveBanner:Hide");
            this.SmallAdaptiveBannerMediumEcpm.Hide();
        }
        //}
        //else if (SmallAdaptiveBanner_Low_Ecpm)
        //{
        if (this.SmallAdaptiveBannerLowEcpm != null)
        {
            Logging.Log("GG >> Admob:smallAdaptiveBanner:Hide");
            this.SmallAdaptiveBannerLowEcpm.Hide();
        }
        // }

    }
    public override void HideSmallSmartBannerEvent()
    {
        if (!isAdmobBannerInitialized)
            return;
        if (SmallSmartBanner_High_Ecpm)
        {
            if (this.SmallSmartBannerHighEcpm != null)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:Hide");
                this.SmallSmartBannerHighEcpm.Hide();
            }
        }
        else if (SmallSmartBanner_Medium_Ecpm)
        {
            if (this.SmallSmartBannermediumEcpm != null)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:Hide");
                this.SmallSmartBannermediumEcpm.Hide();
            }
        }
        else if (SmallSmartBanner_Low_Ecpm)
        {
            if (this.SmallSmartBannerLowEcpm != null)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:Hide");
                this.SmallSmartBannerLowEcpm.Hide();
            }
        }

    }
    public override void HideMediumBannerEvent()
    {
        if (!isAdmobBannerInitialized)
            return;
        Logging.Log("GG >> Admob:mediumBanner:Hide");
        if (this.MediumBannerHighEcpm != null)
        {
            isMBannerBeingDisplayed = false;
            this.MediumBannerHighEcpm.Hide();
        }
        if (this.MediumBannerMediumEcpm != null)
        {
            isMBannerBeingDisplayed = false;
            this.MediumBannerMediumEcpm.Hide();
        }
        if (this.MediumBannerLowEcpm != null)
        {
            isMBannerBeingDisplayed = false;
            this.MediumBannerLowEcpm.Hide();
        }
    }

    public override void ShowSmallBanner(AdPosition position)
    {
        hideSmallBanner();
        try
        {
            if (Noads() || !isAdmobInitialized || !isAdmobBannerInitialized)
            {
                return;
            }
            if (SmallBanner_High_Ecpm)
            {
                Logging.Log("GG >> Admob:smallBanner:ShowCall_H_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowSmallBanner_H_Ecpm);
                if (SmallBanner_High_ECPM != null)
                {
                    IsSBannerBeingDisplayed = true;
                    Logging.Log("GG >> Admob:smallBanner:WillDisplay_H_Ecpm");
                    // this.SmallBanner_High_ECPM.Hide();

                    this.SmallBanner_High_ECPM.Show();
                    this.SmallBanner_High_ECPM.SetPosition(position);
                }
                else
                {
                    Debug.Log("SmallBanner_High_Ecpm NULL");
                    LoadSmallBanner();
                }

            }
            else if (SmallBanner_Medium_Ecpm)
            {
                Logging.Log("GG >> Admob:smallBanner:ShowCall_M_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowSmallBanner_M_Ecpm);
                if (SmallBanner_Medium_ECPM != null)
                {
                    IsSBannerBeingDisplayed = true;
                    Logging.Log("GG >> Admob:smallBanner:WillDisplay_M_Ecpm");
                    // this.SmallBanner_Medium_ECPM.Hide();

                    this.SmallBanner_Medium_ECPM.Show();
                    this.SmallBanner_Medium_ECPM.SetPosition(position);
                }
                else
                {
                    Debug.Log("SmallBanner_Medium_Ecpm NULL");
                    LoadSmallBanner();
                }
            }
            else if (SmallBanner_LowEcpm)
            {
                Logging.Log("GG >> Admob:smallBanner:ShowCall_L_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowSmallBanner_L_Ecpm);
                if (SmallBanner_Low_ECPM != null)
                {
                    IsSBannerBeingDisplayed = true;
                    Logging.Log("GG >> Admob:smallBanner:WillDisplay_L_Ecpm");
                    // this.SmallBanner_Low_ECPM.Hide();

                    this.SmallBanner_Low_ECPM.Show();
                    this.SmallBanner_Low_ECPM.SetPosition(position);
                }
                else
                {
                    Debug.Log("SmallBanner_LowEcpm NULL");
                    LoadSmallBanner();
                }
            }

        }
        catch (Exception error)
        {
            Logging.Log("Small Banner Error: " + error);
        }

    }
    public override void ShowSmallAdaptiveBanner(AdPosition position)
    {
        try
        {
            if (Noads() || !isAdmobInitialized || !isAdmobBannerInitialized)
            {
                return;
            }
            if (smallAdaptiveBanner_High_Ecpm)
            {
                Logging.Log("GG >> Admob:smallAdaptiveBanner:ShowCall_H_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowSmallAdaptiveBanner_H_Ecpm);
                if (SmallAdaptiveBannerhighEcpm != null)
                {
                    Logging.Log("GG >> Admob:smallAdaptiveBanner:WillDisplay_H_Ecpm");
                    this.SmallAdaptiveBannerhighEcpm.Hide();
                    this.SmallAdaptiveBannerhighEcpm.Show();
                    this.SmallAdaptiveBannerhighEcpm.SetPosition(position);

                }
            }
            else if (SmallAdaptiveBanner_Medium_Ecpm)
            {
                Logging.Log("GG >> Admob:smallAdaptiveBanner:ShowCall_M_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowSmallAdaptiveBanner_M_Ecpm);
                if (SmallAdaptiveBannerMediumEcpm != null)
                {
                    Logging.Log("GG >> Admob:smallAdaptiveBanner:WillDisplay_M_Ecpm");
                    this.SmallAdaptiveBannerMediumEcpm.Hide();
                    this.SmallAdaptiveBannerMediumEcpm.Show();
                    this.SmallAdaptiveBannerMediumEcpm.SetPosition(position);

                }

            }
            else if (SmallAdaptiveBanner_Low_Ecpm)
            {
                Logging.Log("GG >> Admob:smallAdaptiveBanner:ShowCall_L_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowSmallAdaptiveBanner_L_Ecpm);
                if (SmallAdaptiveBannerLowEcpm != null)
                {
                    Logging.Log("GG >> Admob:smallAdaptiveBanner:WillDisplay_L_Ecpm");
                    this.SmallAdaptiveBannerLowEcpm.Hide();
                    this.SmallAdaptiveBannerLowEcpm.Show();
                    this.SmallAdaptiveBannerLowEcpm.SetPosition(position);

                }
                else
                {
                    Logging.Log("GG >> Admob:smallAdaptiveBanner:AdNotLoaded_L_Ecpm");
                    LoadSmallAdaptiveBanner();
                }
            }

        }
        catch (Exception error)
        {
            Logging.Log("Small Adaptive Banner Error: " + error);
        }

    }
    public override void ShowSmallSmartBanner(AdPosition position)
    {

        try
        {
            if (Noads() || !isAdmobInitialized || !isAdmobBannerInitialized)
            {
                return;
            }
            if (SmallSmartBanner_High_Ecpm)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:ShowCall_H_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowSmallSmartBanner_H_Ecpm);
                if (SmallSmartBannerHighEcpm != null)
                {
                    Logging.Log("GG >> Admob:smallSmartBanner:WillDisplay_H_Ecpm");
                    this.SmallSmartBannerHighEcpm.Hide();
                    this.SmallSmartBannerHighEcpm.Show();
                    this.SmallSmartBannerHighEcpm.SetPosition(position);
                }
            }
            else if (SmallSmartBanner_Medium_Ecpm)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:ShowCall_M_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowSmallSmartBanner_M_Ecpm);
                if (SmallSmartBannermediumEcpm != null)
                {
                    Logging.Log("GG >> Admob:smallSmartBanner:WillDisplay_M_Ecpm");
                    this.SmallSmartBannermediumEcpm.Hide();
                    this.SmallSmartBannermediumEcpm.Show();
                    this.SmallSmartBannermediumEcpm.SetPosition(position);
                }

            }
            else if (SmallSmartBanner_Low_Ecpm)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:ShowCall_L_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowSmallSmartBanner_L_Ecpm);
                if (SmallSmartBannerLowEcpm != null)
                {
                    Logging.Log("GG >> Admob:smallSmartBanner:WillDisplay_L_Ecpm");
                    this.SmallSmartBannerLowEcpm.Hide();
                    this.SmallSmartBannerLowEcpm.Show();
                    this.SmallSmartBannerLowEcpm.SetPosition(position);
                }
                else
                {
                    Logging.Log("GG >> Admob:smallSmartBanner:AdNotLoaded");
                    LoadSmallSmartBanner();
                }
            }

        }
        catch (Exception error)
        {
            Logging.Log("Small Smart Banner Error: " + error);
        }

    }
    public override bool IsMediumBannerBeingDisplayed()
    {
        return isMBannerBeingDisplayed;
    }
    public override void ShowMediumBanner(AdPosition position)
    {
        try
        {

            if (Noads() || !isAdmobInitialized || !isAdmobBannerInitialized)
            {
                return;
            }
            if (MediumBanner_High_Ecpm)
            {
                Logging.Log("GG >> Admob:mediumBanner:ShowCall_H_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowMediumBanner_H_Ecpm);
                if (MediumBannerHighEcpm != null)
                {
                    isMBannerBeingDisplayed = true;
                    Logging.Log("GG >> Admob:mediumBanner:WillDisplay_H_Ecpm");
                    this.MediumBannerHighEcpm.Hide();
                    this.MediumBannerHighEcpm.Show();
                    this.MediumBannerHighEcpm.SetPosition(position);
                }
                else
                {
                    Logging.Log("GG >> Admob:MediumBanner_High_Ecpm:AdNotLoaded");
                    LoadMediumBanner();
                }
            }
            else if (MediumBanner_Medium_Ecpm)
            {
                Logging.Log("GG >> Admob:mediumBanner:ShowCall_M_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowMediumBanner_M_Ecpm);
                if (MediumBannerMediumEcpm != null)
                {
                    isMBannerBeingDisplayed = true;
                    Logging.Log("GG >> Admob:mediumBanner:WillDisplay_M_Ecpm");
                    this.MediumBannerMediumEcpm.Hide();
                    this.MediumBannerMediumEcpm.Show();
                    this.MediumBannerMediumEcpm.SetPosition(position);
                }
                else
                {
                    Logging.Log("GG >> Admob:MediumBanner_Medium_Ecpm:AdNotLoaded");
                    LoadMediumBanner();
                }
            }
            else if (MediumBanner_Low_Ecpm)
            {
                Logging.Log("GG >> Admob:mediumBanner:ShowCall_L_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowMediumBanner_L_Ecpm);
                if (MediumBannerLowEcpm != null)
                {
                    isMBannerBeingDisplayed = true;
                    Logging.Log("GG >> Admob:mediumBanner:WillDisplay_L_Ecpm");
                    this.MediumBannerLowEcpm.Hide();
                    this.MediumBannerLowEcpm.Show();
                    this.MediumBannerLowEcpm.SetPosition(position);
                }
                else
                {
                    Logging.Log("GG >> Admob:mediumBanner:AdNotLoaded");
                    LoadMediumBanner();
                }
            }

            //Logging.Log("GG >> Admob:smallBanner:Displayed");
        }
        catch (Exception e)
        {
            Logging.Log("Medium Banner Error: " + e);
        }

    }

    /// <summary>
    /// Show Interstitial Ad
    /// </summary>
    public override void ShowInterstitial()
    {


        if (Noads() || !isAdmobInitialized)
        {
            return;
        }

        if (Interstitial_High)
        {
            if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
            {

                Logging.Log("GG >> Admob:iad:ShowCall_H_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowInterstitialAdHigh);

            }
            else
            {
                Debug.Log("GG >> Admob:iad:ShowCall:Offline");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstialOffline);
            }

            if (this.interstitial != null)
            {
                if (this.interstitial.IsLoaded())
                {

                    Logging.Log("GG >> Admob:iad:WillDisplay");
                    AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstitialAdWillDisplayHigh);
                    ForeGroundedAD = true;
                    this.interstitial.Show();

                }
            }


        }
        else if (Interstitial_Medium)
        {

            if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
            {
                Logging.Log("GG >> Admob:iad:ShowCall_M_Ecmp");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowInterstitialAdMedium);

            }
            else
            {
                Debug.Log("GG >> Admob:iad:ShowCall:Offline");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstialOffline);
            }

            if (this.interstitial2 != null)
            {
                if (this.interstitial2.IsLoaded())
                {

                    Logging.Log("GG >> Admob:iad:WillDisplay_M_Ecpm");
                    AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstitialAdWillDisplayMedium);
                    ForeGroundedAD = true;
                    this.interstitial2.Show();

                }
            }

        }
        else if (Interstitial_Low)
        {

            if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
            {
                Logging.Log("GG >> Admob:iad:ShowCall_L_Ecmp");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowInterstitialAdLow);

            }
            else
            {
                Debug.Log("GG >> Admob:iad:ShowCall:Offline");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstialOffline);
            }
            if (this.interstitial3 != null)
            {
                if (this.interstitial3.IsLoaded())
                {

                    Logging.Log("GG >> Admob:iad:WillDisplay");
                    AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstitialAdWillDisplayLow);
                    ForeGroundedAD = true;
                    this.interstitial3.Show();

                }
            }
        }


    }
    public override bool IsInterstitialAdReady()
    {
        if (Interstitial_High)
        {
            if (this.interstitial != null)
                return this.interstitial.IsLoaded();
            else
                return false;
        }
        else if (Interstitial_Medium)
        {

            if (this.interstitial2 != null)
                return this.interstitial2.IsLoaded();
            else
                return false;
        }
        else
        {
            if (this.interstitial3 != null)
                return this.interstitial3.IsLoaded();
            else
                return false;
        }

    }

    //private IEnumerator ShowInterstitialWithDelay(float delay)
    //{
    //    yield return new WaitForSecondsRealtime(delay);
    //    this.interstitial.Show();
    //}
    /// <summary>
    /// Show Video Ad
    /// </summary>
    //public override void ShowVideo()
    //{

    //    if (Video_High_Ecpm)
    //    {
    //        Logging.Log("GG >> Admob:vad:ShowCall_H_Ecpm");
    //        AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowVideoAd_H_ECPM);

    //        if (this.videoAd.IsLoaded())
    //        {

    //            Logging.Log("GG >> Admob:vad:WillDisplay");
    //            AdmobGA_Helper.GA_Log(AdmobGAEvents.VideoAdWillDisplay_H_ECPM);

    //            this.videoAd.Show();


    //        }
    //        //else
    //        //{
    //        //    Logging.Log("GG >> Admob:vad:NotLoaded");
    //        //    LoadVideo();
    //        //}

    //    }
    //    else if (Video_Medium_Ecpm)
    //    {
    //        Logging.Log("GG >> Admob:vad:ShowCall_M_Ecpm");
    //        AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowVideoAd_M_ECPM);

    //        if (this.videoAd2.IsLoaded())
    //        {

    //            Logging.Log("GG >> Admob:vad:WillDisplay_M_Ecpm");
    //            AdmobGA_Helper.GA_Log(AdmobGAEvents.VideoAdWillDisplay_M_ECPM);

    //            this.videoAd2.Show();


    //        }
    //        //else
    //        //{
    //        //    Logging.Log("GG >> Admob:vad:NotLoaded");
    //        //    LoadVideo();
    //        //}
    //    }
    //    else if (Video_Low_Ecpm)
    //    {
    //        Logging.Log("GG >> Admob:vad:ShowCall_L_Ecpm");
    //        AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowVideoAd_L_ECPM);

    //        if (this.videoAd3.IsLoaded())
    //        {

    //            Logging.Log("GG >> Admob:vad:WillDisplay_L_Ecpm");
    //            AdmobGA_Helper.GA_Log(AdmobGAEvents.VideoAdWillDisplay_L_ECPM);

    //            this.videoAd2.Show();


    //        }
    //    }

    //}
    //public override bool IsVideoAdReady()
    //{
    //    if (Video_High_Ecpm)
    //    {
    //        if (this.videoAd != null)
    //            return this.videoAd.IsLoaded();
    //        else
    //            return false;
    //    }
    //    else if (Video_Medium_Ecpm)
    //    {
    //        if (this.videoAd2 != null)
    //            return this.videoAd2.IsLoaded();
    //        else
    //            return false;
    //    }
    //    else
    //    {
    //        if (this.videoAd3 != null)
    //            return this.videoAd2.IsLoaded();
    //        else
    //            return false;
    //    }

    //}
    //private IEnumerator ShowVideoWithDelay()
    //{
    //    yield return new WaitForSecondsRealtime(1f);
    //    this.videoAd.Show();
    //}
    /// <summary>
    /// Show Rewarded Ad
    /// </summary>
    //public override void ShowRewardedVideo()
    //{

    //}
    public void ShowRewardedVideoBtnEvent()
    {
        ShowRewardedVideo(EventGiveReward);
    }
    private void EventGiveReward()
    {
        Logging.Log("Reward Successfully Given!");
    }
    public override void ShowRewardedVideo(RewardUserDelegate _delegate)
    {
        if (!isAdmobInitialized)
            return;
        if (!IsRewardedAdReady())
            return;

        if (RewardVideo_High_ECPM)
        {
            Logging.Log("GG >> Admob:rad:ShowCall");
            NotifyReward = _delegate;
            AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowRewardedAd_H_Ecpm);

            if (this.rewardBasedVideoHighEcpm != null)
            {
                if (this.rewardBasedVideoHighEcpm.IsLoaded())
                {
                    Logging.Log("GG >> Admob:rad:WillDisplay");
                    ForeGroundedAD = true;
                    AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdWillDisplay_H_Ecpm);
                    this.rewardBasedVideoHighEcpm.Show();

                }
            }

        }
        else if (RewardVideo_Medium_Ecpm)
        {
            Logging.Log("GG >> Admob:rad:ShowCall_M_Ecpm");
            NotifyReward = _delegate;
            AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowRewardedAd_M_Ecpm);

            if (this.rewardBasedVideoMediumEcpm != null)
            {
                if (this.rewardBasedVideoMediumEcpm.IsLoaded())
                {
                    Logging.Log("GG >> Admob:rad:WillDisplay_M_Ecpm");
                    ForeGroundedAD = true;
                    AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdWillDisplay_M_Ecpm);
                    this.rewardBasedVideoMediumEcpm.Show();

                }
            }
        }
        else if (RewardVideo_Low_Ecpm)
        {
            Logging.Log("GG >> Admob:rad:ShowCall_L_Ecpm");
            NotifyReward = _delegate;
            AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowRewardedAd_L_Ecpm);

            if (this.rewardBasedVideoLowEcpm != null)
            {
                if (this.rewardBasedVideoLowEcpm.IsLoaded())
                {
                    Logging.Log("GG >> Admob:rad:WillDisplay_L_Ecpm");
                    ForeGroundedAD = true;
                    AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdWillDisplay_L_Ecpm);
                    this.rewardBasedVideoLowEcpm.Show();

                }
            }
        }
    }

    public /*override*/ void ShowRewardedInterstitialAd(RewardUserDelegate _delegate)
    {
        if (RewardInterstitial_High_ECPM)
        {
            Logging.Log("GG >> Admob:riad:ShowCall_H_ECPM");
            NotifyReward = _delegate;
            AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowRewardedInterstitialAd_H_ECPM);

            if (this.rewardedInterstitialAdHighECPM != null)
            {
                if (rewardedInterstitialHighECPMLoaded)
                {
                    Logging.Log("GG >> Admob:riad:WillDisplay_H_ECPM");

                    //  AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialAdWillDisplay_H_ECPM);
                    this.rewardedInterstitialAdHighECPM.Show(userEarnedRewardCallback);
                }
            }

        }
        else if (RewardInterstitial_Medium_Ecpm)
        {
            Logging.Log("GG >> Admob:riad:ShowCall_M_ECPM");
            NotifyReward = _delegate;
            AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowRewardedInterstitialAd_M_ECPM);

            if (this.rewardedInterstitialAdMediumECPM != null)
            {
                if (rewardedInterstitialMediumECPMLoaded)
                {
                    Logging.Log("GG >> Admob:riad:WillDisplay_M_ECPM");

                    //   AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialAdWillDisplay_M_ECPM);
                    this.rewardedInterstitialAdMediumECPM.Show(userEarnedRewardCallback);
                }
            }
        }
        else if (RewardInterstitial_Low_Ecpm)
        {
            Logging.Log("GG >> Admob:riad:ShowCall_L_ECPM");
            NotifyReward = _delegate;
            AdmobGA_Helper.GA_Log(AdmobGAEvents.ShowRewardedInterstitialAd_L_ECPM);

            if (this.rewardedInterstitialAdLowECPM != null)
            {
                if (rewardedInterstitialLowECPMLoaded)
                {
                    Logging.Log("GG >> Admob:riad:WillDisplay_L_ECPM");

                    //  AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialAdWillDisplay_L_ECPM);
                    this.rewardedInterstitialAdLowECPM.Show(userEarnedRewardCallback);
                }
            }
        }
    }

    public override void ShowAppOpenAd()
    {

        if (!isAdmobInitialized || Noads() || IsRewardedAdReady() || rAdStatus == AdLoadingStatus.Loading || Constants.adsRemoteConfigStatus == "0")
        {
            return;
        }
        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {

            if (!IsAdAvailable || isShowingAd)
            {
                return;
            }
            if (Appopenad != null)
            {
                Debug.Log("Showing app open ad.");

                BindAppOpenEvents();
                Appopenad.Show();
            }
            else
            {
                Debug.LogError("App open ad is not ready yet.");
            }
        }
    }
    private bool IsAdAvailable
    {
        get
        {
            // TODO: Consider ad expiration
            return Appopenad != null && (System.DateTime.UtcNow - loadTime).TotalHours < 4;
        }
    }
    private void userEarnedRewardCallback(Reward reward)
    {
        // TODO: Reward the user.
        //Logging.Log("User Rewarded");
    }


    #endregion

    #region Intertitial Add Handler


    //******Intertitial Ad Handlers**********//
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (Interstitial_High)
            {
                iAdStatus = AdLoadingStatus.Loaded;
                if (!isPrinted)
                {
                    Logging.Log("GG >> Admob:iad:Loaded_H_Ecpm");
                    isPrinted = true;
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstitialAdLoadedHigh);
                mediumECPM -= LoadInterstitial;
                Interstitial_High = true;
                Interstitial_Medium = false;
                Interstitial_Low = false;
            }

        });
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (Interstitial_High)
            {

                iAdStatus = AdLoadingStatus.NoInventory;
                Logging.Log("GG >> Admob:iad:NoInventory_H_Ecpm :: " + args.ToString());
                AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstitialAdNoInventoryHigh);
                Interstitial_High = false;
                Interstitial_Medium = true;
                if (mediumECPM != null)
                    mediumECPM();


            }

        });
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            iAdStatus = AdLoadingStatus.NotLoaded;

            Constants.isAdPlaying = true;

            if (Interstitial_High)
            {
                AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstitialAdDisplayedHigh);
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:iad:Displayed_H_Ecpm");
                }
                mediumECPM -= LoadInterstitial;

            }


        });
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {

        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstitialAdClosed_High_ECPM);
            Constants.isAdPlaying = false;
            iAdStatus = AdLoadingStatus.NotLoaded;

            if (Interstitial_High)
            {
                this.interstitial.Destroy();
                this.interstitial = new InterstitialAd(ADMOB_ID.ADMOB_INTERTITIAL_AD_ID_HIGH_ECPM);

                mediumECPM -= LoadInterstitial;
                if (!isPrinted)
                {
                    Logging.Log("GG >> Admob:iad:Closed_H_Ecpm");
                    isPrinted = true;
                }
                Interstitial_High = true;
                Interstitial_Medium = false;
                Interstitial_Low = false;
            }

            //OnInterstitialClosed();

        });
    }

    //******Intertitial2 Ad Handlers**********//
    public void HandleOnAdLoaded2(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (Interstitial_Medium)
            {
                iAdStatus = AdLoadingStatus.Loaded;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:iad:Loaded_M_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstitialAdLoadedMedium);
                lowEcpm -= LoadInterstitial;
                Interstitial_High = false;
                Interstitial_Medium = true;
                Interstitial_Low = false;
            }


        });
    }

    public void HandleOnAdFailedToLoad2(object sender, AdFailedToLoadEventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {


            if (Interstitial_Medium)
            {
                iAdStatus = AdLoadingStatus.NoInventory;
                Logging.Log("GG >> Admob:iad:NoInventory_M_Ecpm :: " + args.ToString());
                AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstitialAdNoInventoryMedium);
                Interstitial_High = false;
                Interstitial_Medium = false;
                Interstitial_Low = true;
                if (lowEcpm != null)
                    lowEcpm();
            }


        });
    }

    public void HandleOnAdOpened2(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            iAdStatus = AdLoadingStatus.NotLoaded;

            Constants.isAdPlaying = true;
            if (Interstitial_Medium)
            {
                AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstitialAdDisplayedMedium);
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:iad:Displayed_M_Ecpm");
                }
                lowEcpm -= LoadInterstitial;
            }

        });
    }

    public void HandleOnAdClosed2(object sender, EventArgs args)
    {

        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {

            AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstitialAdClosed_Medium_ECPM);
            Constants.isAdPlaying = false;
            iAdStatus = AdLoadingStatus.NotLoaded;

            if (Interstitial_Medium)
            {
                lowEcpm -= LoadInterstitial;
                this.interstitial2.Destroy();
                this.interstitial2 = new InterstitialAd(ADMOB_ID.ADMOB_INTERTITIAL_AD_ID_MEDIUM_ECPM);
                if (!isPrinted)
                {
                    Logging.Log("GG >> Admob:iad:Closed_M_Ecpm");
                    isPrinted = true;
                }
                Interstitial_High = true;
                Interstitial_Medium = false;
                Interstitial_Low = false;
            }

            //OnInterstitialClosed();

        });
    }

    //******Intertitial3 Ad Handlers**********//
    public void HandleOnAdLoaded3(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (Interstitial_Low)
            {
                iAdStatus = AdLoadingStatus.Loaded;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:iad:Loaded_L_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstitialAdLoadedLow);
                Interstitial_High = false;
                Interstitial_Medium = false;
                Interstitial_Low = true;
            }

        });
    }

    public void HandleOnAdFailedToLoad3(object sender, AdFailedToLoadEventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {


            if (Interstitial_Low)
            {
                iAdStatus = AdLoadingStatus.NoInventory;
                Logging.Log("GG >> Admob:iad:NoInventory_L_Ecpm :: " + args.ToString());
                AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstitialAdNoInventorylow);
                Interstitial_High = true;
                Interstitial_Medium = false;
                Interstitial_Low = false;
            }

        });
    }

    public void HandleOnAdOpened3(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            iAdStatus = AdLoadingStatus.NotLoaded;

            Constants.isAdPlaying = true;

            AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstitialAdDisplayedLow);
            if (!isPrinted)
            {
                Logging.Log("GG >> Admob:iad:Displayed_L_Ecpm");
                isPrinted = true;
            }


        });
    }

    public void HandleOnAdClosed3(object sender, EventArgs args)
    {

        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {

            AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstitialAdClosed_Low_ECPM);
            Constants.isAdPlaying = false;
            iAdStatus = AdLoadingStatus.NotLoaded;


            if (Interstitial_Low)
            {
                this.interstitial3.Destroy();
                this.interstitial3 = new InterstitialAd(ADMOB_ID.ADMOB_INTERTITIAL_AD_ID_LOW_ECPM);
                Interstitial_High = true;
                Interstitial_Medium = false;
                Interstitial_Low = false;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:iad:Closed_L_Ecpm");
                }
            }
            //OnInterstitialClosed();

        });
    }

    //public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    //{
    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        Logging.Log("GG >> Admob:iad:Clicked");
    //        AdmobGA_Helper.GA_Log(AdmobGAEvents.InterstitialAdClicked);
    //    });
    //}

    #endregion

    #region Small Banner Add Handler


    //******Small Banner Ad Handlers**********//
    public void SmallBanner_HandleOnAdLoaded(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallBanner_High_Ecpm)
            {
                smallBannerStatus = AdLoadingStatus.Loaded;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:smallBanner:Loaded_H_Ecpm");
                }
                //callBackText.text = "Small Banner Loaded of Size: " + BannersHandler.instance.width.text + "*" + BannersHandler.instance.height.text;
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallBannerLoaded_H_Ecpm);
                SmallBannerMediumECPM -= LoadSmallBanner;
                isSmallBannerLoaded = true;
            }

        });
    }

    public void SmallBanner_HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallBanner_High_Ecpm)
            {
                smallBannerStatus = AdLoadingStatus.NoInventory;
                Logging.Log("GG >> Admob:smallBanner:NoInventory_H_Ecpm :: " + args.ToString());
                //callBackText.text = "There is no inventory of small Banner for the given size";
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallBannerNoInventory_H_Ecpm);
                isSmallBannerLoaded = false;
                SmallBanner_High_Ecpm = false;
                SmallBanner_Medium_Ecpm = true;
                if (SmallBannerMediumECPM != null)
                    SmallBannerMediumECPM();
            }
        });
    }

    public void SmallBanner_HandleOnAdOpened(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallBanner_High_Ecpm)
            {
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:smallBanner:Displayed_H_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallBannerDisplayed_H_Ecpm);
                SmallBannerMediumECPM -= LoadSmallBanner;

            }
        });
    }
    public void SmallBanner_HandleOnAdClosed(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallBanner_High_Ecpm)
            {
                if (!isPrinted)
                {
                    Logging.Log("GG >> Admob:smallBanner:Closed_H_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallBannerClosed_H_Ecpm);
                SmallBannerMediumECPM -= LoadSmallBanner;
            }

        });
    }
    public void SmallBanner_HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallBanner_High_Ecpm)
            {
                Logging.Log("GG >> Admob:smallBanner:Clicked");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallBannerClicked);
                SmallBannerMediumECPM -= LoadSmallBanner;
            }

        });
    }
    //******Small Banner2 Ad Handlers**********//
    public void SmallBanner_HandleOnAdLoaded2(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallBanner_Medium_Ecpm)
            {
                smallBannerStatus = AdLoadingStatus.Loaded;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:smallBanner:Loaded_M_Ecpm");
                }
                //callBackText.text = "Small Banner Loaded of Size: " + BannersHandler.instance.width.text + "*" + BannersHandler.instance.height.text;
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallBannerLoaded_M_Ecpm);
                SmallBannerLowEcpm -= LoadSmallBanner;
                isSmallBannerLoaded = true;
            }

        });
    }

    public void SmallBanner_HandleOnAdFailedToLoad2(object sender, AdFailedToLoadEventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallBanner_Medium_Ecpm)
            {
                smallBannerStatus = AdLoadingStatus.NoInventory;
                Logging.Log("GG >> Admob:smallBanner:NoInventory_M_Ecpm :: " + args.ToString());
                //callBackText.text = "There is no inventory of small Banner for the given size";
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallBannerNoInventory_M_Ecpm);
                isSmallBannerLoaded = false;
                SmallBanner_High_Ecpm = false;
                SmallBanner_Medium_Ecpm = false;
                SmallBanner_LowEcpm = true;
                if (SmallBannerLowEcpm != null)
                    SmallBannerLowEcpm();
            }
        });
    }

    public void SmallBanner_HandleOnAdOpened2(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallBanner_Medium_Ecpm)
            {
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:smallBanner:Displayed_M_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallBannerDisplayed_M_Ecpm);
                SmallBannerLowEcpm -= LoadSmallBanner;

            }
        });
    }
    public void SmallBanner_HandleOnAdClosed2(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallBanner_Medium_Ecpm)
            {
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:smallBanner:Closed_M_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallBannerClosed_M_Ecpm);
                SmallBannerLowEcpm -= LoadSmallBanner;
            }

        });
    }
    public void SmallBanner_HandleOnAdLeavingApplication2(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallBanner_Medium_Ecpm)
            {
                Logging.Log("GG >> Admob:smallBanner:Clicked");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallBannerClicked);
                SmallBannerLowEcpm -= LoadSmallBanner;
            }

        });
    }
    //******Small Banner3 Ad Handlers**********//
    public void SmallBanner_HandleOnAdLoaded3(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallBanner_LowEcpm)
            {
                smallBannerStatus = AdLoadingStatus.Loaded;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:smallBanner:Loaded_L_Ecpm");
                }
                //callBackText.text = "Small Banner Loaded of Size: " + BannersHandler.instance.width.text + "*" + BannersHandler.instance.height.text;
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallBannerLoaded_L_Ecpm);

                isSmallBannerLoaded = true;
            }

        });
    }

    public void SmallBanner_HandleOnAdFailedToLoad3(object sender, AdFailedToLoadEventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallBanner_LowEcpm)
            {
                smallBannerStatus = AdLoadingStatus.NoInventory;
                Logging.Log("GG >> Admob:smallBanner:NoInventory_L_Ecpm :: " + args.ToString());
                //callBackText.text = "There is no inventory of small Banner for the given size";
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallBannerNoInventory_L_Ecpm);
                isSmallBannerLoaded = false;

            }
        });
    }

    public void SmallBanner_HandleOnAdOpened3(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallBanner_LowEcpm)
            {
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:smallBanner:Displayed_L_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallBannerDisplayed_L_Ecpm);


            }
        });
    }
    public void SmallBanner_HandleOnAdClosed3(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallBanner_LowEcpm)
            {
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:smallBanner:Closed_L_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallBannerClosed_L_Ecpm);

            }

        });
    }
    public void SmallBanner_HandleOnAdLeavingApplication3(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallBanner_LowEcpm)
            {

                Logging.Log("GG >> Admob:smallBanner:Clicked");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallBannerClicked);

            }

        });
    }
    #endregion

    #region Adaptive Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
    {

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (smallAdaptiveBanner_High_Ecpm)
            {
                smallAdaptiveBannerStatus = AdLoadingStatus.Loaded;
                Logging.Log("GG >> Admob:smallAdaptiveBanner:Loaded_H_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerLoaded_H_Ecpm);
                isSmallAdaptiveBannerLoaded = true;
                SmallAdaptivebannerMediumEcpm -= LoadSmallAdaptiveBanner;
            }
        });
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (smallAdaptiveBanner_High_Ecpm)
            {
                smallAdaptiveBannerStatus = AdLoadingStatus.NoInventory;
                Logging.Log("GG >> Admob:smallAdaptiveBanner:NoInventory_H_Ecpm :: " + args.ToString());
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerNoInventory_H_Ecpm);
                isSmallAdaptiveBannerLoaded = false;
                smallAdaptiveBanner_High_Ecpm = false;
                SmallAdaptiveBanner_Medium_Ecpm = true;
                if (SmallAdaptivebannerMediumEcpm != null)
                    SmallAdaptivebannerMediumEcpm();
            }

        });
    }

    public void HandleAdOpened(object sender, EventArgs args)
    {


        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (smallAdaptiveBanner_High_Ecpm)
            {
                Logging.Log("GG >> Admob:smallAdaptiveBanner:Displayed_H_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerDisplayed_H_Ecpm);
                SmallAdaptivebannerMediumEcpm -= LoadSmallAdaptiveBanner;
            }
        });
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {


        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (smallAdaptiveBanner_High_Ecpm)
            {

                Logging.Log("GG >> Admob:smallAdaptiveBanner:Closed");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerClosed_H_Ecpm);
                SmallAdaptivebannerMediumEcpm -= LoadSmallAdaptiveBanner;
            }
        });
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (smallAdaptiveBanner_High_Ecpm)
            {

                Logging.Log("GG >> Admob:smallAdaptiveBanner:Clicked");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerClicked);
                SmallAdaptivebannerMediumEcpm -= LoadSmallAdaptiveBanner;
            }
        });
    }

    //Adapitve Banner2
    public void HandleAdLoaded2(object sender, EventArgs args)
    {

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallAdaptiveBanner_Medium_Ecpm)
            {
                smallAdaptiveBannerStatus = AdLoadingStatus.Loaded;
                Logging.Log("GG >> Admob:smallAdaptiveBanner:Loaded_M_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerLoaded_M_Ecpm);
                isSmallAdaptiveBannerLoaded = true;
                SmallAdaptivebannerLowEcpm -= LoadSmallAdaptiveBanner;
            }
        });
    }

    public void HandleAdFailedToLoad2(object sender, AdFailedToLoadEventArgs args)
    {

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallAdaptiveBanner_Medium_Ecpm)
            {
                smallAdaptiveBannerStatus = AdLoadingStatus.NoInventory;
                Logging.Log("GG >> Admob:smallAdaptiveBanner:NoInventory_M_Ecpm :: " + args.ToString());
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerNoInventory_M_Ecpm);
                isSmallAdaptiveBannerLoaded = false;
                smallAdaptiveBanner_High_Ecpm = false;
                SmallAdaptiveBanner_Medium_Ecpm = false;
                SmallAdaptiveBanner_Low_Ecpm = true;
                if (SmallAdaptivebannerLowEcpm != null)
                    SmallAdaptivebannerLowEcpm();
            }

        });
    }

    public void HandleAdOpened2(object sender, EventArgs args)
    {


        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallAdaptiveBanner_Medium_Ecpm)
            {
                Logging.Log("GG >> Admob:smallAdaptiveBanner:Displayed_H_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerDisplayed_H_Ecpm);
                SmallAdaptivebannerLowEcpm -= LoadSmallAdaptiveBanner;
            }
        });
    }

    public void HandleAdClosed2(object sender, EventArgs args)
    {


        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallAdaptiveBanner_Medium_Ecpm)
            {

                Logging.Log("GG >> Admob:smallAdaptiveBanner:Closed");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerClosed_H_Ecpm);
                SmallAdaptivebannerLowEcpm -= LoadSmallAdaptiveBanner;
            }
        });
    }

    public void HandleAdLeftApplication2(object sender, EventArgs args)
    {

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallAdaptiveBanner_Medium_Ecpm)
            {

                Logging.Log("GG >> Admob:smallAdaptiveBanner:Clicked");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerClicked);
                SmallAdaptivebannerLowEcpm -= LoadSmallAdaptiveBanner;
            }
        });
    }

    //Adapitve Banner3
    public void HandleAdLoaded3(object sender, EventArgs args)
    {

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallAdaptiveBanner_Low_Ecpm)
            {
                smallAdaptiveBannerStatus = AdLoadingStatus.Loaded;
                Logging.Log("GG >> Admob:smallAdaptiveBanner:Loaded_L_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerLoaded_L_Ecpm);
                isSmallAdaptiveBannerLoaded = true;

            }
        });
    }

    public void HandleAdFailedToLoad3(object sender, AdFailedToLoadEventArgs args)
    {

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallAdaptiveBanner_Low_Ecpm)
            {
                smallAdaptiveBannerStatus = AdLoadingStatus.NoInventory;
                Logging.Log("GG >> Admob:smallAdaptiveBanner:NoInventory_L_Ecpm :: " + args.ToString());
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerNoInventory_L_Ecpm);
                isSmallAdaptiveBannerLoaded = false;

            }

        });
    }

    public void HandleAdOpened3(object sender, EventArgs args)
    {


        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallAdaptiveBanner_Low_Ecpm)
            {
                Logging.Log("GG >> Admob:smallAdaptiveBanner:Displayed_L_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerDisplayed_L_Ecpm);

            }
        });
    }

    public void HandleAdClosed3(object sender, EventArgs args)
    {


        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallAdaptiveBanner_Low_Ecpm)
            {

                Logging.Log("GG >> Admob:smallAdaptiveBanner:Closed");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerClosed_L_Ecpm);

            }
        });
    }

    public void HandleAdLeftApplication3(object sender, EventArgs args)
    {

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallAdaptiveBanner_Low_Ecpm)
            {

                Logging.Log("GG >> Admob:smallAdaptiveBanner:Clicked");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerClicked);

            }
        });
    }
    #endregion

    #region Smart Banner callback handlers

    public void SmartBanner_HandleAdLoaded(object sender, EventArgs args)
    {



        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallSmartBanner_High_Ecpm)
            {
                smallSmartBannerStatus = AdLoadingStatus.Loaded;
                Logging.Log("GG >> Admob:smallSmartBanner:Loaded");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerLoaded_H_Ecpm);
                SmallsmartBannermediumEcpm -= LoadMediumBanner;
                isSmallSmartBannerLoaded = true;
            }

        });
    }

    public void SmartBanner_HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallSmartBanner_High_Ecpm)
            {
                smallSmartBannerStatus = AdLoadingStatus.NoInventory;
                Logging.Log("GG >> Admob:smallSmartBanner:NoInventory_H_Ecpm :: " + args.ToString());
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallSmartBannerNoInventory_H_Ecpm);
                SmallSmartBanner_High_Ecpm = false;
                SmallSmartBanner_Medium_Ecpm = true;
                isSmallSmartBannerLoaded = false;
                if (SmallsmartBannermediumEcpm != null)
                {
                    SmallsmartBannermediumEcpm();

                }
            }
        });
    }

    public void SmartBanner_HandleAdOpened(object sender, EventArgs args)
    {


        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallSmartBanner_High_Ecpm)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:Displayed");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallSmartBannerDisplayed_H_Ecpm);
                SmallAdaptivebannerMediumEcpm -= LoadMediumBanner;

            }

        });
    }

    public void SmartBanner_HandleAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallSmartBanner_High_Ecpm)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:Closed");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallSmartBannerClosed_H_Ecpm);
                SmallAdaptivebannerMediumEcpm -= LoadMediumBanner;

            }
        });
    }

    public void SmartBanner_HandleAdLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeftApplication event received");
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallSmartBanner_High_Ecpm)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:Clicked");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallSmartBannerClicked);
                SmallAdaptivebannerMediumEcpm -= LoadMediumBanner;
            }

        });
    }
    //SmartBanner2 Callbacks
    public void SmartBanner_HandleAdLoaded2(object sender, EventArgs args)
    {



        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallSmartBanner_Medium_Ecpm)
            {
                smallSmartBannerStatus = AdLoadingStatus.Loaded;
                Logging.Log("GG >> Admob:smallSmartBanner:Loaded_M_Ecpm)");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerLoaded_M_Ecpm);
                SmallsmartBannerLowEcpm -= LoadMediumBanner;
                isSmallSmartBannerLoaded = true;
            }

        });
    }

    public void SmartBanner_HandleAdFailedToLoad2(object sender, AdFailedToLoadEventArgs args)
    {

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallSmartBanner_Medium_Ecpm)
            {
                smallSmartBannerStatus = AdLoadingStatus.NoInventory;
                Logging.Log("GG >> Admob:smallSmartBanner:NoInventory_M_Ecpm :: " + args.ToString());
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallSmartBannerNoInventory_M_Ecpm);
                SmallSmartBanner_High_Ecpm = false;
                SmallSmartBanner_Medium_Ecpm = false;
                SmallSmartBanner_Low_Ecpm = true;
                isSmallSmartBannerLoaded = false;
                if (SmallsmartBannerLowEcpm != null)
                {
                    SmallsmartBannerLowEcpm();

                }
            }
        });
    }

    public void SmartBanner_HandleAdOpened2(object sender, EventArgs args)
    {


        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallSmartBanner_Medium_Ecpm)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:Displayed_M_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallSmartBannerDisplayed_M_Ecpm);
                SmallAdaptivebannerLowEcpm -= LoadMediumBanner;

            }

        });
    }

    public void SmartBanner_HandleAdClosed2(object sender, EventArgs args)
    {

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallSmartBanner_Medium_Ecpm)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:Closed");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallSmartBannerClosed_M_Ecpm);
                SmallAdaptivebannerLowEcpm -= LoadMediumBanner;

            }
        });
    }

    public void SmartBanner_HandleAdLeftApplication2(object sender, EventArgs args)
    {

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallSmartBanner_Medium_Ecpm)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:Clicked");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallSmartBannerClicked);
                SmallAdaptivebannerLowEcpm -= LoadMediumBanner;
            }

        });
    }
    //SmartBanner3CallBacks
    public void SmartBanner_HandleAdLoaded3(object sender, EventArgs args)
    {



        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallSmartBanner_Low_Ecpm)
            {
                smallSmartBannerStatus = AdLoadingStatus.Loaded;
                Logging.Log("GG >> Admob:smallSmartBanner:Loaded_L_Ecpm)");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallAdaptiveBannerLoaded_L_Ecpm);
                isSmallSmartBannerLoaded = true;
            }

        });
    }

    public void SmartBanner_HandleAdFailedToLoad3(object sender, AdFailedToLoadEventArgs args)
    {

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallSmartBanner_Low_Ecpm)
            {
                smallSmartBannerStatus = AdLoadingStatus.NoInventory;
                Logging.Log("GG >> Admob:smallSmartBanner:NoInventory_L_Ecpm :: " + args.ToString());
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallSmartBannerNoInventory_L_Ecpm);

                isSmallSmartBannerLoaded = false;

            }
        });
    }

    public void SmartBanner_HandleAdOpened3(object sender, EventArgs args)
    {


        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallSmartBanner_Low_Ecpm)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:Displayed_L_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallSmartBannerDisplayed_L_Ecpm);


            }

        });
    }

    public void SmartBanner_HandleAdClosed3(object sender, EventArgs args)
    {

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallSmartBanner_Low_Ecpm)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:Closed");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallSmartBannerClosed_L_Ecpm);


            }
        });
    }

    public void SmartBanner_HandleAdLeftApplication3(object sender, EventArgs args)
    {

        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (SmallSmartBanner_Low_Ecpm)
            {
                Logging.Log("GG >> Admob:smallSmartBanner:Clicked");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.SmallSmartBannerClicked);


            }

        });
    }

    #endregion

    #region MediumBannerCallBack Handlers
    public void MediumBanner_HandleOnAdLoaded(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_High_Ecpm)
            {
                mediumBannerStatus = AdLoadingStatus.Loaded;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:mediumBanner:Loaded_H_Ecpm");
                }
                //callBackText.text = "Medium Banner Loaded of Size: " + BannersHandler.instance.width.text + "*" + BannersHandler.instance.height.text;
                AdmobGA_Helper.GA_Log(AdmobGAEvents.MediumBannerLoaded_H_Ecpm);
                MediumbannerMediumEcpm -= LoadMediumBanner;
                isMediumBannerLoaded = true;
            }

        });
    }

    public void MediumBanner_HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_High_Ecpm)
            {
                mediumBannerStatus = AdLoadingStatus.NotLoaded;
                Logging.Log("GG >> Admob:mediumBanner:NoInventory_H_Ecpm :: " + args.ToString());
                //callBackText.text = "There is no inventory of medium Banner for the given size";
                AdmobGA_Helper.GA_Log(AdmobGAEvents.MediumBannerNoInventory_H_Ecpm);
                MediumBanner_High_Ecpm = false;
                MediumBanner_Medium_Ecpm = true;
                isMediumBannerLoaded = false;
                if (MediumbannerMediumEcpm != null)
                {
                    MediumbannerMediumEcpm();
                }
            }

        });

    }

    public void MediumBanner_HandleOnAdOpened(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_High_Ecpm)
            {
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:mediumBanner:Displayed_H_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.MediumBannerDisplayed_H_Ecpm);
                MediumbannerMediumEcpm -= LoadMediumBanner;
            }
        });
    }

    public void MediumBanner_HandleOnAdClosed(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_High_Ecpm)
            {
                Logging.Log("GG >> Admob:mediumBanner:Closed");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.MediumBannerClosed_H_Ecpm);
                MediumbannerMediumEcpm -= LoadMediumBanner;
            }
        });
    }

    public void MediumBanner_HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_High_Ecpm)
            {
                Logging.Log("GG >> Admob:mediumBanner:Clicked");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.MediumBannerClicked);
                MediumbannerMediumEcpm -= LoadMediumBanner;
            }
        });
    }

    //MediumBanner2
    public void MediumBanner_HandleOnAdLoaded2(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_Medium_Ecpm)
            {
                mediumBannerStatus = AdLoadingStatus.Loaded;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:mediumBanner:Loaded_M_Ecpm");
                }
                //callBackText.text = "Medium Banner Loaded of Size: " + BannersHandler.instance.width.text + "*" + BannersHandler.instance.height.text;
                AdmobGA_Helper.GA_Log(AdmobGAEvents.MediumBannerLoaded_M_Ecpm);
                MediumbannerLowEcpm -= LoadMediumBanner;
                isMediumBannerLoaded = true;
            }

        });
    }

    public void MediumBanner_HandleOnAdFailedToLoad2(object sender, AdFailedToLoadEventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_Medium_Ecpm)
            {
                mediumBannerStatus = AdLoadingStatus.NotLoaded;
                Logging.Log("GG >> Admob:mediumBanner:NoInventory_M_Ecpm :: " + args.ToString());
                //callBackText.text = "There is no inventory of medium Banner for the given size";
                AdmobGA_Helper.GA_Log(AdmobGAEvents.MediumBannerNoInventory_M_Ecpm);
                MediumBanner_High_Ecpm = false;
                MediumBanner_Medium_Ecpm = false;
                MediumBanner_Low_Ecpm = true;
                isMediumBannerLoaded = false;
                if (MediumbannerLowEcpm != null)
                {
                    MediumbannerLowEcpm();
                }
            }

        });

    }

    public void MediumBanner_HandleOnAdOpened2(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_Medium_Ecpm)
            {
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:mediumBanner:Displayed_M_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.MediumBannerDisplayed_M_Ecpm);
                MediumbannerLowEcpm -= LoadMediumBanner;
            }
        });
    }

    public void MediumBanner_HandleOnAdClosed2(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_Medium_Ecpm)
            {
                Logging.Log("GG >> Admob:mediumBanner:Closed");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.MediumBannerClosed_M_Ecpm);
                MediumbannerLowEcpm -= LoadMediumBanner;
            }
        });
    }

    public void MediumBanner_HandleOnAdLeavingApplication2(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_Medium_Ecpm)
            {
                Logging.Log("GG >> Admob:mediumBanner:Clicked");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.MediumBannerClicked);
                MediumbannerLowEcpm -= LoadMediumBanner;
            }
        });
    }

    //MediumBanner3

    public void MediumBanner_HandleOnAdLoaded3(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_Low_Ecpm)
            {
                mediumBannerStatus = AdLoadingStatus.Loaded;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:mediumBanner:Loaded_L_Ecpm");
                }
                //callBackText.text = "Medium Banner Loaded of Size: " + BannersHandler.instance.width.text + "*" + BannersHandler.instance.height.text;
                AdmobGA_Helper.GA_Log(AdmobGAEvents.MediumBannerLoaded_M_Ecpm);

                isMediumBannerLoaded = true;
            }

        });
    }

    public void MediumBanner_HandleOnAdFailedToLoad3(object sender, AdFailedToLoadEventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_Low_Ecpm)
            {
                mediumBannerStatus = AdLoadingStatus.NotLoaded;
                Logging.Log("GG >> Admob:mediumBanner:NoInventory_L_Ecpm :: " + args.ToString());
                //callBackText.text = "There is no inventory of medium Banner for the given size";
                AdmobGA_Helper.GA_Log(AdmobGAEvents.MediumBannerNoInventory_L_Ecpm);

                isMediumBannerLoaded = false;

            }

        });

    }

    public void MediumBanner_HandleOnAdOpened3(object sender, EventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_Low_Ecpm)
            {
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:mediumBanner:Displayed_L_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.MediumBannerDisplayed_L_Ecpm);

            }
        });
    }

    public void MediumBanner_HandleOnAdClosed3(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_Low_Ecpm)
            {
                Logging.Log("GG >> Admob:mediumBanner:Closed");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.MediumBannerClosed_L_Ecpm);

            }
        });
    }

    public void MediumBanner_HandleOnAdLeavingApplication3(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (MediumBanner_Low_Ecpm)
            {
                Logging.Log("GG >> Admob:mediumBanner:Clicked");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.MediumBannerClicked);

            }
        });
    }
    #endregion

    //#region Video Ad Handlers
    ////******Video Ad Handlers**********//
    //public void Video_HandleOnAdLoaded(object sender, EventArgs args)
    //{
    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        if (Video_High_Ecpm)
    //        {

    //            vAdStatus = AdLoadingStatus.Loaded;
    //            Logging.Log("GG >> Admob:vad:Loaded");
    //            AdmobGA_Helper.GA_Log(AdmobGAEvents.VideoAdLoaded_H_ECPM);
    //            videomediumEcpm -= LoadVideo;
    //        }
    //    });
    //}

    //public void Video_HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    //{
    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        if (Video_High_Ecpm)
    //        {

    //            vAdStatus = AdLoadingStatus.NoInventory;
    //            Logging.Log("GG >> Admob:vad:NoInventory :: " + args.ToString());
    //            AdmobGA_Helper.GA_Log(AdmobGAEvents.VideoAdNoInventory_H_ECPM);
    //            Video_High_Ecpm = false;
    //            Video_Medium_Ecpm = true;
    //            if (mediumECPM != null)
    //            {

    //                videomediumEcpm();
    //            }

    //        }
    //    });
    //}


    //public void Video_HandleOnAdOpened(object sender, EventArgs args)
    //{
    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        if (Video_High_Ecpm)
    //        {

    //            vAdStatus = AdLoadingStatus.NotLoaded;
    //            Logging.Log("GG >> Admob:vad:Displayed_H_ECPM");
    //            AdmobGA_Helper.GA_Log(AdmobGAEvents.VideoAdDisplayed_H_ECPM);
    //            Constants.isAdPlaying = true;
    //        }
    //    });
    //}

    //public void Video_HandleOnAdClosed(object sender, EventArgs args)
    //{


    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        if (Video_High_Ecpm)
    //        {
    //            this.videoAd.Destroy();
    //            this.videoAd = new InterstitialAd(ADMOB_ID.ADMOB_VIDEO_AD_ID_HIGH_ECPM);
    //            BindVideoEvents();
    //            videomediumEcpm -= LoadVideo;
    //        }
    //        vAdStatus = AdLoadingStatus.NotLoaded;
    //        Logging.Log("GG >> Admob:vad:Closed");
    //        AdmobGA_Helper.GA_Log(AdmobGAEvents.VideoAdClosed_High_ECPM);
    //        Constants.isAdPlaying = false;

    //    });
    //    //OnVideoClosed();
    //    //Invoke("OnVideoClosed", 2f);
    //}
    ////******Video2 Ad Handlers**********//
    //public void Video_HandleOnAdLoaded2(object sender, EventArgs args)
    //{
    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        vAdStatus = AdLoadingStatus.Loaded;
    //        Logging.Log("GG >> Admob:vad:Loaded");
    //        AdmobGA_Helper.GA_Log(AdmobGAEvents.VideoAdLoaded_M_ECPM);
    //        videoLowEcpm -= LoadVideo;
    //    });
    //}

    //public void Video_HandleOnAdFailedToLoad2(object sender, AdFailedToLoadEventArgs args)
    //{
    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        if (Video_Medium_Ecpm)
    //        {

    //            vAdStatus = AdLoadingStatus.NoInventory;
    //            Logging.Log("GG >> Admob:vad:NoInventory :: " + args.ToString());
    //            AdmobGA_Helper.GA_Log(AdmobGAEvents.VideoAdNoInventory_M_ECPM);
    //            Video_High_Ecpm = false;
    //            Video_Medium_Ecpm = false;
    //            Video_Low_Ecpm = true;
    //            videoLowEcpm();
    //        }
    //    });
    //}


    //public void Video_HandleOnAdOpened2(object sender, EventArgs args)
    //{
    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        vAdStatus = AdLoadingStatus.NotLoaded;
    //        Logging.Log("GG >> Admob:vad:Displayed");
    //        AdmobGA_Helper.GA_Log(AdmobGAEvents.VideoAdDisplayed_M_ECPM);
    //        Constants.isAdPlaying = true;
    //    });
    //}

    //public void Video_HandleOnAdClosed2(object sender, EventArgs args)
    //{


    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        if (Video_Medium_Ecpm)
    //        {
    //            this.videoAd2.Destroy();
    //            this.videoAd2 = new InterstitialAd(ADMOB_ID.ADMOB_VIDEO_AD_ID_MEDIUM_ECPM);
    //            videoLowEcpm -= LoadVideo;
    //            BindVideo2Events();
    //        }

    //        vAdStatus = AdLoadingStatus.NotLoaded;
    //        Logging.Log("GG >> Admob:vad:Closed");
    //        AdmobGA_Helper.GA_Log(AdmobGAEvents.VideoAdClosed_Medium_ECPM);
    //        Constants.isAdPlaying = false;

    //    });
    //    //OnVideoClosed();
    //    //Invoke("OnVideoClosed", 2f);
    //}
    ////******Video3 Ad Handlers**********//
    //public void Video_HandleOnAdLoaded3(object sender, EventArgs args)
    //{
    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        vAdStatus = AdLoadingStatus.Loaded;
    //        Logging.Log("GG >> Admob:vad:Loaded");
    //        AdmobGA_Helper.GA_Log(AdmobGAEvents.VideoAdLoaded_L_ECPM);
    //    });
    //}

    //public void Video_HandleOnAdFailedToLoad3(object sender, AdFailedToLoadEventArgs args)
    //{
    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        vAdStatus = AdLoadingStatus.NoInventory;
    //        Logging.Log("GG >> Admob:vad:NoInventory :: " + args.ToString());
    //        AdmobGA_Helper.GA_Log(AdmobGAEvents.VideoAdNoInventory_L_ECPM);
    //    });
    //}


    //public void Video_HandleOnAdOpened3(object sender, EventArgs args)
    //{
    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        vAdStatus = AdLoadingStatus.NotLoaded;
    //        Logging.Log("GG >> Admob:vad:Displayed");
    //        AdmobGA_Helper.GA_Log(AdmobGAEvents.VideoAdDisplayed_L_ECPM);
    //        Constants.isAdPlaying = true;
    //    });
    //}

    //public void Video_HandleOnAdClosed3(object sender, EventArgs args)
    //{

    //    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    //    {
    //        this.videoAd.Destroy();
    //        this.videoAd = new InterstitialAd(ADMOB_ID.ADMOB_VIDEO_AD_ID_LOW_ECPM);
    //        BindVideo3Events();
    //        vAdStatus = AdLoadingStatus.NotLoaded;
    //        Logging.Log("GG >> Admob:vad:Closed");
    //        AdmobGA_Helper.GA_Log(AdmobGAEvents.VideoAdClosed_Low_ECPM);
    //        Constants.isAdPlaying = false;

    //    });
    //    //OnVideoClosed();
    //    //Invoke("OnVideoClosed", 2f);
    //}
    ////public void Video_HandleOnAdLeavingApplication(object sender, EventArgs args)
    ////{
    ////    MobileAdsEventExecutor.ExecuteInUpdate(() =>
    ////    {
    ////        Logging.Log("GG >> Admob:vad:Clicked");
    ////        AdmobGA_Helper.GA_Log(AdmobGAEvents.VideoAdClicked);
    ////    });
    ////}

    //#endregion

    #region Rewarded Ad Handlers
    //***** Rewarded Events *****//
    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_High_ECPM)
            {
                RewardVideoMediumECPM -= LoadRewardedVideo;
                rAdStatus = AdLoadingStatus.Loaded;
                Logging.Log("GG >> Admob:rad:Loaded_H_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdLoaded_H_Ecpm);
                RewardVideo_High_ECPM = true;
                RewardVideo_Medium_Ecpm = false;
                RewardVideo_Low_Ecpm = false;
            }
        });
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_High_ECPM)
            {
                rAdStatus = AdLoadingStatus.NoInventory;
                Logging.Log("GG >> Admob:rad:NoInventory_H_Ecpm :: " + args.ToString());
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdNoInventory_H_ECPM);
                RewardVideo_High_ECPM = false;
                RewardVideo_Medium_Ecpm = true;
                if (RewardVideoMediumECPM != null)
                {
                    RewardVideoMediumECPM();

                }
            }
        });

    }
    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_High_ECPM)
            {

                rAdStatus = AdLoadingStatus.NotLoaded;
                Logging.Log("GG >> Admob:rad:FailedToShow");
            }
        });
    }
    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {

            if (RewardVideo_High_ECPM)
            {
                RewardVideoMediumECPM -= LoadRewardedVideo;
                rAdStatus = AdLoadingStatus.NotLoaded;
                Logging.Log("GG >> Admob:rad:Displayed_H_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdDisplayed_H_Ecpm);

            }
        });

    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_High_ECPM)
            {
                rAdStatus = AdLoadingStatus.NotLoaded;
                Logging.Log("GG >> Admob:rad:Started_H_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdStarted_H_ECPM);
            }

        });
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_High_ECPM)
            {

                RewardVideoMediumECPM -= LoadRewardedVideo;
                rAdStatus = AdLoadingStatus.NotLoaded;
                Logging.Log("GG >> Admob:rad:Closed_H_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdClosed_H_ECPM);

                this.rewardBasedVideoHighEcpm = new RewardedAd(ADMOB_ID.ADMOB_REWARDED_AD_ID_High_ECPM);
                RewardVideo_High_ECPM = true;
                RewardVideo_Medium_Ecpm = false;
                RewardVideo_Low_Ecpm = false;
                //LoadRewardedVideo();
            }

        });
        //Invoke("OnAdClosed", 2);
        //Logging.Log("GG >> On Ad Clicked");

    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_High_ECPM)
            {
                RewardVideoMediumECPM -= LoadRewardedVideo;
                Logging.Log("GG >> give reward to user after watching rAd_H_Ecpm");
                NotifyReward();
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdReward_H_ECPM);
                RewardVideo_High_ECPM = true;
                RewardVideo_Medium_Ecpm = false;
                RewardVideo_Low_Ecpm = false;
            }

        });
    }

    //***** Rewarded Events2 *****//
    public void HandleRewardBasedVideoLoaded2(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_Medium_Ecpm)
            {
                RewardVideoLowECPM -= LoadRewardedVideo;
                rAdStatus = AdLoadingStatus.Loaded;
                Logging.Log("GG >> Admob:rad:Loaded_M_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdLoaded_M_Ecpm);
                RewardVideo_High_ECPM = false;
                RewardVideo_Medium_Ecpm = true;
                RewardVideo_Low_Ecpm = false;
            }

        });
    }

    public void HandleRewardBasedVideoFailedToLoad2(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_Medium_Ecpm)
            {
                rAdStatus = AdLoadingStatus.NoInventory;
                Logging.Log("GG >> Admob:rad:NoInventory_M_Ecpm :: " + args.ToString());
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdNoInventory_M_ECPM);

                RewardVideo_Medium_Ecpm = false;
                RewardVideo_Low_Ecpm = true;
                if (RewardVideoLowECPM != null)
                    RewardVideoLowECPM();
            }
        });

    }
    public void HandleRewardedAdFailedToShow2(object sender, AdErrorEventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_Medium_Ecpm)
            {
                rAdStatus = AdLoadingStatus.NotLoaded;
                Logging.Log("GG >> Admob:rad:FailedToShow");

            }
        });
    }
    public void HandleRewardBasedVideoOpened2(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {

            if (RewardVideo_Medium_Ecpm)
            {

                RewardVideoLowECPM -= LoadRewardedVideo;
                rAdStatus = AdLoadingStatus.NotLoaded;
                Logging.Log("GG >> Admob:rad:Displayed_M_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdDisplayed_M_Ecpm);
            }
        });

    }

    public void HandleRewardBasedVideoStarted2(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_Medium_Ecpm)
            {
                rAdStatus = AdLoadingStatus.NotLoaded;
                Logging.Log("GG >> Admob:rad:Started_H_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdStarted_M_ECPM);

            }
        });
    }

    public void HandleRewardBasedVideoClosed2(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {

            if (RewardVideo_Medium_Ecpm)
            {
                RewardVideoLowECPM -= LoadRewardedVideo;
                rAdStatus = AdLoadingStatus.NotLoaded;
                Logging.Log("GG >> Admob:rad:Closed");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdClosed_M_ECPM);

                this.rewardBasedVideoMediumEcpm = new RewardedAd(ADMOB_ID.ADMOB_REWARDED_AD_ID_Medium_ECPM);
                RewardVideo_High_ECPM = true;
                RewardVideo_Medium_Ecpm = false;
                RewardVideo_Low_Ecpm = false;
                // LoadRewardedVideo();
            }
        });
        //Invoke("OnAdClosed", 2);
        //Logging.Log("GG >> On Ad Clicked");

    }

    public void HandleRewardBasedVideoRewarded2(object sender, Reward args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_Medium_Ecpm)
            {
                RewardVideoLowECPM -= LoadRewardedVideo;
                Logging.Log("GG >> give reward to user after watching rAd_M_Ecpm");
                NotifyReward();
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdReward_M_ECPM);
                RewardVideo_High_ECPM = false;
                RewardVideo_Medium_Ecpm = true;
                RewardVideo_Low_Ecpm = false;
            }
        });
    }
    //***** Rewarded Events3 *****//
    public void HandleRewardBasedVideoLoaded3(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_Low_Ecpm)
            {
                rAdStatus = AdLoadingStatus.Loaded;
                Logging.Log("GG >> Admob:rad:Loaded_L_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdLoaded_L_Ecpm);
                RewardVideo_High_ECPM = false;
                RewardVideo_Medium_Ecpm = false;
                RewardVideo_Low_Ecpm = true;
            }
        });
    }

    public void HandleRewardBasedVideoFailedToLoad3(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_Low_Ecpm)
            {

                rAdStatus = AdLoadingStatus.NoInventory;
                Logging.Log("GG >> Admob:rad:NoInventory_L_Ecpm :: " + args.ToString());
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdNoInventory_L_ECPM);
                this.rewardBasedVideoLowEcpm = new RewardedAd(ADMOB_ID.ADMOB_REWARDED_AD_ID_Low_ECPM);
                RewardVideo_High_ECPM = true;
                RewardVideo_Medium_Ecpm = false;
                RewardVideo_Low_Ecpm = false;
                //LoadRewardedVideo();
            }
        });

    }
    public void HandleRewardedAdFailedToShow3(object sender, AdErrorEventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_Low_Ecpm)
            {
                RewardVideo_High_ECPM = false;
                RewardVideo_Medium_Ecpm = false;
                RewardVideo_Low_Ecpm = true;
                rAdStatus = AdLoadingStatus.NotLoaded;
                Logging.Log("GG >> Admob:rad:FailedToShow");
            }
        });
    }
    public void HandleRewardBasedVideoOpened3(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {

            if (RewardVideo_Low_Ecpm)
            {

                rAdStatus = AdLoadingStatus.NotLoaded;
                Logging.Log("GG >> Admob:rad:Displayed_L_ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdDisplayed_L_Ecpm);
            }

        });

    }

    public void HandleRewardBasedVideoStarted3(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_Low_Ecpm)
            {
                rAdStatus = AdLoadingStatus.NotLoaded;
                Logging.Log("GG >> Admob:rad:Started_L_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdStarted_L_ECPM);

            }
        });
    }

    public void HandleRewardBasedVideoClosed3(object sender, EventArgs args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {

            if (RewardVideo_Low_Ecpm)
            {
                rAdStatus = AdLoadingStatus.NotLoaded;
                Logging.Log("GG >> Admob:rad:Closed_L_Ecpm");
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdClosed_L_ECPM);

                this.rewardBasedVideoLowEcpm = new RewardedAd(ADMOB_ID.ADMOB_REWARDED_AD_ID_Low_ECPM);
                RewardVideo_High_ECPM = true;
                RewardVideo_Medium_Ecpm = false;
                RewardVideo_Low_Ecpm = false;
                // LoadRewardedVideo();
            }
        });
        //Invoke("OnAdClosed", 2);
        //Logging.Log("GG >> On Ad Clicked");

    }

    public void HandleRewardBasedVideoRewarded3(object sender, Reward args)
    {
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardVideo_Low_Ecpm)
            {
                Logging.Log("GG >> give reward to user after watching rAd_L_Ecpm");

                NotifyReward();
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedAdReward_L_ECPM);
            }
        });
    }

    #endregion

    #region RewardedInterstitialCallbackHandler

    private void HandleAdFailedToPresent(object sender, AdErrorEventArgs args)
    {
        Logging.Log("Rewarded interstitial ad has failed to present.");
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            riAdStatus = AdLoadingStatus.NotLoaded;
            if (!isPrinted)
            {
                isPrinted = true;
                Logging.Log("GG >> Admob:riad:FailedToShow");
            }
        });
        isPrinted = false;
    }

    private void HandleAdDidPresent(object sender, EventArgs args)
    {
        bool isPrinted = false;
        Logging.Log("Rewarded interstitial ad has presented.");
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            riAdStatus = AdLoadingStatus.NotLoaded;
            rewardedInterstitialLoaded = false;
            if (!isPrinted)
            {
                isPrinted = true;
                Logging.Log("GG >> Admob:riad:Displayed");
            }
            AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialAdDisplayed);

        });
        isPrinted = false;
    }

    private void HandleAdDidDismiss(object sender, EventArgs args)
    {
        bool isPrinted = false;
        Logging.Log("Rewarded interstitial ad has dismissed presentation.");
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            riAdStatus = AdLoadingStatus.NotLoaded;
            if (!isPrinted)
            {
                isPrinted = true;
                Logging.Log("GG >> Admob:riad:Closed");
            }
            AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialAdClosed);
            MobileAdsEventExecutor.ExecuteInUpdate(() =>
            {
                Logging.Log("GG >> give reward to user after watching riAd");

                NotifyReward();
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialAdReward);
            });
            LoadRewardedInterstitial();
        });
        isPrinted = false;
    }

    private void HandlePaidEvent(object sender, AdValueEventArgs args)
    {
        MonoBehaviour.print(
            "Rewarded interstitial ad has received a paid event.");


    }
    private void RewardedInterstitialHandleAdFailedToPresentHighECPM(object sender, AdErrorEventArgs args)
    {
        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardInterstitial_High_ECPM)
            {
                riAdStatus = AdLoadingStatus.NotLoaded;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:riad:FailedToShow:HECPM");
                }
            }
        });
        isPrinted = false;
    }

    private void RewardedInterstitialHandleAdDidPresentHighECPM(object sender, EventArgs args)
    {
        bool isPrinted = false;
        Logging.Log("Rewarded interstitial ad has presented.");
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardInterstitial_High_ECPM)
            {
                RewardInterstitialMediumECPM -= LoadRewardedInterstitial;
                riAdStatus = AdLoadingStatus.NotLoaded;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:riad:Displayed_H_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialAdDisplayed_H_ECPM);

            }
        });
        isPrinted = false;
    }

    private void RewardedInterstitialHandleAdDidDismissHighECPM(object sender, EventArgs args)
    {
        bool isPrinted = false;
        Logging.Log("Rewarded interstitial ad has dismissed presentation.");
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardInterstitial_High_ECPM)
            {
                rewardedInterstitialHighECPMLoaded = false;

                RewardInterstitialMediumECPM -= LoadRewardedInterstitial;
                riAdStatus = AdLoadingStatus.NotLoaded;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:riad:Closed_H_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialAdClosed_H_ECPM);
                NotifyReward();
                RewardInterstitial_High_ECPM = true;
                RewardInterstitial_Medium_Ecpm = false;
                RewardInterstitial_Low_Ecpm = false;
                LoadRewardedInterstitial();
            }

        });
        isPrinted = false;
    }

    private void RewardedInterstitialHandlePaidEventHighECPM(object sender, AdValueEventArgs args)
    {
        MonoBehaviour.print(
            "Rewarded interstitial ad has received a paid event.");

        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardInterstitial_High_ECPM)
            {
                RewardInterstitialMediumECPM -= LoadRewardedInterstitial;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> give reward to user after watching riAd_H_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialAdReward_H_ECPM);
                RewardInterstitial_High_ECPM = true;
                RewardInterstitial_Medium_Ecpm = false;
                RewardInterstitial_Low_Ecpm = false;
            }

        });
        isPrinted = false;

    }


    ///////// Rewarded Interstitial Medium ECPM Callbacks //////////
    private void RewardedInterstitialHandleAdFailedToPresentMediumECPM(object sender, AdErrorEventArgs args)
    {
        bool isPrinted = false;
        Logging.Log("Rewarded interstitial ad has failed to present.");
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardInterstitial_Medium_Ecpm)
            {
                riAdStatus = AdLoadingStatus.NotLoaded;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:riad:FailedToShow:MECPM");
                }
            }
        });
        isPrinted = false;
    }

    private void RewardedInterstitialHandleAdDidPresentMediumECPM(object sender, EventArgs args)
    {
        bool isPrinted = false;
        Logging.Log("Rewarded interstitial ad has presented.");
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardInterstitial_Medium_Ecpm)
            {
                RewardInterstitialLowECPM -= LoadRewardedInterstitial;
                riAdStatus = AdLoadingStatus.NotLoaded;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:riad:Displayed_M_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialAdDisplayed_M_ECPM);

            }
        });
        isPrinted = false;
    }

    private void RewardedInterstitialHandleAdDidDismissMediumECPM(object sender, EventArgs args)
    {
        bool isPrinted = false;
        Logging.Log("Rewarded interstitial ad has dismissed presentation.");
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardInterstitial_Medium_Ecpm)
            {
                rewardedInterstitialMediumECPMLoaded = false;

                RewardInterstitialLowECPM -= LoadRewardedInterstitial;
                riAdStatus = AdLoadingStatus.NotLoaded;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:riad:Closed_M_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialAdClosed_M_ECPM);
                NotifyReward();
                RewardInterstitial_High_ECPM = true;
                RewardInterstitial_Medium_Ecpm = false;
                RewardInterstitial_Low_Ecpm = false;
                LoadRewardedInterstitial();
            }

        });
        isPrinted = false;
    }

    private void RewardedInterstitialHandlePaidEventMediumECPM(object sender, AdValueEventArgs args)
    {
        MonoBehaviour.print(
            "Rewarded interstitial ad has received a paid event.");

        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardInterstitial_Medium_Ecpm)
            {
                RewardInterstitialLowECPM -= LoadRewardedInterstitial;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> give reward to user after watching riAd_M_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialAdReward_M_ECPM);
                RewardInterstitial_High_ECPM = true;
                RewardInterstitial_Medium_Ecpm = false;
                RewardInterstitial_Low_Ecpm = false;
            }

        });
        isPrinted = false;
    }


    ///////// Rewarded Interstitial Low ECPM Callbacks ///////////
    private void RewardedInterstitialHandleAdFailedToPresentLowECPM(object sender, AdErrorEventArgs args)
    {
        bool isPrinted = false;
        Logging.Log("Rewarded interstitial ad has failed to present.");
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardInterstitial_Low_Ecpm)
            {
                riAdStatus = AdLoadingStatus.NotLoaded;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:riad:FailedToShow:LECPM");
                }
            }
        });
        isPrinted = false;
    }

    private void RewardedInterstitialHandleAdDidPresentLowECPM(object sender, EventArgs args)
    {
        bool isPrinted = false;
        Logging.Log("Rewarded interstitial ad has presented.");
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardInterstitial_Low_Ecpm)
            {
                riAdStatus = AdLoadingStatus.NotLoaded;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:riad:Displayed_L_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialAdDisplayed_L_ECPM);

            }
        });
        isPrinted = false;
    }

    private void RewardedInterstitialHandleAdDidDismissLowECPM(object sender, EventArgs args)
    {
        bool isPrinted = false;
        Logging.Log("Rewarded interstitial ad has dismissed presentation.");
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardInterstitial_Low_Ecpm)
            {
                rewardedInterstitialLowECPMLoaded = false;

                riAdStatus = AdLoadingStatus.NotLoaded;
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> Admob:riad:Closed_L_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialAdClosed_L_ECPM);
                NotifyReward();
                RewardInterstitial_High_ECPM = true;
                RewardInterstitial_Medium_Ecpm = false;
                RewardInterstitial_Low_Ecpm = false;
                LoadRewardedInterstitial();
            }

        });
        isPrinted = false;
    }

    private void RewardedInterstitialHandlePaidEventLowECPM(object sender, AdValueEventArgs args)
    {
        MonoBehaviour.print(
            "Rewarded interstitial ad has received a paid event.");

        bool isPrinted = false;
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (RewardInterstitial_Low_Ecpm)
            {
                if (!isPrinted)
                {
                    isPrinted = true;
                    Logging.Log("GG >> give reward to user after watching riAd_L_Ecpm");
                }
                AdmobGA_Helper.GA_Log(AdmobGAEvents.RewardedInterstitialAdReward_L_ECPM);
                RewardInterstitial_High_ECPM = true;
                RewardInterstitial_Medium_Ecpm = false;
                RewardInterstitial_Low_Ecpm = false;
            }

        });
        isPrinted = false;
    }


    #endregion

    #region AppOpenCallbackHandler
    private void HandleAdDidDismissFullScreenContent(object sender, EventArgs args)
    {
        Debug.Log("Closed app open ad");
        // Set the ad to null to indicate that AppOpenAdManager no longer has another ad to show.
        Appopenad = null;
        isShowingAd = false;
        //LoadAppOpenAd();
    }

    private void HandleAdFailedToPresentFullScreenContent(object sender, AdErrorEventArgs args)
    {
        Debug.LogFormat("Failed to present the ad (reason: {0})", args.AdError.GetMessage());
        // Set the ad to null to indicate that AppOpenAdManager no longer has another ad to show.
        Appopenad = null;
        //LoadAd();
    }

    private void HandleAdDidPresentFullScreenContent(object sender, EventArgs args)
    {
        Debug.Log("Displayed app open ad");
        isShowingAd = true;
    }

    private void HandleAdDidRecordImpression(object sender, EventArgs args)
    {
        Debug.Log("Recorded ad impression");
    }

    private void HandleAppopenPaidEvent(object sender, AdValueEventArgs args)
    {
        Debug.LogFormat("Received paid event. (currency: {0}, value: {1}",
                args.AdValue.CurrencyCode, args.AdValue.Value);
    }
    #endregion

    public bool Noads()
    {
        if (Constants.Getprefs(Constants.removeAds) == 1)
            return true;
        else
            return false;
    }
}
