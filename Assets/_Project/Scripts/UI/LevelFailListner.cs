//using GameAnalyticsSDK;
//using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFailListner : MonoBehaviour
{
    MediationHandler mediation;
    public GameObject ReviveRewardBtn;
    public Text cashearnedTxt;
   
    int curearnedBonus =0 ;
    int earnedBonus = 100;
    int coinIncVal = 5;

    private void OnEnable()
    {
        GameplayController.Instance.HUD_Status(false);
    }

    private void OnDisable()
    {
        GameplayController.Instance.HUD_Status(true);
    }

    private void Start()
    {
        mediation = FindObjectOfType<MediationHandler>();
        try
        {
            //if (FindObjectOfType<AbstractAdsmanager>())
            //{
            //    FindObjectOfType<AbstractAdsmanager>().LoadInterstitial();
            //}
        }

        catch (Exception e)
        {
        }

        SoundsManager.Instance.PlaySound(SoundsManager.Instance.levelFail);
        Constants.FBAnalytic_EventLevel_Fail(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)), Constants.Getprefs(Constants.lastselectedLevel));
        StartCoroutine(CR_CoinsAnimation());
    }
   

    IEnumerator CR_CoinsAnimation()

    { 
        yield return new WaitForSeconds(1f);
        while (curearnedBonus <= earnedBonus && curearnedBonus <= earnedBonus - coinIncVal)
        {
            curearnedBonus += coinIncVal;
            cashearnedTxt.text = curearnedBonus.ToString();
            SoundsManager.Instance.PlaySound(SoundsManager.Instance.CoinscollectSound);
            yield return new WaitForSeconds(0.012345f);
        }
        Constants.SetPref(Constants.Totalreward, Constants.Getprefs(Constants.Totalreward) + earnedBonus);
        StopCoroutine(CR_CoinsAnimation());
    }

    public void OnPress_Home()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        //Toolbox.GameManager.Back_to_mainmenu = true;
        Constants.FBAnalytic_EventDesign(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)) + "_" + Constants.Getprefs(Constants.lastselectedLevel).ToString() + "_" + "LevelFail_Home_Pressed");
       HUDListner.Instance.Loadingpanel.SetActive(true);
        GameManager.Instance.Load_Scene(Constants.scene_Menu, 2);
        this.gameObject.SetActive(false);
    }

    public void OnPress_skipLevel()
    {
        if (Constants.Getprefs(Constants.lastselectedLevel) < Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)))
            return;
        try
        {
            
        }
        catch(Exception e)
        {

        }
    }

    private void skiplevel()
    {
        if (Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)) < Constants.TotallevelofMode[Constants.Getprefs(Constants.lastselectedMode)] - 1 && Constants.Getprefs(Constants.lastselectedLevel) >= Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)))
        {
            Constants.SetPref(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode), (Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode))) + 1);
            print(" val :" + Constants.Getprefs(Constants.lastUnlockedLevel + Constants.lastselectedMode) + "_Val" + Constants.TotallevelofMode[Constants.Getprefs(Constants.lastselectedMode)]);

        }
        if (Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)) < Constants.TotallevelofMode[Constants.Getprefs(Constants.lastselectedMode)] - 1)
        {
            Constants.SetPref(Constants.lastselectedLevel, Constants.Getprefs(Constants.lastselectedLevel) + 1);
        }
        else
        {
            if (Constants.Getprefs(Constants.lastselectedMode) < Constants.TotallevelofMode.Length)
            {
                Constants.SetPref(Constants.lastselectedMode, Constants.Getprefs(Constants.lastselectedMode) + 1);
            }
        }

        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Constants.FBAnalytic_EventDesign(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)) + "_" + Constants.Getprefs(Constants.lastselectedLevel).ToString() + "_" + "LevelFail_Restart_Pressed");
        HUDListner.Instance.Loadingpanel.SetActive(true);
        GameManager.Instance.Load_Scene(GameManager.Instance.Get_CurrentModeScenename(), 2);
        this.gameObject.SetActive(false);
    }
    public void OnPress_Restart()
    {
        LoadInterstitial();
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Constants.FBAnalytic_EventDesign(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)) + "_" + Constants.Getprefs(Constants.lastselectedLevel).ToString() + "_" + "LevelFail_Restart_Pressed");
        //Toolbox.GameManager.Call_ad_after_restart = true;
        HUDListner.Instance.Loadingpanel.SetActive(true);
        GameManager.Instance.Load_Scene(GameManager.Instance.Get_CurrentModeScenename(), 2);
        this.gameObject.SetActive(false);
    }
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
