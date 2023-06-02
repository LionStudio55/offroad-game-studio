//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public class PlayerPrefManager : MonoBehaviour {

//	public static PlayerPrefManager _instance;
//    MediationHandler mediation;

//    private void Awake()
//	{
//		if (_instance == null)
//		{
//			_instance = this;
//		}
//		else if (_instance != this)
//		{
//			Destroy(gameObject);
//		}
//        mediation = FindObjectOfType<MediationHandler>();
//    }

//	public static PlayerPrefManager Instance
//	{

//		get
//		{

//			if (_instance == null)
//			{

//				try
//				{
//					_instance = GameObject.FindObjectOfType<PlayerPrefManager>();
//				}
//				catch (Exception e)
//				{
//					Debug.Log(e.Message);
//					_instance = new PlayerPrefManager();
//				}

//			}

//			return _instance;

//		}

//	}


//	void Start()
//	{
//		Debug.Log("initialized PlayerPrefManager");

//	}

//    public void RemoveAds()
//    {
		
//        if (mediation != null)//        {//            mediation.hideSmallBanner();//            mediation.hideMediumBanner();//        }
//        PlayerPrefs.SetInt("RemoveAds", 1);

//        if (InAppSettings.instance)
//        {
//            InAppSettings.instance.SetupInApp();
//        }

//    }



//    public void UnlockAllLevels()
//    {

//        PlayerPrefs.SetInt("unlockedlevels", 40);

//        PlayerPrefs.SetInt("LevelsUnlock", 1);

//        if (InAppSettings.instance)
//        {
//            InAppSettings.instance.SetupInApp();
//        }

//        if (levelselection.instance)
//        {
//            levelselection.instance.firstchk();
//        }

//        //  Application.LoadLevel(Application.loadedLevel);
//        //PlayerPrefs.SetInt("Set your ID", 1);//
//    }

//    public void UnlockAllWeapons()
//    {
//        for (int i = 0; i <= 9; i++)
//        {
//            PlayerPrefs.SetInt("costgun" + i.ToString(), 0);
//        }

//        PlayerPrefs.SetInt("PlayersInApp", 1);

//        if (InAppSettings.instance)
//        {
//            InAppSettings.instance.SetupInApp();
//        }

//        // Application.LoadLevel(Application.loadedLevel);
//        //PlayerPrefs.SetInt("Set your ID", 1);//
//    }




//    public bool IsAdsRemoved()
//    {

//        if (PlayerPrefs.GetInt("RemoveAds") == 0)
//            return false;
//        else
//            return true;
//    }

  

//}
