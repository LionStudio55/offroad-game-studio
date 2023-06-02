//using GameAnalyticsSDK;
//using GoogleMobileAds.Api;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PauseListner : MonoBehaviour
{
    public List<AudioSource> soundsSources;
    bool restartPressed = false;

    private void OnEnable()
    {
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

        GameplayController.Instance.HUD_Status(false);
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    #region ButtonListners

    public void OnPress_Home()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        //Toolbox.GameManager.Back_to_mainmenu = true;
        Constants.FBAnalytic_EventDesign(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode))+ "_" + Constants.Getprefs(Constants.lastselectedLevel).ToString() + "_PauseHome_Press");
        HUDListner.Instance.Loadingpanel.SetActive(true);
        GameManager.Instance.Load_Scene(Constants.scene_Menu,2);
        this.gameObject.SetActive(false);
        AudioListener.volume = 1;
    }

    public void OnPress_Restart()
    {
        restartPressed = true;
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Constants.FBAnalytic_EventDesign(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)) + "_" + Constants.Getprefs(Constants.lastselectedLevel).ToString() + "_Pause_Restart");
        HUDListner.Instance.Loadingpanel.SetActive(true);
        GameManager.Instance.Load_Scene(GameManager.Instance.Get_CurrentModeScenename(), 2);
        // Toolbox.GameManager.Call_ad_after_restart = true;
        this.gameObject.SetActive(false);
        AudioListener.volume = 1;
    }

    public void OnPress_Resume()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        GameplayController.Instance.HUD_Status(true);
        Constants.FBAnalytic_EventDesign(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)) + "_" + Constants.Getprefs(Constants.lastselectedLevel).ToString() + "_Pause_resume");
        HUDListner.Instance.ShowBanner();
        this.gameObject.SetActive(false);
        AudioListener.volume = 1;
    }

    #endregion
}
