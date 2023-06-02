//using GoogleMobileAds.Api;

//public delegate void AdmobRewardUserDelegate(object sender, Reward args);

public enum AdmobGAEvents
{
    Initializing,
    Initialized,

    LoadInterstitialHighAd, LoadInterstitialMediumAd, LoadInterstitialLowAd,

    LoadVideoAd_High_ECPM, LoadVideoAd_Medium_ECPM, LoadVideoAd_Low_ECPM,

    LoadRewardedAd_H_Ecpm, LoadRewardedAd_M_Ecpm, LoadRewardedAd_L_Ecpm,
    LoadRewardedInterstitialAd,
    RewardedInterstitialNoInventory_H_ECPM,
    RewardedInterstitialNoInventory_M_ECPM,
    RewardedInterstitialNoInventory_L_ECPM,
    LoadRewardedInterstitialAd_H_ECPM,
    LoadRewardedInterstitialAd_M_ECPM,
    LoadRewardedInterstitialAd_L_ECPM,
    ShowRewardedInterstitialAd_H_ECPM,
    ShowRewardedInterstitialAd_M_ECPM,
    ShowRewardedInterstitialAd_L_ECPM,
    RewardedInterstitialAdDisplayed_H_ECPM,
    RewardedInterstitialAdClosed_H_ECPM,
    RewardedInterstitialAdReward_H_ECPM,
    RewardedInterstitialAdDisplayed_M_ECPM,
    RewardedInterstitialAdClosed_M_ECPM,
    RewardedInterstitialAdReward_M_ECPM,
    RewardedInterstitialAdDisplayed_L_ECPM,
    RewardedInterstitialAdClosed_L_ECPM,
    RewardedInterstitialAdReward_L_ECPM,



    InterstitialAdLoadedHigh, InterstitialAdLoadedMedium, InterstitialAdLoadedLow,
    VideoAdLoaded_H_ECPM, VideoAdLoaded_M_ECPM, VideoAdLoaded_L_ECPM,
    RewardedAdLoaded_H_Ecpm, RewardedAdLoaded_M_Ecpm, RewardedAdLoaded_L_Ecpm,

    ShowInterstitialAdHigh, ShowInterstitialAdMedium, ShowInterstitialAdLow,
    ShowInterstitialAdHigh_Offline, ShowInterstitialAdMedium_Offline, ShowInterstitialAdLow_Offline,
    ShowVideoAd_H_ECPM, ShowVideoAd_M_ECPM, ShowVideoAd_L_ECPM,
    ShowRewardedAd_H_Ecpm, ShowRewardedAd_M_Ecpm, ShowRewardedAd_L_Ecpm,

    ShowRewardedInterstitialAd,

    InterstitialAdWillDisplayHigh, InterstitialAdWillDisplayMedium, InterstitialAdWillDisplayLow,
    VideoAdWillDisplay_H_ECPM, VideoAdWillDisplay_M_ECPM, VideoAdWillDisplay_L_ECPM,
    RewardedAdWillDisplay_H_Ecpm, RewardedAdWillDisplay_M_Ecpm, RewardedAdWillDisplay_L_Ecpm,

    RewardedInterstitialAdWillDisplay,

    InterstitialAdDisplayedHigh, InterstitialAdDisplayedMedium, InterstitialAdDisplayedLow,
    VideoAdDisplayed_H_ECPM, VideoAdDisplayed_M_ECPM, VideoAdDisplayed_L_ECPM,
    RewardedAdDisplayed_H_Ecpm, RewardedAdDisplayed_M_Ecpm, RewardedAdDisplayed_L_Ecpm,

    RewardedInterstitialAdDisplayed,

    InterstitialAdNoInventoryHigh, InterstitialAdNoInventoryMedium, InterstitialAdNoInventorylow,
    VideoAdNoInventory_H_ECPM, VideoAdNoInventory_M_ECPM, VideoAdNoInventory_L_ECPM,
    RewardedAdNoInventory_H_ECPM, RewardedAdNoInventory_M_ECPM, RewardedAdNoInventory_L_ECPM,

    RewardedAdStarted_H_ECPM, RewardedAdStarted_M_ECPM, RewardedAdStarted_L_ECPM,

    RewardedAdReward_H_ECPM, RewardedAdReward_M_ECPM, RewardedAdReward_L_ECPM,
    RewardedInterstitialAdReward,

    InterstitialAdClicked,
    VideoAdClicked,
    RewardedAdClicked,

    InterstitialAdClosed_High_ECPM, InterstitialAdClosed_Medium_ECPM, InterstitialAdClosed_Low_ECPM,
    VideoAdClosed_High_ECPM, VideoAdClosed_Medium_ECPM, VideoAdClosed_Low_ECPM,
    RewardedAdClosed_H_ECPM, RewardedAdClosed_M_ECPM, RewardedAdClosed_L_ECPM,
    RewardedInterstitialAdClosed,

    AdaptersInitialized,
    AdaptersNotInitialized,
    AdapterNotReadyNoInternet,

    RewardedAdFailedToShow,

    LoadSmallBanner_H_Ecpm, LoadSmallBanner_M_Ecpm, LoadSmallBanner_L_Ecpm,

    LoadSmallAdaptiveBanner_H_Ecpm, LoadSmallAdaptiveBanner_M_Ecpm, LoadSmallAdaptiveBanner_L_Ecpm,

    LoadSmallSmartBanner_H_Ecpm, LoadSmallSmartBanner_M_Ecpm, LoadSmallSmartBanner_L_Ecpm,

    LoadMediumBanner_H_Ecpm, LoadMediumBanner_M_Ecpm, LoadMediumBanner_L_Ecpm,

    ShowSmallBanner_H_Ecpm, ShowSmallBanner_M_Ecpm, ShowSmallBanner_L_Ecpm,

    ShowSmallAdaptiveBanner_H_Ecpm, ShowSmallAdaptiveBanner_M_Ecpm, ShowSmallAdaptiveBanner_L_Ecpm,
    ShowSmallSmartBanner_H_Ecpm, ShowSmallSmartBanner_M_Ecpm, ShowSmallSmartBanner_L_Ecpm,
    ShowMediumBanner_H_Ecpm, ShowMediumBanner_M_Ecpm, ShowMediumBanner_L_Ecpm,

    SmallBannerLoaded_H_Ecpm, SmallBannerLoaded_M_Ecpm, SmallBannerLoaded_L_Ecpm,

    SmallAdaptiveBannerLoaded_H_Ecpm, SmallAdaptiveBannerLoaded_M_Ecpm, SmallAdaptiveBannerLoaded_L_Ecpm,
    SmallSmartBannerLoaded_H_Ecpm, SmallSmartBannerLoaded_M_Ecpm, SmallSmartBannerLoaded_L_Ecpm,
    MediumBannerLoaded_H_Ecpm, MediumBannerLoaded_M_Ecpm, MediumBannerLoaded_L_Ecpm,

    SmallBannerNoInventory_H_Ecpm, SmallBannerNoInventory_M_Ecpm, SmallBannerNoInventory_L_Ecpm,

    SmallAdaptiveBannerNoInventory_H_Ecpm, SmallAdaptiveBannerNoInventory_M_Ecpm, SmallAdaptiveBannerNoInventory_L_Ecpm,
    SmallSmartBannerNoInventory_H_Ecpm, SmallSmartBannerNoInventory_M_Ecpm, SmallSmartBannerNoInventory_L_Ecpm,
    MediumBannerNoInventory_H_Ecpm, MediumBannerNoInventory_M_Ecpm, MediumBannerNoInventory_L_Ecpm,

    SmallBannerDisplayed_H_Ecpm, SmallBannerDisplayed_M_Ecpm, SmallBannerDisplayed_L_Ecpm,
    SmallAdaptiveBannerDisplayed_H_Ecpm, SmallAdaptiveBannerDisplayed_M_Ecpm, SmallAdaptiveBannerDisplayed_L_Ecpm,
    SmallSmartBannerDisplayed_H_Ecpm, SmallSmartBannerDisplayed_M_Ecpm, SmallSmartBannerDisplayed_L_Ecpm,
    MediumBannerDisplayed_H_Ecpm, MediumBannerDisplayed_M_Ecpm, MediumBannerDisplayed_L_Ecpm,

    SmallBannerClicked,
    SmallAdaptiveBannerClicked,
    SmallSmartBannerClicked,
    MediumBannerClicked,

    SmallBannerClosed_H_Ecpm, SmallBannerClosed_M_Ecpm, SmallBannerClosed_L_Ecpm,
    SmallAdaptiveBannerClosed_H_Ecpm, SmallAdaptiveBannerClosed_M_Ecpm, SmallAdaptiveBannerClosed_L_Ecpm,
    SmallSmartBannerClosed_H_Ecpm, SmallSmartBannerClosed_M_Ecpm, SmallSmartBannerClosed_L_Ecpm,
    MediumBannerClosed_H_Ecpm, MediumBannerClosed_M_Ecpm, MediumBannerClosed_L_Ecpm

    ,SmallBannerOflline,InterstialOffline,RewardOFline
}
