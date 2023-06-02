//using GameAnalyticsSDK;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ReviveListner : MonoBehaviour
{
    public Image timeRing;
    public Button videoBtn;
    public Text coinsTxt;
    public Text EnoughCoinTxt;

    float ringEndSpeed = 0.2f;
    float time = 100;

    private void OnEnable()
    {
        if (GameplayController.Instance.IsRevived )
        {
            OnPress_Close();
        }
        Time.timeScale = 0.03f;
        coinsTxt.text = Constants.reviveCoinsCost.ToString();
    }

    private void OnDisable()
    {
    }

    private void Update()
    {
        time -= ringEndSpeed;

        timeRing.fillAmount = time / 100;
     //   print("time :"+time);
        if (time <= 0)
            OnPress_Close();
    }

    public void OnPress_Revive() {

    //    Time.timeScale = 1.0f;
        Constants.FBAnalytic_EventDesign("_Revived");
       
        this.gameObject.SetActive(false);
        try
        {
            //if (FindObjectOfType<AdsManager>())
            //{
            //    //if (FindObjectOfType<AbstractAdsmanager>())
            //    //    FindObjectOfType<AbstractAdsmanager>().ShowRewardedVideo(RewardType.REVIVEREWARD);
               
            //    //else
            //    //    OnPress_Close();
            //}
        }
        catch (Exception e)
        {
         //   GameAnalytics.NewErrorEvent(GAErrorSeverity.Info, "AdsManager Instance Not Found!");
        }
    }


    public void OnPress_UseCoins()
    {
        Time.timeScale = 1.0f;
        if (Constants.Getprefs(Constants.Totalreward) >= Constants.reviveCoinsCost)
        {
            Constants.FBAnalytic_EventDesign("_Revived OnPress_UseCoins");
            //Toolbox.GameManager.Analytics_DesignEvent("_Revived OnPress_UseCoins");
            //ReviveController.Revive_PlayerOnCoins();

        }
        else
        {
            EnoughCoinTxt.text = ("No enough Coins").ToString();
        }
        this.gameObject.SetActive(false);
    }

    public void OnPress_Close()
    {
        Time.timeScale = 1.0f;
        HUDListner.Instance.FailPanel.SetActive(true);    
        this.gameObject.SetActive(false);
    }
    
}
