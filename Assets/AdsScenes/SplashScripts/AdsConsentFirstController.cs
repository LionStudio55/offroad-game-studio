using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdsConsentFirstController : MonoBehaviour
{
    public GameObject consenttad_tickpanel, UserSplash;
    public string PrivacyLink;
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (PlayerPrefs.GetInt("ConsentAd", 0) == 0)
        {
            consenttad_tickpanel.SetActive(true);
            UserSplash.SetActive(false);
        }
        else
        {
            consenttad_tickpanel.SetActive(false);
            UserSplash.SetActive(true);

            Invoke(nameof(WaitForMainMenu), 10f);
        }
        Time.timeScale = 1f;
    }

    public void Okbutton()
    {
        UserSplash.SetActive(true);

        consenttad_tickpanel.SetActive(false);
        PlayerPrefs.SetInt("ConsentAd", 1);
        Invoke(nameof(ShowAppOpenAd), 7f);
        Invoke(nameof(WaitForMainMenu), 10f);


    }

    void ShowAppOpenAd()
    {
        if (AdmobAdsManager.Instance)
        {
            AdmobAdsManager.Instance.ShowAppOpenAd();
        }
    }
    private void WaitForMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void PrivacyOpen()
    {
        Application.OpenURL(PrivacyLink);
    }
}
