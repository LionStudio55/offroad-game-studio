using System;
using UnityEngine;

public class ShowBanner : MonoBehaviour
{
    public enum Pos { Center, right, left };
    public Pos bannnerposition;
    public bool Hidemediumbanner = false;
    // Start is called before the first frame update
    private void OnEnable()
    {
        try
        {
            if (FindObjectOfType<MediationHandler>())
            {
                if (bannnerposition == Pos.Center)
                {
                    FindObjectOfType<MediationHandler>().ShowSmallBanner(GoogleMobileAds.Api.AdPosition.Top);
                }

                else if (bannnerposition == Pos.left)
                {
                    // if (FindObjectOfType<MediationHandler>().IsSmallBannerReady())
                    FindObjectOfType<MediationHandler>().ShowSmallBanner(GoogleMobileAds.Api.AdPosition.TopLeft);
                }
                else
                {
                    //if (FindObjectOfType<MediationHandler>().IsSmallBannerReady())
                    FindObjectOfType<MediationHandler>().ShowSmallBanner(GoogleMobileAds.Api.AdPosition.TopRight);
                }
                if (Hidemediumbanner)
                    FindObjectOfType<MediationHandler>().hideMediumBanner();
            }
        }
        catch (Exception e)
        {
        }
    }

    private void OnDisable()
    {
        //try
        //{
        //    if (FindObjectOfType<MediationHandler>())
        //    {
        //        FindObjectOfType<MediationHandler>().hideSmallBanner();
        //    }
        //}
        //catch (Exception e)
        //{
        //}
    }
}
