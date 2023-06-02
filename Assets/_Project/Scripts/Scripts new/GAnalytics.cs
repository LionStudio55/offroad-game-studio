using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
//using GameAnalyticsSDK;
public class GAnalytics : MonoBehaviour
{
    // Start is called before the first frame update

    public static GAnalytics Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeGameAnalytics()
    {
        //GameAnalytics.Initialize();
    }

    #region Analytics

    public void LogResourceEvent(bool isAdd, float Ammount, string ItemType)
    {
        //if (isAdd)
        //{
        //    GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "Coins", Ammount, ItemType, "");
        //}
        //else
        //{
        //    GameAnalytics.NewResourceEvent(GAResourceFlowType.Sink, "Coins", Ammount, ItemType, "");
        //}
    }

    public void LogEvent(string Message)
    {

        //GameAnalytics.NewDesignEvent(Message);
        Firebase.Analytics.FirebaseAnalytics.LogEvent(Message);

    }

    public void OpenGarageEventLog()
    {

        //GameAnalytics.NewDesignEvent("OpenGarage");
        Firebase.Analytics.FirebaseAnalytics.LogEvent("OpenGarage");
    }

    public void OpenShopEventLog()
    {

        //GameAnalytics.NewDesignEvent("OpenShop");
        Firebase.Analytics.FirebaseAnalytics.LogEvent("OpenShop");

    }

    public void MissionOrLevelStartedEventLog(int LevelNumber, string GameMode)
    {

        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "GameMode_" + GameMode, "LevelNumber_" + LevelNumber);
        Firebase.Analytics.FirebaseAnalytics.LogEvent("LevelStarted_GameMode_" + GameMode + LevelNumber.ToString());
    }

    public void MissionOrLevelCompletedEventLog(string GameMode, int LevelNumber, int LevelScore, bool IsMissionSuccessful)
    {

        //GameAnalytics.NewProgressionEvent((IsMissionSuccessful ? GAProgressionStatus.Complete : GAProgressionStatus.Fail), "GameMode_" + GameMode,
        //    "LevelNumber_" + LevelNumber, LevelScore);

        Firebase.Analytics.FirebaseAnalytics.LogEvent("LC_" + GameMode + LevelNumber.ToString() +
        "_MS_" + (IsMissionSuccessful ? "_Successfull" : "_Failed"));
    }

    public void ItemPurchaseEventLog(string ItemName, int ItemPrice)
    {

        //GameAnalytics.NewResourceEvent(GAResourceFlowType.Sink, "Coins", ItemPrice, ItemName, "");
        Firebase.Analytics.FirebaseAnalytics.LogEvent("ItemPurchased_Name" + ItemName);
    }

    public void PauseEventLog()
    {

        //GameAnalytics.NewDesignEvent("GamePaused");
        Firebase.Analytics.FirebaseAnalytics.LogEvent("GamePaused");

    }

    public void BackToMenuFromPauseEventLog()
    {

        //GameAnalytics.NewDesignEvent("BackToMenuFromPause");
        //{
        //    Firebase.Analytics.FirebaseAnalytics.LogEvent("BackToMenuFromPause");
       // }
    }

    public void BackToMenuFromMissionResultEventLog()
    {

        //GameAnalytics.NewDesignEvent("BackToMenuFromMission");
        Firebase.Analytics.FirebaseAnalytics.LogEvent("BackToMenuFromMission");
    }

    public void NextFromMissionResultEventLog()
    {

        //GameAnalytics.NewDesignEvent("NextMissionFromGameOver");
        Firebase.Analytics.FirebaseAnalytics.LogEvent("NextMissionFromGameOver");

    }
    #endregion
}
