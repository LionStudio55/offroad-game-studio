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
        if (mediation != null && Application.internetReachability != NetworkReachability.NotReachable && (PlayerPrefs.GetInt("RemoveAds") != 1))
    }

    private void OnDisable()
    {
        if (mediation != null)
    }

}