//using Firebase.Analytics;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

 public enum Controls { Touch, steering, Gyro };
public static class Constants
{
    #region Ads related

    public static string adsRemoteConfigStatus = "1";
    public static bool isGamePaused = false;
    public static bool isAdPlaying = false;
    public static bool showInterstitial = true;
    
    #endregion

    #region Links

    public const string link_StoreInitial = "https://play.google.com/store/apps/details?id=com.jeep.drving.offroad.games";
    public const string link_MoreGames = "https://play.google.com/store/apps/developer?id=Mobile+Game+Play";
    public const string link_Facebook = "";
    public const string link_PrivacyPolicy = "https://mobilegameplayfor.blogspot.com/2023/01/mobile-game-play.html";

    #endregion

    //#region InApps

    //public const string inAppId_coins_5000 = "packone";
    //public const string inAppId_coins_15000 = "packtwo";
    //public const string inAppId_coins_20000 = "packthree";
    //public const string inAppId_coins_30000 = "packfour";
    //public const string inAppId_coins_40000 = "packfive";
    //public const string inAppId_unlockAllGuns = "unlockallguns";
    //public const string inAppId_unlockAllChaptes = "unlockallchapters";
    //public const string inAppId_unlockAllLevels = "unlockalllevels";
    //public const string inAppId_noAds = "noads";
    //public const string inAppId_megaOffer = "megaoffer";


    //public const int inAppId_CoinsReward_5000 = 5000;
    //public const int inAppId_CoinsReward_15000 = 15000;
    //public const int inAppId_CoinsReward_20000 = 20000;
    //public const int inAppId_CoinsReward_30000 = 30000;
    //public const int inAppId_CoinsReward_40000 = 40000;

    //#endregion

    #region Paths

    public const string folderPath_Prefabs = "Prefabs/";
    public const string folderPath_Prefabs_Levels_Mode = "Levels_Mode";
    public const string folderPath_Prefabs_VehicleSelection_Vehicles= "VehicleSelection/";
    public const string folderPath_Scriptables = "ScriptableObj/";
    public const string folderPath_Scriptables_Levels = "Levels_Mode";
    public const string folderPath_Scriptables_VehicleSelection_Vehicles = "Guns/";
    public const string folderPath_Prefabs_PlayerVehicles = "Vehicles/";

    #endregion

    #region Prefs Data 
    public const string UserConsent = "UserConsent";
    public const string Headshot = "Headshot";
    public const string Bodyshot = "Bodyshot";
    public const string Levelreward = "Levelreward";
    public const string Mode2Unlock = "Mode2Unlock";
    public const string Mode3Unlock = "Mode3Unlock";
    public const string Mode4Unlock = "Mode4Unlock";
    public const string Mode5Unlock = "Mode5Unlock";
    public const string Totalreward = "TotalLevelreward";
    public const string Daimond = "Daimond";
    public const string lastselectedMode = "lastselectedMode";
    public const string lastselectedEnv = "lastselectedEnv";
    public const string lastselectedLevel = "lastselectedLevel";
    public const string lastUnlockedLevel = "lastUnlockedLevel";
    public const string LastSelectedVehicle = "LastSelectedVehicle";
    public const string Totalvideoswatched = "Totalvideoswatched";
    public const string removeAds = "RemoveAds";
    public const string TyrweaponNo = "TyrweaponNo";
    public const string DailyRewardDay = "DailyRewardDay";
    public const string NextDailyRewardTime = "NextDailyRewardTime";
    public const string DailyRewardTime = "DailyRewardTime";
    public const string Dailyrewardclaimed = "Dailyrewardclaimed";
    public const string AppRated = "AppRated";


    public static void SetPref(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public static int Getprefs(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
    public static void SetPrefstring(string KeyName, string _val)
    {
        PlayerPrefs.SetString(KeyName, _val);
    }

    public static string Getprefstring(string KeyName)
    {
        return PlayerPrefs.GetString(KeyName);
    }
    public static bool SetBoolpref(String name, bool value)
    {
        try
        {
            PlayerPrefs.SetInt(name, value ? 1 : 0);
        }
        catch
        {
            return false;
        }
        return true;
    }

    public static bool GetBoolpref(String name)
    {
        return PlayerPrefs.GetInt(name) == 1;
    }
    public static void DeletePref(string pref)
    {
        PlayerPrefs.DeleteKey(pref);
    }
    #endregion

    #region GamePlay
    public static Controls SelectedControltype;
    public static bool TryWeapon = false;
    public static bool WeaponTrialFinished = false;
    public static bool DirectModeselectionshow = false;
    public static int reviveCoinsCost = 100;
    public static bool AreAllGunsUnlocked()
    {
        Guns = PlayerPrefsX.GetBoolArray("GunsUnlocked");
        for (int i = 0; i < Guns.Length; i++)
        {
            if (!Guns[i])
            {

                //Debug.LogError("All vehicles --NOT-- unlocked");
                return false;
            }

        }
        //Debug.LogError("All vehicles are unlocked");
        return true;
    }
    #endregion

    #region Names

    public const string gameModeName_Mode1 = "Career_Mode";
    public const string gameModeName_Mode2 = "Challenge_Mode";
    public const string gameModeName_Mode3 = "Free_Hunt";
    public const string gameModeName_Mode4 = "Adventure";
    public const string gameModeName_Mode5 = "Survival";
    public const string gameModeName_Mode6 = "Pro_Hunter";
    public const string gameModeName_Mode7 = "Flying_Bird_hunt";
    public const string gameModeName_Mode8 = "Wild_Shooting";
    public const string gameModeName_Mode9 = "Survival_Mode";
    public const string scene_Menu = "MainMenu";
    public const string scene_weaponselection = "weapon_selection";
    public const string scenename_Mode1 = "GamePlay";
    public const string scenename_Mode2 = "ChallengeMode";
    public const string scenename_Mode3 = "GamePlay";
    public const string scenename_Mode4 = "GamePlay";
    public const string scenename_Mode5 = "GamePlay";
    public const string scenename_Mode6 = "GamePlay";



    #endregion

    #region Firebase-Analytics

    public static void FBAnalytic_EventLevel_Started(string Mode, int level)
    {
        Mode = Mode.Replace(" ", "_");

        try
        {
            //  FirebaseAnalytics.LogEvent("lvl_start_" + Mode + "_Lvl" + level);
            Debug.Log("Level_started_" + "Mode_" + Mode + "_" + "Lvl_" + level);
        }
        catch (Exception e)
        {
            Debug.Log("Error in Analytics:" + e.ToString());
        }
    }
    public static void FBAnalytic_EventLevel_pause(string Mode, int level)
    {
        Mode = Mode.Replace(" ", "_");

        try
        {
            //  FirebaseAnalytics.LogEvent("lvl_pause_" + Mode + "_Lvl" + level);
            Debug.Log("Level_pause_" + "Mode_" + Mode + "_" + "Lvl_" + level);
        }
        catch (Exception e)
        {
            Debug.Log("Error in Analytics:" + e.ToString());
        }
    }
    public static void FBAnalytic_EventLevel_Complete(string Mode, int level)
    {
        Mode = Mode.Replace(" ", "_");
        //lvl_complete_Survival_Lvl0
        try
        {
            //   FirebaseAnalytics.LogEvent("lvl_complete_" + Mode + "_Lvl" + level);
            Debug.Log("Lvl_complete_" + "Mode_" + Mode + "_" + "Level_" + level);
        }
        catch (Exception e)
        {
            Debug.Log("Error in Analytics: " + e.ToString());
        }
    }

    public static void FBAnalytic_EventLevel_Fail(string Mode, int level)
    {
        Mode = Mode.Replace(" ", "_");
        try
        {
            //  FirebaseAnalytics.LogEvent("lvl_fail_" + Mode + "_Lvl" + level);
            Debug.Log("Lvl_Fail_" + "Mode_" + Mode + "_" + "Level_" + level);
        }
        catch (Exception e)
        {
            Debug.Log("Error in Analytics: " + e.ToString());
        }
    }

    public static void FBAnalytic_EventDesign(string eventName)
    {
        eventName = eventName.Replace(" ", "_");
        try
        {
            //   FirebaseAnalytics.LogEvent(eventName);
            Debug.Log(eventName);
        }
        catch (Exception e)
        {
            Debug.Log("Error in Analytics: " + e.ToString());
        }
    }

    public static void NotificationsOpen(string eventname)
    {
        try
        {
            //    FirebaseAnalytics.LogEvent("Open_" + eventname);
            Debug.Log("AnalyticsNotification: " + eventname);
        }
        catch (Exception e)
        {
            Debug.Log("Analytics_Design: Error in Analytics: " + e.ToString());
        }
    }
    #endregion

    #region DailyReward
    public static readonly int[] dailyReward = {
        1000,
        120,
        200,
        260,
        400,
        550,
        750
    };
    public static readonly int[] dailyRewardDynamic = {
        1,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10,
        11
    };
    public static int Firstdynamicreward = 1;
    public static int Seconndynamicreward = 6;
    public static int Thirddynamicreward = 3;
    #endregion

    #region Rewards of Watch-Videos
    public static void Freecoins_Onwatchvieo()
    {
        // Toolbox.UIManager.UpdateTxts();
    }

    public static string GetCurGameModeName(int index)
    {
        if (index == 0)
            return gameModeName_Mode1;
        if (index == 1)
            return gameModeName_Mode2;
        if (index == 2)
            return gameModeName_Mode3;
        if (index == 3)
            return gameModeName_Mode4;
        if (index == 4)
            return gameModeName_Mode5;
        if (index == 5)
            return gameModeName_Mode6;
        if (index == 6)
            return gameModeName_Mode7;
        if (index == 7)
            return gameModeName_Mode8;
        if (index == 8)
            return gameModeName_Mode9;
        else
            return gameModeName_Mode1;
    }
    #endregion

    #region Inapp reward Function 

    public static bool[] Modes = { true, true, true, true, true };
    public static bool[] Guns = { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
    public static int[] TotallevelofMode = { 10, 10, 10, 10, 10, 10 };
    public static void Set_unlockAllModes()
    {
        PlayerPrefsX.SetBoolArray("ModesUnlocked", Modes);
    }
    public static void RemoveAds()
    {
        SetPref(removeAds, 1);
    }

    public static void unlocklevels()
    {
        for (int i = 0; i < Modes.Length; i++)
        {
            Constants.SetPref(Constants.lastUnlockedLevel + i, TotallevelofMode[i] - 1);
        }
    }
    public static void unlockguns()
    {
        PlayerPrefsX.SetBoolArray("GunsUnlocked", Guns);
    }
    public static void UnLocKEveryThing()
    {
        RemoveAds();
        Set_unlockAllModes();
        unlocklevels();
        unlockguns();
    }
    public static void SpecificGun(int id)
    {
        Guns = PlayerPrefsX.GetBoolArray("GunsUnlocked");
        Guns[id] = true;
        PlayerPrefsX.SetBoolArray("GunsUnlocked", Guns);
    }
    #endregion

    #region debugLogs
    public static void Logs(string str)
    {
        Debug.Log(str);
    }
    public static void Permanent_Logs(string str)
    {
        Debug.Log(str);
    }
    #endregion

    //#region Scenemanagement
    //public static void Load_MenuScene(string scenename, float _delay)
    //{
    //    //star(CR_LoadScene(scenename, _delay));
    //}
    //public static IEnumerator CR_LoadScene(string _sceneIndex, float duration)
    //{

    //    Permanent_Logs("Loading Scene");
    //    yield return new WaitForSeconds(duration);
    //    SceneManager.LoadScene(_sceneIndex);
    //}
    //#endregion
}




