using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMediumRectangle : MonoBehaviour
{

     MediationHandler mediation;

    private void Awake()
    {
        mediation = FindObjectOfType<MediationHandler>();
    }

    private void OnEnable()
    {
        // Show  Banner Ads.............................
        if (mediation != null && Application.internetReachability != NetworkReachability.NotReachable && (PlayerPrefs.GetInt("RemoveAds") != 1))        {                       mediation.ShowMediumBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);        }
    }

    private void OnDisable()
    {
        if (mediation != null)        {            mediation.hideMediumBanner();        }
    }

}
