//using GameAnalyticsSDK;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitListner : MonoBehaviour
{
   // private ConsoliAdsBannerView bannerview;

    private void OnEnable()
    {

        //try
        //{
        //    if (FindObjectOfType<AbstractAdsmanager>())
        //    {
        //        FindObjectOfType<AbstractAdsmanager>().ShowInterstitial();
        //        FindObjectOfType<AbstractAdsmanager>().ShowMediumBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
        //    }
        //}

        //catch (Exception e)
        //{
        //    //GameAnalytics.NewErrorEvent(GAErrorSeverity.Info, "MediationHandler Not Found!");
        //}
    }

    private void OnDisable()
    {
        //try
        //{
        //    if (FindObjectOfType<AbstractAdsmanager>())
        //    {
        //        FindObjectOfType<AbstractAdsmanager>().LoadInterstitial();
        //        FindObjectOfType<AbstractAdsmanager>().ShowSmallBanner(GoogleMobileAds.Api.AdPosition.Top);
        //    }
        //}

        //catch (Exception e)
        //{
        //   // GameAnalytics.NewErrorEvent(GAErrorSeverity.Info, "MediationHandler Not Found!");
        //}
    }
    #region Button Listner

    public void OnPress_Yes()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        Constants.FBAnalytic_EventDesign("Quit_Press_Yes");
        this.gameObject.SetActive(false);
        Application.Quit();
    }
    public void OnPress_No()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        Constants.FBAnalytic_EventDesign("Quit_Press_No");
        this.gameObject.SetActive(false);

    }


    #endregion
}
