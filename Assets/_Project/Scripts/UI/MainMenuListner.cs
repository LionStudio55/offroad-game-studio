using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
//using GameAnalyticsSDK;

public class MainMenuListner : MonoBehaviour
{
    MediationHandler mediation;
    public Text coinsTxt;
    public Text daimondTxt;

    //public RectTransform bannerAd;
    //public RectTransform IconAd;
    public GameObject noAdsButton;
    //public GameObject TutorialArrow;
    //public List<GameObject> Tutotialobj;
    
    private void Awake()
    {
      //  ShowBannner();
    }
    public void OnEnable()
    {
        Time.timeScale = 1;

        //if (DateTime.Now >= Toolbox.DB.Prefs.NextDailyRewardTime)
        //{
        //    Toolbox.UIManager.DailyReward.SetActive(true);
        //    Toolbox.DB.Prefs.Dailyrewardclaimed = false;
        //}
        //else
        //{
        //    Invoke("MegaOffer", 1.0f);
        //}
        // Invoke("MegaOffer", 1.0f);
        //set_StatusTutorial();


       // NoAdsButtonHandling();
        UpdateTxts();
    }

   

    private void Start()
    {
        mediation = FindObjectOfType<MediationHandler>();
        //if (Toolbox.GameManager.Back_to_mainmenu)
        //{

        //    try
        //    {
        //        if (FindObjectOfType<AbstractAdsmanager>())
        //            FindObjectOfType<AbstractAdsmanager>().ShowInterstitial();
        //           Toolbox.GameManager.Back_to_mainmenu = false;
        //    }
        //    catch (Exception e)
        //    {
        //        GameAnalytics.NewErrorEvent(GAErrorSeverity.Info, "MediationHandler Instance Not Found!");
        //       //  Toolbox.GameManager.Back_to_mainmenu = false;
        //    }
        //}

    }

    //private void set_StatusTutorial()
    //{
    //    if (Toolbox.DB.Prefs.Tutorialshowfirsttime)
    //    {
    //        foreach (GameObject g in Tutotialobj)
    //            g.GetComponent<Button>().interactable = false;
    //        TutorialArrow.SetActive(true);
    //    }
    //    else
    //    {
    //        foreach (GameObject g in Tutotialobj)
    //            g.GetComponent<Button>().interactable = true;
    //        TutorialArrow.SetActive(false);
    //    }
    //}
    //private void MegaOffer()
    //{
    //    if (!Toolbox.GameManager.FirstShowMegaOffer && !Toolbox.DB.Prefs.MegaOfferPurchased)
    //    {
    //        //Toolbox.GameManager.Instantiate_MegaOffer();
    //        Toolbox.UIManager.MegaOffers.SetActive(true);
    //        Toolbox.GameManager.FirstShowMegaOffer = true;
    //    }
    //}

    public void NoAdsButtonHandling()
    {
        //if (Toolbox.DB.Prefs.NoAdsPurchased)
        //    noAdsButton.GetComponent<Button>().interactable = false;
    }
    public void ShowBannner()
    {
        //if (AdsManager.Instance)
        //    AdsManager.Instance.ShowSmallBanner(GoogleMobileAds.Api.AdPosition.Top);
        //if (FindObjectOfType<AbstractAdsmanager>())
        //    FindObjectOfType<AbstractAdsmanager>().ShowSmallBanner(GoogleMobileAds.Api.AdPosition.Top);
    }

     public void UpdateTxts()
    {
        coinsTxt.text = Constants.Getprefs(Constants.Totalreward).ToString();
        daimondTxt.text = Constants.Getprefs(Constants.Daimond).ToString();
    }



    #region ButtonListners

    public void OnPress_Next()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Constants.FBAnalytic_EventDesign("MainMenu_Press_Next");
        UIManager.INSTANCE.UIDummy_Loading.SetActive(true);
        LoadInterstitial();
        //UIManager.Instance.ShowNextUI();
        //try
        //{
        //    if (FindObjectOfType<AbstractAdsmanager>())
        //        FindObjectOfType<AbstractAdsmanager>().ShowInterstitial();
        //}
        //catch (Exception e)
        //{
        //    GameAnalytics.NewErrorEvent(GAErrorSeverity.Info, "MediationHandler Instance Not Found!");
        //    //  Toolbox.GameManager.Back_to_mainmenu = false;
        //}
        ///Toolbox.GameManager.loading_Delay(3f);
        Invoke(nameof(Next), 7f);
    }

    private void Next()
    {
        UIManager.Instance.ShowNextUI();
        UIManager.INSTANCE.UIDummy_Loading.SetActive(false);
        SHOWInterstitialIAD();
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        CancelInvoke(nameof(Next));
    }

    public void OnPress_Settings()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks); 
        Constants.FBAnalytic_EventDesign("MainMenu_Press_Settings");
        //Toolbox.UIManager.Settings_Panel.SetActive(true);
        UIManager.Instance.Settings_Panel.SetActive(true);
    }

    public void OnPress_RateUs()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Constants.FBAnalytic_EventDesign("MainMenu_Press_RateUs");
        Application.OpenURL(Constants.link_StoreInitial+Application.identifier);
    }

    public void OnPress_MoreGames()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Constants.FBAnalytic_EventDesign("MainMenu_Press_MoreGames");
        Application.OpenURL(Constants.link_MoreGames);
    }

    public void OnPress_PrivacyPolicy()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Application.OpenURL(Constants.link_PrivacyPolicy);
    }

    public void OnPress_Quit()
    {

        UIManager.Instance.Quit_Panel.SetActive(true);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);

    }
    public void OnPress_WatchVideo()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        //if (FindObjectOfType<AbstractAdsmanager>())
        //    FindObjectOfType<AbstractAdsmanager>().ShowRewardedVideo(RewardType.FREEREWARD);

    }

    public void OnPress_FB()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Constants.FBAnalytic_EventDesign("MainMenu_Press_FB");
        Application.OpenURL(Constants.link_Facebook);
    }

    public void OnPress_AdsScene()
    {

       // Toolbox.GameManager.LoadLevel(4, false);
    }
    public void OnPress_RemoveAds()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Constants.FBAnalytic_EventDesign("MainMenu_Press_RemoveAds");
        InAppHandler.Instance.Buy_NoAds();
    }

    public void OnPress_Store()
    {

        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Constants.FBAnalytic_EventDesign("MainMenu_Press_Store");
        UIManager.Instance.Shop_Panel.SetActive(true);
    }
    public void On_Press_Shop()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Constants.FBAnalytic_EventDesign("MainMenu_Press_Shop");
        UIManager.Instance.DirectShowShop();
        //Toolbox.GameManager.GodirectshopfromMenu = true;
    }
    public void On_Press_Dailrewards()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Constants.FBAnalytic_EventDesign("On_Press_Dailrewards");
       // UIManager.Instance.DailyReward.SetActive(true);

    }
    #endregion
    public void SHOWInterstitialIAD()
    {
        if (mediation != null && (PlayerPrefs.GetInt("RemoveAds") != 1))
        {
            mediation.ShowInterstitial();
        }
    }
    public void LoadInterstitial()
    {
        if (mediation != null && (PlayerPrefs.GetInt("RemoveAds") != 1))
        {
            mediation.LoadInterstitial();
        }
    }
}
