//using GameAnalyticsSDK;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//using GoogleMobileAds.Api;

[Serializable]
public class LevelsThumbnail
{
    public Sprite[] thumbnails;
}


public class LevelSelectionListner : MonoBehaviour
{
    MediationHandler mediation;
    public Transform content;
    public Text coinsTxt;
    public Text daimondTxt;

    //public GameObject MessagePopup;
    //public GameObject Loading;
    //public Text daimondTxt;
    //public int[] ModesLevel;

    public GameObject PlayButon;
    public GameObject UnlockallBtn;
    public GameObject UnlockallLevelsInapps;


    public int tileWidth = 446;
    public int tileSpacing = 23;
    //public Sprite[] ModesLevelsthumbnails;
    //public LevelButtonListner[] btnListner;
    //public List<GameObject> Tutotialobj;

    private void OnEnable()
    {
        // content.gameObject.GetComponent<Animator>().enabled = true;
        RefreshView();
        //   Invoke(nameof(Megaoffer), 2f);
        //content.localPosition = new Vector3(
        //    -(Constants.Getprefs(Constants.lastselectedLevel) * tileWidth)
        //    - (Constants.Getprefs(Constants.lastselectedLevel) * tileSpacing), 0, 0);

        //Bg.SetActive(true);
    }


    private void Start()
    {
        mediation = FindObjectOfType<MediationHandler>();
    }


    public void RefreshView()
    {
        InitLevelButtonsState();
        //CheckStatus_UnlockallLevels();
        UpdateTxts();
    }
    private void Megaoffer()
    {
        if (Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)) >= Constants.TotallevelofMode[Constants.Getprefs(Constants.lastselectedMode)] - 1)
        {
            UnlockallLevelsInapps.SetActive(false);
        }
        else
        {
            UnlockallLevelsInapps.SetActive(true);
        }
        CancelInvoke(nameof(Megaoffer));
    }
    public void UpdateTxts()
    {
        coinsTxt.text = Constants.Getprefs(Constants.Totalreward).ToString();
        daimondTxt.text = Constants.Getprefs(Constants.Daimond).ToString();
    }

    public void CheckStatus_UnlockallLevels()
    {
        if (Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)) >= Constants.TotallevelofMode[Constants.Getprefs(Constants.lastselectedMode)] - 1)
        {
            UnlockallBtn.SetActive(false);
        }
        else
        {
            UnlockallBtn.SetActive(true);
        }

    }


    private void InitLevelButtonsState()
    {
        for (int i = 0; i < content.childCount; i++)
        {
            content.GetChild(i).gameObject.SetActive(false);
        }

        bool watchVideoBtnEnabled = false;
        int lvlUnlocked = Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode));
        for (int i = 0; i < Constants.TotallevelofMode[Constants.Getprefs(Constants.lastselectedMode)]/*content.childCount*/; i++)
        {
           // Debug.Log("InitLevelButtonsState"); 
            content.GetChild(i).gameObject.SetActive(true);

            LevelButtonListner btnListner = content.GetChild(i).GetComponent<LevelButtonListner>();
            //if (ModesLevelsthumbnails.Count > 0)
            //    btnListner.Render.sprite = ModesLevelsthumbnails[Constants.Getprefs(Constants.lastselectedMode)].thumbnails[i];
            btnListner.Set_LevleNameTxt(i + 1);
            btnListner.Lock_Status(true);

           

            //Watch video Btn for Unlock Next Level
            //if (!watchVideoBtnEnabled && i == lvlUnlocked+1)
            //{
            //    //int watchindex = lvlUnlocked + 1;
            //    //Debug.Log("lvlUnlocked :"+ watchindex);
            //    content.GetChild(i).GetComponent<LevelButtonListner>().WatchVideoUnlock_Status(true);
            //    watchVideoBtnEnabled = true;
            //}
            //else
            //    btnListner.WatchVideoUnlock_Status(false);

            ////hightlight last selected level
            if (i == lvlUnlocked)
            {
              //  btnListner.check_OutlineStatus(true);
              //  btnListner.transform.GetChild(0).GetComponent<UIAnimatorCore.UIAnimator>().enabled = true;
                btnListner.Lock_Status(false);
                btnListner.Hover_status(true);
                //btnListner.PlayedState.SetActive(false);
                // btnListner.Render.GetComponent<UIShiny>().enabled = true;
            }
            else if (i <= lvlUnlocked)
            {
               // btnListner.check_OutlineStatus(false);
               // btnListner.transform.GetChild(0).GetComponent<UIAnimatorCore.UIAnimator>().enabled = false;
                btnListner.Lock_Status(false);
                btnListner.Hover_status(false);
               // btnListner.PlayedState.SetActive(true);

                //  btnListner.Render.GetComponent<UIShiny>().enabled = false;
            }
            else
            {
                //btnListner.check_OutlineStatus(false);
              //  btnListner.transform.GetChild(0).GetComponent<UIAnimatorCore.UIAnimator>().enabled = false;
                btnListner.Lock_Status(true);
                btnListner.Hover_status(false);
                //btnListner.PlayedState.SetActive(false);
                // btnListner.Render.GetComponent<UIShiny>().enabled = false;
            }
        }
       
    }

    #region ButtonListners

    public void OnPress_LevelButton(GameObject _buttonObj)
    {
      UIManager.Instance.UIDummy_Loading.SetActive(true);
        for (int i = 0; i < content.childCount; i++)
        {
            //content.GetChild(i).transform.GetChild(0).GetComponent<UIAnimatorCore.UIAnimator>().enabled = false;
          //  content.GetChild(i).GetComponent<LevelButtonListner>().check_OutlineStatus(false);

        }
        for (int i = 0; i < content.childCount; i++)
        {
            if (_buttonObj == content.GetChild(i).gameObject)
            {

                Constants.SetPref(Constants.lastselectedLevel, i);
                
                Invoke(nameof(Loadscene), 7f);
                //  content.GetChild(i).GetComponent<LevelButtonListner>().check_OutlineStatus(true);
                // content.GetChild(i).transform.GetChild(0).GetComponent<UIAnimatorCore.UIAnimator>().enabled = true;
               // PlayButon.SetActive(true);
               // loadAds();
                return;
            }
        }

    }
    public void Loadscene()
    {
        UIManager.Instance.ShowNextUI();
        UIManager.Instance.UIDummy_Loading.SetActive(false);
        //SceneManager.LoadScene(2);
        SHOWInterstitialIAD();
        
    }
    public void Levellock()
    {
        UIManager.Instance.MessagePopup.SetActive(true);
        UIManager.Instance.MessagePopup.GetComponent<MessageListner>().UpdateTxt("This Level is currently locked.Please Play before Previous Level", "LEVEL LOCKED");
    }
    public void OnPress_Play()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        SceneManager.LoadScene(2);
        SHOWInterstitialIAD();
        //if (Toolbox.GameManager.Godirectlevelselectionfrommode)
        //    Toolbox.GameManager.Loading_GameScene(true, Toolbox.DB.Prefs.Get_LastSelectedGameModeSceneIndex());
        //else
        //    this.GetComponentInParent<UIManager>().ShowNextUI();

        // Toolbox.GameManager.Permanent_Log("LastSelectedLevelOfCurrentGameMode :" + Toolbox.DB.Prefs.Get_LastSelectedLevelOfCurrentGameMode());
        // Toolbox.GameManager.Permanent_Log("LastSelectedGameMode :" + Toolbox.DB.Prefs.LastSelectedGameMode);
        //loadAds();
    }
    public void OnPress_Back()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        UIManager.Instance.ShowPrevUI();
    }

    public void UnlockNextLevel_WatchVideo()
    {

        try
        {
            //if (FindObjectOfType<AbstractAdsmanager>())
            //    FindObjectOfType<AbstractAdsmanager>().ShowRewardedVideo(RewardType.UNLOCK_NEXT_Level);
        }

        catch (Exception e)
        {
            //GameAnalytics.NewErrorEvent(GAErrorSeverity.Info, "AdsManager Instance Not Found!");
        }
    }
    public void OnPress_Shop()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        //Toolbox.UIManager.Shop_Panel.SetActive(true);
    }

    public void OnPress_UnlockAllLevel()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_AllLevels();
    }

    private void loadAds()
    {
        try
        {
            //if (FindObjectOfType<MediationHandler>())
            //    FindObjectOfType<MediationHandler>().LoadInterstitial(); by uzair
        }

        catch (Exception e)
        {
            //GameAnalytics.NewErrorEvent(GAErrorSeverity.Info, "MediationHandler Not Found!");
        }
    }
    #endregion
    public void SHOWInterstitialIAD()
    {
        if (mediation != null && (PlayerPrefs.GetInt("RemoveAds") != 1))
        {
            mediation.ShowInterstitial();
        }
    }
    public void LoadInterstitial()
    {
        if (mediation != null && (PlayerPrefs.GetInt("RemoveAds") != 1))
        {
            mediation.LoadInterstitial();
        }
    }
}
