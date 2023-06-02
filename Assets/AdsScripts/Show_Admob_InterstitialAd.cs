using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Admob_InterstitialAd : MonoBehaviour
{

    MediationHandler mediation;

    private void Awake()
    {
        mediation = FindObjectOfType<MediationHandler>();
    }

    private void OnEnable()
    {
        // Show  Admob Interstitial ads.............................
        if (mediation != null && Application.internetReachability != NetworkReachability.NotReachable && (PlayerPrefs.GetInt("RemoveAds") != 1))        {            mediation.ShowInterstitial();        }
    }

    private void OnDisable()
    {

        if (mediation != null && Application.internetReachability != NetworkReachability.NotReachable && (PlayerPrefs.GetInt("RemoveAds") != 1))        {            mediation.LoadInterstitial();
        }
    }

}
