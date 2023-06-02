
using System;
using UnityEngine;


[System.Serializable]
public class Prefs_Data
{


    [SerializeField] private bool gameAudio = true;
    [SerializeField] private bool gameSound = true;

    [SerializeField] private float soundVolume = 1.0f;
    [SerializeField] private float musicVolume = 0.4f;

    [SerializeField] private int goldCoins = 0;
    [SerializeField] private int highScore = 0;
    [SerializeField] private int RetryLifes = 5;
    [SerializeField] private string playerName;
    [SerializeField] private bool fbLoggedIn = false;

    [SerializeField] private bool soundMute = false;

    [SerializeField] private bool firstRun = true;
    [SerializeField] private bool tutorialShowed = false;
    [SerializeField] private bool appRated = false;
    [SerializeField] private bool userConsent = false;

    [SerializeField] private int lastLevelStartAnimation = 0;

    [SerializeField] private int lastSelectedGameMode = 0;
    [SerializeField] private int lastSelectedGameModeCar = 0;

    [SerializeField] private int lastSelectedLevel_Mode1 = 0;
    [SerializeField] private int lastSelectedLevel_Mode2 = 0;
    [SerializeField] private int lastSelectedLevel_Mode3 = 0;
    [SerializeField] private int lastSelectedLevel_Mode4 = 0;
    [SerializeField] private int lastSelectedLevel_Mode5 = 0;
    [SerializeField] private int lastSelectedLevel_Mode6 = 0;


    [SerializeField] private int TotalorginalLevelsMode1;
    [SerializeField] private bool[] levelsUnlocked_Mode1;
    [SerializeField] private int[] levelsStars_Mode1;

    [SerializeField] private int TotalorginalLevelsMode2;
    [SerializeField] private bool[] levelsUnlocked_Mode2;
    [SerializeField] private int[] levelsStars_Mode2;

    [SerializeField] private int TotalorginalLevelsMode3;
    [SerializeField] private bool[] levelsUnlocked_Mode3;
    [SerializeField] private int[] levelsStars_Mode3;

    [SerializeField] private int TotalorginalLevelsMode4;
    [SerializeField] private bool[] levelsUnlocked_Mode4;
    [SerializeField] private int[] levelsStars_Mode4;

    [SerializeField] private int TotalorginalLevelsMode5;
    [SerializeField] private bool[] levelsUnlocked_Mode5;
    [SerializeField] private int[] levelsStars_Mode5;

    [SerializeField] private int TotalorginalLevelsMode6;
    [SerializeField] private bool[] levelsUnlocked_Mode6;
    [SerializeField] private int[] levelsStars_Mode6;


    [SerializeField] private bool mode2Unlocked = false;
    [SerializeField] private bool mode3Unlocked = false;
    [SerializeField] private bool mode4Unlocked = false;
    [SerializeField] private bool MuiltplayerMode2 = false;
    [SerializeField] private bool MuiltPlayerMode1 = false;

    [SerializeField] private bool noAdsPurchased = false;
    [SerializeField] private bool megaOfferPurchased = false;

    [SerializeField] private int lastSelectedVehicle = 0;
    [SerializeField] private bool[] vehiclesUnlocked;


    [SerializeField] private int lastSelectedVehicleFormuala = 0;
    [SerializeField] private bool[] vehiclesUnlockedFormuala;



    [SerializeField] private int lastSelectedVehiclemoster = 0;
    [SerializeField] private bool[] vehiclesUnlockedmoster;

    [SerializeField] private int lastSelectedVehiclesupercar = 0;
    [SerializeField] private bool[] vehiclesUnlockedSupercar;

    [SerializeField] private int lastSelectedVehicleCityCars = 0;
    [SerializeField] private bool[] vehiclesUnlockedCityCars;

    [SerializeField] private int lastSelectedVehicleCityBuses = 0;
    [SerializeField] private bool[] vehiclesUnlockedCitybuses;

    [SerializeField] private int lastSelectedVehicleCityTrucks = 0;
    [SerializeField] private bool[] vehiclesUnlockedCityTrucks;

    [SerializeField] private int dailyRewardDay = 0;
    [SerializeField] private DateTime nextDailyRewardTime;
    [SerializeField] private DateTime classicMode_unlockDateTime = DateTime.Now.AddDays(1);
    //[SerializeField] private bool tutorialshowfirsttime = false;
    private int dynamicDailyRewardItemNumber1 = -1;

    [SerializeField] private int scheduledNotificationId = -1;

    [SerializeField] private int HeroNumber;
    [SerializeField] private int Levels;
    [SerializeField] private int CheckPoint;
    [SerializeField] private int AnimalHero;
    [SerializeField] private int AnimslModeLevel;
    [SerializeField] private bool PurchasingInapp;
    [SerializeField] private bool FetchDataComplete;

    [SerializeField] private bool LoadAd;
    [SerializeField] private bool FireBaseInit;
    [SerializeField] private bool FireBaseRemote;
    //public int Get_LastUnlockedLevelofCurrentGameMode()
    //{

    //    if (lastSelectedGameMode == Constants.gameModeIndex_Mode1)
    //    {

    //        for (int i = 0; i < levelsUnlocked_Mode1.Length; i++)
    //        {
    //            if (!levelsUnlocked_Mode1[i])
    //            {
    //                return i - 1;
    //            }
    //        }
    //        return levelsUnlocked_Mode1.Length - 1;

    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode2)
    //    {
    //        for (int i = 0; i < levelsUnlocked_Mode2.Length; i++)
    //        {
    //            if (!levelsUnlocked_Mode2[i])
    //            {
    //                return i - 1;
    //            }
    //        }
    //        return levelsUnlocked_Mode2.Length - 1;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode3)
    //    {
    //        for (int i = 0; i < levelsUnlocked_Mode3.Length; i++)
    //        {
    //            if (!levelsUnlocked_Mode3[i])
    //            {
    //                return i - 1;
    //            }
    //        }
    //        return levelsUnlocked_Mode3.Length - 1;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode4)
    //    {
    //        for (int i = 0; i < levelsUnlocked_Mode4.Length; i++)
    //        {
    //            if (!levelsUnlocked_Mode4[i])
    //            {
    //                return i - 1;
    //            }
    //        }
    //        return levelsUnlocked_Mode5.Length - 1;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode5)
    //    {
    //        for (int i = 0; i < levelsUnlocked_Mode5.Length; i++)
    //        {
    //            if (!levelsUnlocked_Mode5[i])
    //            {
    //                return i - 1;
    //            }
    //        }
    //        return levelsUnlocked_Mode5.Length - 1;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode6)
    //    {
    //        for (int i = 0; i < levelsUnlocked_Mode6.Length; i++)
    //        {
    //            if (!levelsUnlocked_Mode6[i])
    //            {
    //                return i - 1;
    //            }
    //        }
    //        return levelsUnlocked_Mode6.Length - 1;
    //    }

    //    return levelsUnlocked_Mode1.Length - 1;
    //}

    public int Get_LastUnlockedLevelOfGameMode(int _mode)
    {
        if (_mode == 0)
        {

            for (int i = 0; i < levelsUnlocked_Mode1.Length; i++)
            {
                if (!levelsUnlocked_Mode1[i])
                {
                    return i - 1;
                }
            }
            return levelsUnlocked_Mode1.Length - 1;

        }
        else if (_mode == 1)
        {

            for (int i = 0; i < levelsUnlocked_Mode2.Length; i++)
            {
                if (!levelsUnlocked_Mode2[i])
                {
                    return i - 1;
                }
            }
            return levelsUnlocked_Mode2.Length - 1;

        }
        else if (_mode == 2)
        {

            for (int i = 0; i < levelsUnlocked_Mode3.Length; i++)
            {
                if (!levelsUnlocked_Mode3[i])
                {
                    return i - 1;
                }
            }
            return levelsUnlocked_Mode3.Length - 1;

        }
        else if (_mode == 3)
        {

            for (int i = 0; i < levelsUnlocked_Mode4.Length; i++)
            {
                if (!levelsUnlocked_Mode4[i])
                {
                    return i - 1;
                }
            }
            return levelsUnlocked_Mode4.Length - 1;

        }
        else if (_mode == 4)
        {

            for (int i = 0; i < levelsUnlocked_Mode5.Length; i++)
            {
                if (!levelsUnlocked_Mode5[i])
                {
                    return i - 1;
                }
            }
            return levelsUnlocked_Mode5.Length - 1;

        }
        else if (_mode == 5)
        {

            for (int i = 0; i < levelsUnlocked_Mode6.Length; i++)
            {
                if (!levelsUnlocked_Mode6[i])
                {
                    return i - 1;
                }
            }
            return levelsUnlocked_Mode6.Length - 1;

        }

        return 1;

    }

    //public int Get_LastSelectedLevelOfCurrentGameMode()
    //{

    //    if (lastSelectedGameMode == Constants.gameModeIndex_Mode1)
    //    {

    //        return lastSelectedLevel_Mode1;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode2)
    //    {
    //        return lastSelectedLevel_Mode2;
    //    }

    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode3)
    //    {
    //        return lastSelectedLevel_Mode3;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode4)
    //    {
    //        return lastSelectedLevel_Mode4;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode5)
    //    {
    //        return lastSelectedLevel_Mode5;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode6)
    //    {
    //        return lastSelectedLevel_Mode6;
    //    }
    //    return 0;
    //}

    //public void Set_LastSelectedLevelOfCurrentGameMode(int _level)
    //{
    //    if (lastSelectedGameMode == Constants.gameModeIndex_Mode1)
    //    {
    //        lastSelectedLevel_Mode1 = _level;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode2)
    //    {
    //        lastSelectedLevel_Mode2 = _level;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode3)
    //    {
    //        lastSelectedLevel_Mode3 = _level;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode4)
    //    {
    //        lastSelectedLevel_Mode4 = _level;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode5)
    //    {
    //        lastSelectedLevel_Mode5 = _level;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode6)
    //    {
    //        lastSelectedLevel_Mode6 = _level;
    //    }
    //}

    //public int Get_LengthOfLevelsOfCurrentGameMode()
    //{
    //    if (lastSelectedGameMode == Constants.gameModeIndex_Mode1)
    //    {
    //        return LevelsUnlocked_Mode1.Length;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode2)
    //    {
    //        return LevelsUnlocked_Mode2.Length;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode3)
    //    {
    //        return LevelsUnlocked_Mode3.Length;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode4)
    //    {
    //        return LevelsUnlocked_Mode4.Length;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode5)
    //    {
    //        return LevelsUnlocked_Mode5.Length;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode6)
    //    {
    //        return LevelsUnlocked_Mode6.Length;
    //    }
    //    return 0;
    //}

    //public void Change_LastSelectedLevelOfCurrentGameMode(int _val)
    //{
    //    if (lastSelectedGameMode == Constants.gameModeIndex_Mode1)
    //    {
    //        lastSelectedLevel_Mode1 += _val;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode2)
    //    {
    //        lastSelectedLevel_Mode2 += _val;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode3)
    //    {
    //        lastSelectedLevel_Mode3 += _val;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode4)
    //    {
    //        lastSelectedLevel_Mode4 += _val;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode5)
    //    {
    //        lastSelectedLevel_Mode5 += _val;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode6)
    //    {
    //        lastSelectedLevel_Mode6 += _val;
    //    }
    //}

    //public int Get_LastSelectedGameModeSceneIndex()
    //{

    //    return Constants.sceneIndex_GameMode2;


    //}

    //public void Unlock_NextLevelOfCurrentGameMode()
    //{
    //    if (lastSelectedGameMode == Constants.gameModeIndex_Mode1)
    //    {
    //        levelsUnlocked_Mode1[Get_LastUnlockedLevelOfGameMode(Constants.gameModeIndex_Mode1) + 1] = true;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode2)
    //    {
    //        levelsUnlocked_Mode2[Get_LastUnlockedLevelOfGameMode(Constants.gameModeIndex_Mode2) + 1] = true;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode3)
    //    {
    //        levelsUnlocked_Mode3[Get_LastUnlockedLevelOfGameMode(Constants.gameModeIndex_Mode3) + 1] = true;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode4)
    //    {
    //        levelsUnlocked_Mode4[Get_LastUnlockedLevelOfGameMode(Constants.gameModeIndex_Mode4) + 1] = true;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode5)
    //    {
    //        levelsUnlocked_Mode5[Get_LastUnlockedLevelOfGameMode(Constants.gameModeIndex_Mode5) + 1] = true;
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode6)
    //    {
    //        levelsUnlocked_Mode6[Get_LastUnlockedLevelOfGameMode(Constants.gameModeIndex_Mode6) + 1] = true;
    //    }
    //}


    //public bool Get_LevelUnlockStatusOfCurrentGameMode(int _level)
    //{

    //    if (lastSelectedGameMode == Constants.gameModeIndex_Mode1)
    //    {
    //        return levelsUnlocked_Mode1[_level];
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode2)
    //    {
    //        return levelsUnlocked_Mode2[_level];
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode3)
    //    {
    //        return levelsUnlocked_Mode3[_level];
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode4)
    //    {
    //        return levelsUnlocked_Mode4[_level];
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode5)
    //    {
    //        return levelsUnlocked_Mode5[_level];
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode6)
    //    {
    //        return levelsUnlocked_Mode6[_level];
    //    }
    //    return false;
    //}

    //public int Get_LevelStarsOfCurrentGameMode(int _level)
    //{

    //    if (lastSelectedGameMode == Constants.gameModeIndex_Mode1)
    //    {
    //        return levelsStars_Mode1[_level];
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode2)
    //    {
    //        return levelsStars_Mode2[_level];
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode3)
    //    {
    //        return levelsStars_Mode3[_level];
    //    }

    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode4)
    //    {
    //        return levelsStars_Mode4[_level];
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode5)
    //    {
    //        return levelsStars_Mode5[_level];
    //    }
    //    else if (lastSelectedGameMode == Constants.gameModeIndex_Mode6)
    //    {
    //        return levelsStars_Mode6[_level];
    //    }

    //    return 0;
    //}

    //wiil return the _val number locked item from the store. e.g 1 will return the first locked
    public int GetLockedItemIndex(int _val)
    {


        for (int i = 0; i < vehiclesUnlocked.Length; i++)
        {
            //  Debug.Log("i :"+i); 
            if (!vehiclesUnlocked[i])
            {

                _val--;

                if (_val == 0)
                {

                    return i;
                }
            }
        }

        //Less items than value are locked
        return -1;
    }

    public bool AreAllCarsUnlocked()
    {
        for (int i = 0; i < vehiclesUnlocked.Length; i++)
        {
            if (!vehiclesUnlocked[i])
            {

                //Debug.LogError("All vehicles --NOT-- unlocked");
                return false;
            }

        }
        //Debug.LogError("All vehicles are unlocked");
        return true;
    }

    public void unlockAllSuperCar()
    {
        for (int i = 0; i < vehiclesUnlocked.Length; i++)
        {
            if (!vehiclesUnlocked[i])
            {
                vehiclesUnlocked[i] = true;
            }
        }
    }

    public void unlockAllF1()
    {
        for (int i = 0; i < vehiclesUnlockedFormuala.Length; i++)
        {
            if (!vehiclesUnlockedFormuala[i])
            {
                vehiclesUnlockedFormuala[i] = true;
            }
        }
    }

    public void unlockAllMonsterTrucks()
    {
        for (int i = 0; i < vehiclesUnlockedmoster.Length; i++)
        {
            if (!vehiclesUnlockedmoster[i])
            {
                vehiclesUnlockedmoster[i] = true;
            }
        }
    }
    public void UnlockAllVehicles()
    {

        for (int i = 0; i < vehiclesUnlocked.Length; i++)
        {
            if (!vehiclesUnlocked[i])
            {
                vehiclesUnlocked[i] = true;
            }
        }
        for (int i = 0; i < vehiclesUnlockedFormuala.Length; i++)
        {
            if (!vehiclesUnlockedFormuala[i])
            {
                vehiclesUnlockedFormuala[i] = true;
            }
        }
        for (int i = 0; i < vehiclesUnlockedmoster.Length; i++)
        {
            if (!vehiclesUnlockedmoster[i])
            {
                vehiclesUnlockedmoster[i] = true;
            }
        }
        for (int i = 0; i < vehiclesUnlockedSupercar.Length; i++)
        {
            if (!vehiclesUnlockedSupercar[i])
            {
                vehiclesUnlockedSupercar[i] = true;
            }
        }
        for (int i = 0; i < vehiclesUnlockedCitybuses.Length; i++)
        {
            if (!vehiclesUnlockedCitybuses[i])
            {
                vehiclesUnlockedCitybuses[i] = true;
            }
        }
        for (int i = 0; i < vehiclesUnlockedCityTrucks.Length; i++)
        {
            if (!vehiclesUnlockedCityTrucks[i])
            {
                vehiclesUnlockedCityTrucks[i] = true;
            }
        }
    }

    public void UnlockAllLevels()
    {

        for (int i = 0; i < LevelsUnlocked_Mode1.Length; i++)
        {
            if (!LevelsUnlocked_Mode1[i])
            {
                LevelsUnlocked_Mode1[i] = true;
            }
        }

        for (int i = 0; i < LevelsUnlocked_Mode2.Length; i++)
        {
            if (!LevelsUnlocked_Mode2[i])
            {
                LevelsUnlocked_Mode2[i] = true;
            }
        }
        for (int i = 0; i < LevelsUnlocked_Mode3.Length; i++)
        {
            if (!LevelsUnlocked_Mode3[i])
            {
                LevelsUnlocked_Mode3[i] = true;
            }
        }
        for (int i = 0; i < LevelsUnlocked_Mode4.Length; i++)
        {
            if (!LevelsUnlocked_Mode4[i])
            {
                LevelsUnlocked_Mode4[i] = true;
            }
        }
        for (int i = 0; i < LevelsUnlocked_Mode5.Length; i++)
        {
            if (!LevelsUnlocked_Mode5[i])
            {
                LevelsUnlocked_Mode5[i] = true;
            }
        }
        for (int i = 0; i < LevelsUnlocked_Mode6.Length; i++)
        {
            if (!LevelsUnlocked_Mode6[i])
            {
                LevelsUnlocked_Mode6[i] = true;
            }
        }
        // Mode2Unlocked = true;
    }

    public bool GameAudio { get => gameAudio; set => gameAudio = value; }
    public bool GameSound { get => gameSound; set => gameSound = value; }
    public int GoldCoins
    {
        get => goldCoins; set
        {

            goldCoins = value;
            // Toolbox.GameManager.UpdateCoinsTxtHandling();
        }
    }
    public int HighScore { get => highScore; set => highScore = value; }
    public bool FirstRun { get => firstRun; set => firstRun = value; }
    public bool TutorialShowed { get => tutorialShowed; set => tutorialShowed = value; }
    public bool AppRated { get => appRated; set => appRated = value; }
    public string PlayerName { get => playerName; set => playerName = value; }
    public bool FbLoggedIn { get => fbLoggedIn; set => fbLoggedIn = value; }
    public bool SoundMute { get => soundMute; set => soundMute = value; }

    public int LastSelectedVehicle { get => lastSelectedVehicle; set => lastSelectedVehicle = value; }
    public bool[] VehiclesUnlocked { get => vehiclesUnlocked; set => vehiclesUnlocked = value; }
    public int LastSelectedVehiclesupercar { get => lastSelectedVehiclesupercar; set => lastSelectedVehiclesupercar = value; }
    public bool[] VehiclesUnlockedSupercar { get => vehiclesUnlockedSupercar; set => vehiclesUnlockedSupercar = value; }
    public int LastSelectedVehicleFormuala { get => lastSelectedVehicleFormuala; set => lastSelectedVehicleFormuala = value; }
    public bool[] VehiclesUnlockedFormuala { get => vehiclesUnlockedFormuala; set => vehiclesUnlockedFormuala = value; }
    public int LastSelectedVehiclemoster { get => lastSelectedVehiclemoster; set => lastSelectedVehiclemoster = value; }
    public bool[] VehiclesUnlockedmoster { get => vehiclesUnlockedmoster; set => vehiclesUnlockedmoster = value; }
    public int LastSelectedVehicleCityCars { get => lastSelectedVehicleCityCars; set => lastSelectedVehicleCityCars = value; }
    public bool[] VehiclesUnlockedCityCars { get => vehiclesUnlockedCityCars; set => vehiclesUnlockedCityCars = value; }
    public int LastSelectedVehicleCityBuses { get => lastSelectedVehicleCityBuses; set => lastSelectedVehicleCityBuses = value; }
    public bool[] VehiclesUnlockedCitybuses { get => vehiclesUnlockedCitybuses; set => vehiclesUnlockedCitybuses = value; }
    public int LastSelectedVehicleCityTrucks { get => lastSelectedVehicleCityTrucks; set => lastSelectedVehicleCityTrucks = value; }
    public bool[] VehiclesUnlockedCityTrucks { get => vehiclesUnlockedCityTrucks; set => vehiclesUnlockedCityTrucks = value; }

    public int LastSelectedGameMode { get => lastSelectedGameMode; set => lastSelectedGameMode = value; }
    public int LastSelectedGameModeCar { get => lastSelectedGameModeCar; set => lastSelectedGameModeCar = value; }
    public bool[] LevelsUnlocked_Mode1 { get => levelsUnlocked_Mode1; set => levelsUnlocked_Mode1 = value; }
    public int[] LevelsStars_Mode1 { get => levelsStars_Mode1; set => levelsStars_Mode1 = value; }
    public bool[] LevelsUnlocked_Mode2 { get => levelsUnlocked_Mode2; set => levelsUnlocked_Mode2 = value; }
    public int[] LevelsStars_Mode2 { get => levelsStars_Mode2; set => levelsStars_Mode2 = value; }

    public bool[] LevelsUnlocked_Mode3 { get => levelsUnlocked_Mode3; set => levelsUnlocked_Mode3 = value; }
    public int[] LevelsStars_Mode3 { get => levelsStars_Mode3; set => levelsStars_Mode3 = value; }

    public bool[] LevelsUnlocked_Mode4 { get => levelsUnlocked_Mode4; set => levelsUnlocked_Mode4 = value; }
    public int[] LevelsStars_Mode4 { get => levelsStars_Mode4; set => levelsStars_Mode4 = value; }
    public bool[] LevelsUnlocked_Mode5 { get => levelsUnlocked_Mode5; set => levelsUnlocked_Mode5 = value; }
    public int[] LevelsStars_Mode5 { get => levelsStars_Mode5; set => levelsStars_Mode5 = value; }

    public bool[] LevelsUnlocked_Mode6 { get => levelsUnlocked_Mode6; set => levelsUnlocked_Mode6 = value; }
    public int[] LevelsStars_Mode6 { get => levelsStars_Mode6; set => levelsStars_Mode6 = value; }

    public int LastSelectedLevel_Mode1 { get => lastSelectedLevel_Mode1; set => lastSelectedLevel_Mode1 = value; }
    public int LastSelectedLevel_Mode2 { get => lastSelectedLevel_Mode2; set => lastSelectedLevel_Mode2 = value; }
    public int LastSelectedLevel_Mode3 { get => lastSelectedLevel_Mode3; set => lastSelectedLevel_Mode3 = value; }
    public int LastSelectedLevel_Mode4 { get => lastSelectedLevel_Mode4; set => lastSelectedLevel_Mode4 = value; }
    public int LastSelectedLevel_Mode5 { get => lastSelectedLevel_Mode5; set => lastSelectedLevel_Mode5 = value; }

    public int LastSelectedLevel_Mode6 { get => lastSelectedLevel_Mode6; set => lastSelectedLevel_Mode6 = value; }

    public DateTime NextDailyRewardTime { get => nextDailyRewardTime; set => nextDailyRewardTime = value; }
    public DateTime ClassicMode_UnlockDateTime { get => classicMode_unlockDateTime; set => classicMode_unlockDateTime = value; }
    public int DailyRewardDay { get => dailyRewardDay; set => dailyRewardDay = value; }
    public bool NoAdsPurchased { get => noAdsPurchased; set => noAdsPurchased = value; }
    public float SoundVolume { get => soundVolume; set => soundVolume = value; }
    public float MusicVolume { get => musicVolume; set => musicVolume = value; }
    public int DynamicDailyRewardItemNumber1 { get => dynamicDailyRewardItemNumber1; set => dynamicDailyRewardItemNumber1 = value; }
    public bool UserConsent { get => userConsent; set => userConsent = value; }
    public bool Mode2Unlocked { get => mode2Unlocked; set => mode2Unlocked = value; }
    public bool Mode3Unlocked { get => mode3Unlocked; set => mode3Unlocked = value; }
    public bool Mode4Unlocked { get => mode4Unlocked; set => mode4Unlocked = value; }
    public bool muiltplayerMode2 { get => MuiltplayerMode2; set => MuiltplayerMode2 = value; }
    public bool muiltplayerMode1 { get => MuiltPlayerMode1; set => MuiltPlayerMode1 = value; }
    public int ScheduledNotificationId { get => scheduledNotificationId; set => scheduledNotificationId = value; }
    public int LastLevelStartAnimation { get => lastLevelStartAnimation; set => lastLevelStartAnimation = value; }

}


public class DB : MonoBehaviour
{

    [SerializeField] private Prefs_Data prefs;

    public Prefs_Data Prefs { get => prefs; set => prefs = value; }
    private const string FMT = "O";
    private void Awake()
    {
        //  Load_Binary_Prefs();
        //print("DateTime.Now :" + DateTime.Now);
        //print("ClassicMode_UnlockDateTime :" + Prefs.ClassicMode_UnlockDateTime);
        //if (DateTime.Now > prefs.ClassicMode_UnlockDateTime)
        //{
        //    Prefs.ClassicMode_UnlockDateTime = DateTime.Now.AddDays(2);
        //    print("AddDays");
        //}
        // Save_Json_Prefs();



        if (!PlayerPrefsX.GetBool("firstRun5", true))
        {
            GetPlayerPrefs();

            //  PlayerPrefs.SetString("NextDailyRewardTime", prefs.NextDailyRewardTime.ToLongTimeString());
        }
        else
        {
            SetPlayerPrefs();
        }

        //   Debug.Log(DateTime.Parse(PlayerPrefs.GetString("NextDailyRewardTime")));

    }
    private void OnApplicationQuit()
    {
        SetPlayerPrefs();
    }

    private void OnApplicationPause(bool pause)
    {

        SetPlayerPrefs();
        //if (!pause)
        //{
        //    if (PreferenceManager.GetAdsStatus() && Constants.AppOpenAd == false)
        //    {
        //        AppOpenAdManager.Instance.ShowAdIfAvailable();
        //    }
        //    else
        //    {
        //        Constants.AppOpenAd = false;
        //    }
        //}
    }

    public void GetPlayerPrefs()
    {
        prefs.GameAudio = PlayerPrefsX.GetBool("gameAudio");
        prefs.GameSound = PlayerPrefsX.GetBool("gameSound");
        prefs.SoundVolume = PlayerPrefs.GetFloat("soundVolume");
        prefs.MusicVolume = PlayerPrefs.GetFloat("musicVolume");
        prefs.GoldCoins = PlayerPrefs.GetInt("goldCoins");
        prefs.HighScore = PlayerPrefs.GetInt("highScore");
        //prefs.RetryLifes1 = PlayerPrefs.GetInt("chances");

        prefs.PlayerName = PlayerPrefs.GetString("playerName");
        prefs.FbLoggedIn = PlayerPrefsX.GetBool("fbLoggedIn");
        prefs.SoundMute = PlayerPrefsX.GetBool("soundMute");
        prefs.FirstRun = PlayerPrefsX.GetBool("firstRun5");
        prefs.TutorialShowed = PlayerPrefsX.GetBool("tutorialShowed");
        prefs.AppRated = PlayerPrefsX.GetBool("appRated");
        prefs.UserConsent = PlayerPrefsX.GetBool("userConsent");
        prefs.LastLevelStartAnimation = PlayerPrefs.GetInt("lastLevelStartAnimation");
        prefs.LastSelectedGameMode = PlayerPrefs.GetInt("lastSelectedGameMode");
        prefs.LastSelectedGameModeCar = PlayerPrefs.GetInt("lastSelectedGameModeCar");

        prefs.LastSelectedLevel_Mode1 = PlayerPrefs.GetInt("lastSelectedLevel_Mode1");
        prefs.LastSelectedLevel_Mode2 = PlayerPrefs.GetInt("lastSelectedLevel_Mode2");
        prefs.LastSelectedLevel_Mode3 = PlayerPrefs.GetInt("lastSelectedLevel_Mode3");
        prefs.LastSelectedLevel_Mode4 = PlayerPrefs.GetInt("lastSelectedLevel_Mode4");
        prefs.LastSelectedLevel_Mode5 = PlayerPrefs.GetInt("lastSelectedLevel_Mode5");
        prefs.LastSelectedLevel_Mode6 = PlayerPrefs.GetInt("lastSelectedLevel_Mode6");

        prefs.LevelsUnlocked_Mode1 = PlayerPrefsX.GetBoolArray("LevelsUnlocked_Mode1");
        prefs.LevelsUnlocked_Mode2 = PlayerPrefsX.GetBoolArray("LevelsUnlocked_Mode2");
        prefs.LevelsUnlocked_Mode3 = PlayerPrefsX.GetBoolArray("LevelsUnlocked_Mode3");
        prefs.LevelsUnlocked_Mode4 = PlayerPrefsX.GetBoolArray("LevelsUnlocked_Mode4");
        prefs.LevelsUnlocked_Mode5 = PlayerPrefsX.GetBoolArray("LevelsUnlocked_Mode5");
        prefs.LevelsUnlocked_Mode6 = PlayerPrefsX.GetBoolArray("LevelsUnlocked_Mode6");

        prefs.LevelsStars_Mode1 = PlayerPrefsX.GetIntArray("levelsStars_Mode1");
        prefs.LevelsStars_Mode2 = PlayerPrefsX.GetIntArray("levelsStars_Mode2");
        prefs.LevelsStars_Mode3 = PlayerPrefsX.GetIntArray("levelsStars_Mode3");
        prefs.LevelsStars_Mode4 = PlayerPrefsX.GetIntArray("levelsStars_Mode4");
        prefs.LevelsStars_Mode5 = PlayerPrefsX.GetIntArray("levelsStars_Mode5");
        prefs.LevelsStars_Mode6 = PlayerPrefsX.GetIntArray("levelsStars_Mode6");


        prefs.Mode2Unlocked = PlayerPrefsX.GetBool("mode2Unlocked");
        prefs.Mode3Unlocked = PlayerPrefsX.GetBool("mode3Unlocked");
        prefs.Mode4Unlocked = PlayerPrefsX.GetBool("mode4Unlocked");
        prefs.muiltplayerMode2 = PlayerPrefsX.GetBool("mode5Unlocked");
        prefs.muiltplayerMode1 = PlayerPrefsX.GetBool("mode6Unlocked");



        prefs.NoAdsPurchased = PlayerPrefsX.GetBool("noAdsPurchased");
        //prefs.MegaOfferPurchased = PlayerPrefsX.GetBool("megaOfferPurchased");

        prefs.LastSelectedVehicle = PlayerPrefs.GetInt("lastSelectedVehicle");
        prefs.VehiclesUnlocked = PlayerPrefsX.GetBoolArray("vehiclesUnlocked");

        prefs.LastSelectedVehicleFormuala = PlayerPrefs.GetInt("lastSelectedVehicleFormuala");
        prefs.VehiclesUnlockedFormuala = PlayerPrefsX.GetBoolArray("vehiclesUnlockedFormuala");


        prefs.LastSelectedVehiclemoster = PlayerPrefs.GetInt("lastSelectedVehiclemoster");
        prefs.VehiclesUnlockedmoster = PlayerPrefsX.GetBoolArray("vehiclesUnlockedmoster");



        prefs.LastSelectedVehiclesupercar = PlayerPrefs.GetInt("lastSelectedVehiclesupercar");
        prefs.VehiclesUnlockedSupercar = PlayerPrefsX.GetBoolArray("vehiclesUnlockedsupercar");

        prefs.LastSelectedVehicleCityBuses = PlayerPrefs.GetInt("LastSelectedVehicleCityBuses");
        prefs.VehiclesUnlockedCitybuses = PlayerPrefsX.GetBoolArray("VehiclesUnlockedCitybuses");

        prefs.LastSelectedVehicleCityTrucks = PlayerPrefs.GetInt("LastSelectedVehicleCityTrucks");
        prefs.VehiclesUnlockedCityTrucks = PlayerPrefsX.GetBoolArray("VehiclesUnlockedCityTrucks");

        prefs.LastSelectedVehicleCityCars = PlayerPrefs.GetInt("LastSelectedVehicleCityCars");
        prefs.VehiclesUnlockedCityCars = PlayerPrefsX.GetBoolArray("VehiclesUnlockedCityCars");


        //prefs.AnimalHero1 = PlayerPrefs.GetInt("AnimalHero");
        //prefs.AnimslModeLevel1 = PlayerPrefs.GetInt("AnimalModeLevel");
        //  prefs.NextDailyRewardTime = PlayerPrefsX.get ("NextDailyRewardTime");
        prefs.DailyRewardDay = PlayerPrefs.GetInt("DailyRewardDay");
        prefs.DynamicDailyRewardItemNumber1 = PlayerPrefs.GetInt("DynamicDailyRewardItemNumber1");
        prefs.ScheduledNotificationId = PlayerPrefs.GetInt("ScheduledNotificationId");

        PlayerPrefsX.SetBool("LevelPlayed", false);


        prefs.ClassicMode_UnlockDateTime = DateTime.Parse(PlayerPrefs.GetString("ClassicMode_UnlockDateTime"));
    }


    public void SetPlayerPrefs()
    {
        PlayerPrefsX.SetBool("gameAudio", prefs.GameAudio);
        PlayerPrefsX.SetBool("gameSound", prefs.GameSound);
        PlayerPrefs.SetFloat("soundVolume", prefs.SoundVolume);
        PlayerPrefs.SetFloat("musicVolume", prefs.MusicVolume);
        PlayerPrefs.SetInt("goldCoins", prefs.GoldCoins);
        PlayerPrefs.SetInt("highScore", prefs.HighScore);
        //PlayerPrefs.SetInt("chances", prefs.RetryLifes1);
        PlayerPrefs.SetString("playerName", prefs.PlayerName);
        PlayerPrefsX.SetBool("fbLoggedIn", prefs.FbLoggedIn);
        PlayerPrefsX.SetBool("soundMute", prefs.SoundMute);
        PlayerPrefsX.SetBool("firstRun5", prefs.FirstRun);
        PlayerPrefsX.SetBool("tutorialShowed", prefs.TutorialShowed);
        PlayerPrefsX.SetBool("appRated", prefs.AppRated);
        PlayerPrefsX.SetBool("userConsent", prefs.UserConsent);
        PlayerPrefs.SetInt("lastLevelStartAnimation", prefs.LastLevelStartAnimation);

        PlayerPrefs.SetInt("lastSelectedGameMode", prefs.LastSelectedGameMode);
        PlayerPrefs.SetInt("lastSelectedGameModeCar", prefs.LastSelectedGameModeCar);

        PlayerPrefs.SetInt("lastSelectedLevel_Mode1", prefs.LastSelectedLevel_Mode1);
        PlayerPrefs.SetInt("lastSelectedLevel_Mode2", prefs.LastSelectedLevel_Mode2);
        PlayerPrefs.SetInt("lastSelectedLevel_Mode3", prefs.LastSelectedLevel_Mode3);
        PlayerPrefs.SetInt("lastSelectedLevel_Mode4", prefs.LastSelectedLevel_Mode4);
        PlayerPrefs.SetInt("lastSelectedLevel_Mode5", prefs.LastSelectedLevel_Mode5);
        PlayerPrefs.SetInt("lastSelectedLevel_Mode6", prefs.LastSelectedLevel_Mode6);


        PlayerPrefsX.SetBoolArray("LevelsUnlocked_Mode1", prefs.LevelsUnlocked_Mode1);
        PlayerPrefsX.SetBoolArray("LevelsUnlocked_Mode2", prefs.LevelsUnlocked_Mode2);
        PlayerPrefsX.SetBoolArray("LevelsUnlocked_Mode3", prefs.LevelsUnlocked_Mode3);
        PlayerPrefsX.SetBoolArray("LevelsUnlocked_Mode4", prefs.LevelsUnlocked_Mode4);
        PlayerPrefsX.SetBoolArray("LevelsUnlocked_Mode5", prefs.LevelsUnlocked_Mode5);
        PlayerPrefsX.SetBoolArray("LevelsUnlocked_Mode6", prefs.LevelsUnlocked_Mode6);

        PlayerPrefsX.SetIntArray("levelsStars_Mode1", prefs.LevelsStars_Mode1);
        PlayerPrefsX.SetIntArray("levelsStars_Mode2", prefs.LevelsStars_Mode2);
        PlayerPrefsX.SetIntArray("levelsStars_Mode3", prefs.LevelsStars_Mode3);
        PlayerPrefsX.SetIntArray("levelsStars_Mode4", prefs.LevelsStars_Mode4);
        PlayerPrefsX.SetIntArray("levelsStars_Mode5", prefs.LevelsStars_Mode5);
        PlayerPrefsX.SetIntArray("levelsStars_Mode6", prefs.LevelsStars_Mode6);

        PlayerPrefsX.SetBool("mode2Unlocked", prefs.Mode2Unlocked);
        PlayerPrefsX.SetBool("mode3Unlocked", prefs.Mode3Unlocked);
        PlayerPrefsX.SetBool("mode4Unlocked", prefs.Mode4Unlocked);
        PlayerPrefsX.SetBool("mode5Unlocked", prefs.muiltplayerMode2);
        PlayerPrefsX.SetBool("mode6Unlocked", prefs.muiltplayerMode1);



        PlayerPrefsX.SetBool("noAdsPurchased", prefs.NoAdsPurchased);
        //PlayerPrefsX.SetBool("megaOfferPurchased", prefs.MegaOfferPurchased);
        PlayerPrefs.SetInt("lastSelectedVehicle", prefs.LastSelectedVehicle);
        PlayerPrefsX.SetBoolArray("vehiclesUnlocked", prefs.VehiclesUnlocked);
        PlayerPrefs.SetInt("lastSelectedVehicleFormuala", prefs.LastSelectedVehicleFormuala);
        PlayerPrefsX.SetBoolArray("vehiclesUnlockedFormuala", prefs.VehiclesUnlockedFormuala);
        PlayerPrefs.SetInt("lastSelectedVehiclemoster", prefs.LastSelectedVehiclemoster);
        PlayerPrefsX.SetBoolArray("vehiclesUnlockedmoster", prefs.VehiclesUnlockedmoster);

        PlayerPrefs.SetInt("lastSelectedVehiclesupercar", prefs.LastSelectedVehiclesupercar);
        PlayerPrefsX.SetBoolArray("vehiclesUnlockedsupercar", prefs.VehiclesUnlockedSupercar);

        PlayerPrefs.SetInt("LastSelectedVehicleCityBuses", prefs.LastSelectedVehicleCityBuses);
        PlayerPrefsX.SetBoolArray("VehiclesUnlockedCitybuses", prefs.VehiclesUnlockedCitybuses);

        PlayerPrefs.SetInt("LastSelectedVehicleCityCars", prefs.LastSelectedVehicleCityCars);
        PlayerPrefsX.SetBoolArray("VehiclesUnlockedCityCars", prefs.VehiclesUnlockedCityCars);

        PlayerPrefs.SetInt("LastSelectedVehicleCityTrucks", prefs.LastSelectedVehicleCityTrucks);
        PlayerPrefsX.SetBoolArray("VehiclesUnlockedCityTrucks", prefs.VehiclesUnlockedCityTrucks);



        PlayerPrefs.SetInt("DailyRewardDay", prefs.DailyRewardDay);
        PlayerPrefs.SetInt("DynamicDailyRewardItemNumber1", prefs.DynamicDailyRewardItemNumber1);
        PlayerPrefs.SetInt("ScheduledNotificationId", prefs.ScheduledNotificationId);

        PlayerPrefs.SetString("ClassicMode_UnlockDateTime", prefs.ClassicMode_UnlockDateTime.ToString());
        //PlayerPrefs.SetInt("AnimalModeLevel", prefs.AnimslModeLevel1);
        //PlayerPrefs.SetInt("AnimalHero", prefs.AnimalHero1);
    }


}
