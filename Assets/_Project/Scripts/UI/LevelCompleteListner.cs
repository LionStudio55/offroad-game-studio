//using GameAnalyticsSDK;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Scripting;
//using GoogleMobileAds.Api;

public class LevelCompleteListner : MonoBehaviour
{
    MediationHandler mediation;
    public GameObject panel_2Buttons;
    public GameObject panel_3Buttons;
    //public GameObject doubleRewardBtn;
    public GameObject nextButton;

    public Text StuntrewardTxt;
    public Text LevelrewardTxt;
    public Text totalTxt;

    int curstuntBonus = 0;
    int curlevelBonus = 0;
    int curtotalCoins = 0;

    int stuntBonus = 0;
    int levelBonus = 0;
    int totalCoins = 0;
    //int totaldoublecoins;

    //bool showCoinsAnim = false;

    //public Button DoubleReward;
    //public Text doubleRewardCoinsTxt;

    int coinsReward = 0;
    int coinIncVal = 20;
    //bool coinIncremented = false;

    private void OnEnable()
    {
        //GarbageCollector.GCMode = GarbageCollector.Mode.Enabled;
        // System.GC.Collect();
        GameplayController.Instance.HUD_Status(false);
    }

    private void OnDisable()
    {
        GameplayController.Instance.HUD_Status(true);
        StopAllCoroutines();
        Time.timeScale = 1;
    }

    private void Start()
    {
        mediation = FindObjectOfType<MediationHandler>();

        //try
        //{
        //    if (FindObjectOfType<MediationHandler>())
        //    {
        //        FindObjectOfType<MediationHandler>().ShowMediumBanner(GoogleMobileAds.Api.AdPosition.TopLeft);
        //        FindObjectOfType<MediationHandler>().LoadInterstitial();
        //    }
        //}
        //catch (Exception e)
        //{
        //    GameAnalytics.NewErrorEvent(GAErrorSeverity.Info, "MediationHandler Instance Not Found!");
        //}

        Constants.FBAnalytic_EventLevel_Complete(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)), Constants.Getprefs(Constants.lastselectedLevel));
        UnlockNextLevel();
        HandleRewards();
        RewardPlayer();
    }


    private void HandleRewards()
    {

        stuntBonus = UnityEngine.Random.Range(300, 500); //Should be changed to proper implementation or different attribute
        levelBonus = UnityEngine.Random.Range(100, 300); /*Toolbox.DB.Prefs.GameData[Toolbox.DB.Prefs.LastSelectedGameMode].Levelstar[Toolbox.DB.Prefs.Get_LastSelectedLevelOfCurrentGameMode()]*///Should be changed to proper implementation or different attribute
        totalCoins = (stuntBonus + levelBonus);

       StuntrewardTxt.text = "";
        LevelrewardTxt.text = "";
        totalTxt.text = "";
        //Toolbox.GameManager.Log("totalcoins :"+totalCoins + "ObjectiveBonus :" + ObjectiveBonus + "HeadshotBonus :"+ HeadshotBonus);
        //Toolbox.GameManager.Log("totalCoinsTxt :" + totalCoinsTxt.text.ToString());
        //doubleRewardCoinsTxt.text = Mathf.RoundToInt(totalCoins * 2).ToString();

        coinsReward = (totalCoins);
        StartCoroutine(CR_CoinsAnimation());
    }

    IEnumerator CR_CoinsAnimation()
    {

        yield return new WaitForSeconds(2.5f);

        while (curstuntBonus <= stuntBonus && curstuntBonus <= stuntBonus - coinIncVal)
        {
            curstuntBonus += coinIncVal;
            StuntrewardTxt.text = curstuntBonus.ToString();
            SoundsManager.Instance.PlaySound(SoundsManager.Instance.CoinscollectSound);
            yield return new WaitForSeconds(0.012345f);
        }
        while (curlevelBonus <= levelBonus && curlevelBonus <= levelBonus - coinIncVal)
        {
            curlevelBonus += coinIncVal;
            LevelrewardTxt.text = curlevelBonus.ToString();
            SoundsManager.Instance.PlaySound(SoundsManager.Instance.CoinscollectSound);
            yield return new WaitForSeconds(0.01234f);
        }

        totalCoins = (curstuntBonus + curlevelBonus);

        while (curtotalCoins <= totalCoins && curtotalCoins <= totalCoins - coinIncVal)
        {
            curtotalCoins += coinIncVal;
            totalTxt.text = curtotalCoins.ToString();
            SoundsManager.Instance.PlaySound(SoundsManager.Instance.CoinscollectSound);
            yield return new WaitForSeconds(0.0123f);
        }

        //if (Toolbox.DB.Prefs.Get_LastSelectedLevelOfCurrentGameMode() <= (Toolbox.DB.Prefs.Get_LengthOfLevelsOfCurrentGameMode() - 1))
        //{
        //    print("Unlock");
        //    panel_3Buttons.SetActive(true);
        //   // print("Unlock :"+ Toolbox.DB.Prefs.Get_LastUnlockedLevelofCurrentGameMode() + "Constants.mode2UnlockAfterLevels :" + Constants.mode2UnlockAfterLevels);
        //    print("Unlock :" + Toolbox.DB.Prefs.Get_LastUnlockedLevelofCurrentGameMode() + "Constants.mode2UnlockAfterLevels :" + Constants.mode2UnlockAfterLevels);
        //    if (Toolbox.DB.Prefs.GameData[0].Modeunlocked && Toolbox.DB.Prefs.Get_LastUnlockedLevelofCurrentGameMode() >= Constants.mode2UnlockAfterLevels-1 && !Toolbox.DB.Prefs.Mode2Unlocked)
        //    {
        //        print("Unlockmode2UnlockAfterLevels");
        //        Toolbox.DB.Prefs.GameData[2].Modeunlocked = true;
        //        Toolbox.DB.Prefs.Mode2Unlocked = true;
        //        Toolbox.HUDListner.Message.GetComponent<MessageListner>().UpdateTxt(Toolbox.DB.Prefs.Get_CurGameModeName(2) + " Mode has been Unlocked.", "Congratulations");

        //    }
        //    else if (Toolbox.DB.Prefs.GameData[0].Modeunlocked && Toolbox.DB.Prefs.Get_LastUnlockedLevelofCurrentGameMode() >= Constants.mode3UnlockAfterLevels-1 && !Toolbox.DB.Prefs.Mode3Unlocked)
        //    {
        //        print("Unlockmode3UnlockAfterLevels");
        //        Toolbox.DB.Prefs.GameData[4].Modeunlocked = true;
        //        Toolbox.DB.Prefs.Mode3Unlocked = true;
        //        Toolbox.HUDListner.Message.GetComponent<MessageListner>().UpdateTxt(Toolbox.DB.Prefs.Get_CurGameModeName(4) + " Mode has been Unlocked.", "Congratulations");

        //    }
        //    else if (Toolbox.DB.Prefs.GameData[1].Modeunlocked && Toolbox.DB.Prefs.Get_LastUnlockedLevelofCurrentGameMode() >= Constants.mode4UnlockAfterLevels-1 && !Toolbox.DB.Prefs.Mode4Unlocked)
        //    {
        //        print("Unlockmode4UnlockAfterLevels");
        //        Toolbox.DB.Prefs.GameData[4].Modeunlocked = true;
        //        Toolbox.DB.Prefs.Mode4Unlocked = true;
        //        Toolbox.HUDListner.Message.GetComponent<MessageListner>().UpdateTxt(Toolbox.DB.Prefs.Get_CurGameModeName(4) + " Mode has been Unlocked.", "Congratulations");

        //    }
        //    else if (Toolbox.DB.Prefs.GameData[0].Modeunlocked && Toolbox.DB.Prefs.Get_LastUnlockedLevelofCurrentGameMode() >= Constants.mode5UnlockAfterLevels-1 && !Toolbox.DB.Prefs.Mode4Unlocked)
        //    {
        //        print("Unlockmode5UnlockAfterLevels");
        //        Toolbox.DB.Prefs.GameData[4].Modeunlocked = true;
        //        Toolbox.DB.Prefs.Mode5Unlocked = true;
        //        Toolbox.HUDListner.Message.GetComponent<MessageListner>().UpdateTxt(Toolbox.DB.Prefs.Get_CurGameModeName(4) + " Mode has been Unlocked.", "Congratulations");

        //    }
        //    else
        //    {
        //        print("ads");
        //        Ads();
        //    }
        //}
        //else
        //{
        //    if (Toolbox.DB.Prefs.LastSelectedGameMode < Toolbox.DB.Prefs.GameData.Length)
        //    {
        //        Toolbox.HUDListner.Message.SetActive(true);
        //        Toolbox.HUDListner.Message.GetComponent<MessageListner>().UpdateTxt(Toolbox.DB.Prefs.Get_CurGameModeName(Toolbox.DB.Prefs.LastSelectedGameMode) + " levels has been completed.Press on Next Button you can continue Next Mode Levels.", "Congratulations");
        //        // Toolbox.DB.Prefs.LastSelectedGameMode += 1;
        //    }
        //    panel_3Buttons.SetActive(true);
        //}
        //totaldoublecoins = curtotalCoins * 2;
        //doubleRewardCoinsTxt.text = Mathf.RoundToInt(curtotalCoins).ToString() + " x " + "2";
        //CR_ShowMegaOffer();
    }

    public void RewardPlayer()
    {

        Constants.SetPref(Constants.Totalreward,Constants.Getprefs(Constants.Totalreward)+ coinsReward);
    }

    private void UnlockNextLevel()
    {
        if (Constants.Getprefs(Constants.lastselectedLevel) < Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)))
            return;


        if (Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)) < Constants.TotallevelofMode[Constants.Getprefs(Constants.lastselectedMode)]-1 && Constants.Getprefs(Constants.lastselectedLevel) >= Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)))
        {
            Constants.SetPref(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode), (Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode))) + 1);
          //  print(" val :" + Constants.Getprefs(Constants.lastUnlockedLevel + Constants.lastselectedMode) + "_Val" + Constants.TotallevelofMode[Constants.Getprefs(Constants.lastselectedMode)]);
            panel_2Buttons.SetActive(false);
            panel_3Buttons.SetActive(true);
        }
        else
        {
            panel_2Buttons.SetActive(true);
            panel_3Buttons.SetActive(false);
        }

        // Just for Tutorial Removing 
        //if (Toolbox.DB.Prefs.Get_LastSelectedLevelOfCurrentGameMode() >= Constants.TutorialFinishLevel)
        //    Toolbox.DB.Prefs.Tutorialshowfirsttime = false;

        //if (Toolbox.DB.Prefs.Get_LastSelectedLevelOfCurrentGameMode() < (Toolbox.DB.Prefs.Get_LengthOfLevelsOfCurrentGameMode() - 1))
        //{
        //    Toolbox.DB.Prefs.Unlock_NextLevelOfCurrentGameMode();

        //    if (Toolbox.DB.Prefs.Get_LastSelectedLevelOfCurrentGameMode() > 0)
        //    {
        //        try
        //        {

        //            if ((Toolbox.DB.Prefs.Get_LastSelectedLevelOfCurrentGameMode() + 1) % 3 == 0)
        //            {
        //                int index = Toolbox.DB.Prefs.GetLockedItemIndex(1);

        //                if (index >= 0)
        //                {
        //                    Toolbox.DB.Prefs.VehiclesUnlocked[index] = true;
        //                    Toolbox.DB.Prefs.LastSelectedVehicle = index;

        //                    Toolbox.AdsManager.Hide_BAd();
        //                    StartCoroutine(CR_ShowMsgWithDelay(index));
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //        }
        //    }

        //}
        //else
        //{
        //    panel_2Buttons.SetActive(false);
        //    panel_3Buttons.SetActive(true);
        //}


    }

    public void Ads()
    {
        //try
        //{
        //    if (FindObjectOfType<AbstractAdsmanager>())
        //    {
        //        FindObjectOfType<AbstractAdsmanager>().LoadInterstitial();
        //    }
        //}
        //catch (Exception e)
        //{
        //    GameAnalytics.NewErrorEvent(GAErrorSeverity.Info, "MediationHandler Instance Not Found!");
        //}
    }

    //private void CR_ShowMegaOffer()
    //{

    //    if ((Toolbox.DB.Prefs.Get_LastSelectedLevelOfCurrentGameMode()) % 3 == 0)
    //    {
    //        Toolbox.GameManager.Permanent_Log("Modulus :" + Toolbox.DB.Prefs.Get_LastSelectedLevelOfCurrentGameMode());
    //        if (!Toolbox.DB.Prefs.MegaOfferPurchased)
    //        {
    //            //if (FindObjectOfType<AbstractAdsmanager>())
    //            //    FindObjectOfType<AbstractAdsmanager>().HideBannners();
    //            Toolbox.HUDListner.Mega_OfferPanel.SetActive(true);
    //            Toolbox.GameManager.ShowMegaOfferOnComplete = true;
    //        }
    //    }
    //    else
    //    {
    //        //if(FindObjectOfType<AbstractAdsmanager>())
    //        //    FindObjectOfType<AbstractAdsmanager>().ShowMediumBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
    //    }
    //    if (Toolbox.DB.Prefs.Get_LastSelectedLevelOfCurrentGameMode() < (Toolbox.DB.Prefs.Get_LengthOfLevelsOfCurrentGameMode() - 1))
    //    {
    //        panel_3Buttons.SetActive(true);
    //    }
    //    else
    //        panel_3Buttons.SetActive(false);
    //}
    #region ButtonListners
    public void OnPress_Home()
    {
       
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
         Constants.FBAnalytic_EventDesign(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)) + "_" + Constants.Getprefs(Constants.lastselectedLevel).ToString() + "_" + "Cmplte_HomePress");
        //Toolbox.DB.Prefs.Change_LastSelectedLevelOfCurrentGameMode(1);
        HUDListner.Instance.Loadingpanel.SetActive(true);
        GameManager.Instance.Load_Scene(Constants.scene_Menu, 2);
        this.gameObject.SetActive(false);
    }
    public void OnPress_Next()
    {
        LoadInterstitial();
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Constants.FBAnalytic_EventDesign(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)) + "_" + Constants.Getprefs(Constants.lastselectedLevel).ToString() + "_" + "LevelComplete_Next_Pressed");
        if(Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)) <= Constants.TotallevelofMode[Constants.Getprefs(Constants.lastselectedMode)] - 1)
        {
            Constants.SetPref(Constants.lastselectedLevel, Constants.Getprefs(Constants.lastselectedLevel) + 1);
        }
        //else
        //{
        //    if (Constants.Getprefs(Constants.lastselectedMode) < Constants.TotallevelofMode.Length)
        //    {
        //        Constants.SetPref(Constants.lastselectedMode, Constants.Getprefs(Constants.lastselectedMode) + 1);
        //    }
        //}

        HUDListner.Instance.Loadingpanel.SetActive(true);
        GameManager.Instance.Load_Scene(GameManager.Instance.Get_CurrentModeScenename(), 2);


        //if ((Toolbox.DB.Prefs.Get_LastSelectedLevelOfCurrentGameMode()) % 4 == 0)
        //{
        //    Toolbox.GameManager.DirectShowVehicleSelectionOnMenu = true;
        //    Toolbox.HUDListner.Loadingpanel.SetActive(true);
        //    Toolbox.GameManager.Load_MenuScene(true);
        //}
        //else
        //{
        //    Toolbox.HUDListner.Loadingpanel.SetActive(true);
        //    Toolbox.GameManager.Load_GameScene(true, Toolbox.DB.Prefs.Get_LastSelectedGameModeSceneIndex(), 3f);
        //}
        this.gameObject.SetActive(false);
    }
    public void OnPress_Restart()
    {
        LoadInterstitial();
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Constants.FBAnalytic_EventDesign(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)) + "_" + Constants.Getprefs(Constants.lastselectedLevel).ToString() + "_" + "LevelComplete_Restart_Pressed");
        //Toolbox.GameManager.Call_ad_after_restart = true;
        HUDListner.Instance.Loadingpanel.SetActive(true);
        GameManager.Instance.Load_Scene(GameManager.Instance.Get_CurrentModeScenename(), 2);
        this.gameObject.SetActive(false);
    }
    public void OnPress_2xVideoReward()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        //if (FindObjectOfType<AbstractAdsmanager>())
        //    FindObjectOfType<AbstractAdsmanager>().ShowRewardedVideo(RewardType.LEVEL_COMPLETE_2XCOINS);
       Constants.FBAnalytic_EventDesign(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)) + "_" + Constants.Getprefs(Constants.lastselectedLevel).ToString() + "_" + "video_2x_Pressed");
    }
    //public IEnumerator Double_CoinsAnimation()
    // {

    //     yield return new WaitForSeconds(1.0f);

    //     while (curtotalCoins <= totaldoublecoins && curtotalCoins <= totaldoublecoins - coinIncVal)
    //     {
    //         curtotalCoins += coinIncVal;
    //         totalCoinsTxt.text = curtotalCoins.ToString();
    //         Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.singleCoinsSound);
    //         yield return new WaitForSeconds(0.0123f);
    //     }
    //     coinsReward = totaldoublecoins;
    //     RewardPlayer();
    //     DoubleReward.interactable = false;
    //     //StopCoroutine(Double_CoinsAnimation());
    // }
    // public void Add_Double_Coins()
    // {
    //     StartCoroutine(Double_CoinsAnimation());
    // }
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
