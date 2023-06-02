using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour
{
    public GameObject Splash;
    public GameObject PrivacyPolicy;
    // Start is called before the first frame update
    void Start()
    {
        if (!Constants.GetBoolpref(Constants.UserConsent))
        {
            PrivacyPolicy.SetActive(true);
            Splash.gameObject.SetActive(true);
        }
        else
        {
            PrivacyPolicy.SetActive(false);
            Splash.gameObject.SetActive(true);
            GameManager.Instance.Load_Scene(Constants.scene_Menu, 10f);
            Invoke(nameof(App_Open),9f);
        }
    }


    private void App_Open()
    {
        try
        {
            if (FindObjectOfType<MediationHandler>())
                FindObjectOfType<MediationHandler>().ShowAppOpenAd();
        }
        catch(Exception e)
        {

        }
    }
}
