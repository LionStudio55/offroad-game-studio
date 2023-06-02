using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBanner : MonoBehaviour
{
    public GoogleMobileAds.Api.AdPosition Pos;
    // Start is called before the first frame update
    private void OnEnable()
    {
        try
        {
            if (FindObjectOfType<MediationHandler>())
            {
                FindObjectOfType<MediationHandler>().ShowMediumBanner(Pos);
                
            }
        }
        catch (Exception e)
        {
        }
    }

    private void OnDisable()
    {
        try
        {
            if (FindObjectOfType<MediationHandler>())
            {
                FindObjectOfType<MediationHandler>().hideMediumBanner();
            }
        }
        catch (Exception e)
        {
        }
    }
}
