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
            //Splash.gameObject.SetActive(false);
        }
        else
        {
           // PrivacyPolicy.SetActive(false);
            Splash.gameObject.SetActive(true);
            GameManager.Instance.Load_Scene(Constants.scene_Menu, 8f);
        }
    }

    // Update is called once per frame
  
}
