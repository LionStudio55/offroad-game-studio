//using GameAnalyticsSDK;
//using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneToLoad;
    public Image Fillbar;
    public CanvasGroup canvasGroup;
    private float speed=30f;
    //public ConsoliAdsBannerView consoliAdsBannerView = new ConsoliAdsBannerView();


    public void Start()
    {
        //try
        //{
        //    if (FindObjectOfType<AbstractAdsmanager>())
        //        FindObjectOfType<AbstractAdsmanager>().ShowInterstitial(); by uzair
        //}
        //catch (Exception e)
        //{
        //}

       // Toolbox.GameManager.Call_ad_before_gameplay = true;
        sceneToLoad = GameManager.Instance.Get_CurrentModeScenename();
        DontDestroyOnLoad(gameObject);
        StartGame();
    }

    public void StartGame()
    {
        StartCoroutine(StartLoad());
    }

    IEnumerator StartLoad()
    {
       // loadingScreen.SetActive(true);
        yield return StartCoroutine(FadeLoadingScreen(1, 1));
       
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            Fillbar.fillAmount = Fillbar.fillAmount + 0.01f * speed *Time.deltaTime;

            if (Fillbar.fillAmount >= 1f)
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }

       
        yield return StartCoroutine(FadeLoadingScreen(0, 1));
        Destroy(this.gameObject);
    }

    IEnumerator FadeLoadingScreen(float targetValue, float duration)
    {
        float startValue = canvasGroup.alpha;
        float time = 0;

        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, targetValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = targetValue;
    }
    public void OpenLink(string url)
    {
        Application.OpenURL(url);
    }
}
