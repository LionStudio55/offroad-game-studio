using System;
using UIAnimatorCore;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Mode_Selection : MonoBehaviour
{
    MediationHandler mediation;

    public bool[] ModesUnlocked;
    public int[] NoofwatchvideoforUnlockvideo;
    public Text Coinstext;
    public Text daimondTxt;
    public GameObject[] Modebtn;
    public GameObject[] Hover;
    public GameObject[] locks;
    public GameObject[] WatchVideo;
    public Text[] VideosText;
    public Text[] ModesTotalLevel;
    public GameObject UnlockAllModesBtn;
    public GameObject UnlockAllEverythingInapps;

    private void OnEnable()
    {
       
        if (!PlayerPrefs.HasKey("ModesUnlocked"))
        {
          //  print("FIRST");
            PlayerPrefsX.SetBoolArray("ModesUnlocked", ModesUnlocked);
        }
        else
        {
           // print("nOTFIRST");
            ModesUnlocked = PlayerPrefsX.GetBoolArray("ModesUnlocked");
        }
       // ModesUnlockstatus();
        Updatestats();
        //  Invoke(nameof(Megaoffer),1f);
        LoadInterstitial();
    }
    private void Start()
    {
        mediation = FindObjectOfType<MediationHandler>();
    }
    private void Megaoffer()
    {
        if (AreAllModesUnlocked())
            UnlockAllEverythingInapps.SetActive(false);
        else
            UnlockAllEverythingInapps.SetActive(true);
        CancelInvoke(nameof(Megaoffer));
    }
    private void OnDisable()
    {
        PlayerPrefsX.SetBoolArray("ModesUnlocked", ModesUnlocked);
    }
    public void Updatestats()
    {
        ModesUnlocked = PlayerPrefsX.GetBoolArray("ModesUnlocked");
        Coinstext.text = Constants.Getprefs(Constants.Totalreward).ToString();
        daimondTxt.text = Constants.Getprefs(Constants.Daimond).ToString();
        InitGunsButtonsState();
        Hover[Constants.Getprefs(Constants.lastselectedMode)].SetActive(true);
        //if (AreAllModesUnlocked())
        //    UnlockAllModesBtn.SetActive(false);
        //else
        //    UnlockAllModesBtn.SetActive(true);


    }
    
    private void InitGunsButtonsState()
    {

        bool watchVideoBtnEnabled = false;
        int GunUnlocked = Get_LastUnlockedMode();
        Debug.Log("InitLevelButtonsState");
        for (int i = 0; i < ModesUnlocked.Length; i++)
        {
            Modebtn[i].gameObject.SetActive(true);

            ModesTotalLevel[i].text = "Lvl " + Constants.TotallevelofMode[i].ToString();
            //Watch video Btn for Unlock Next Level
            //if (!watchVideoBtnEnabled && !ModesUnlocked[i])
            //{
            //    WatchVideo[i].SetActive(true);
            //    VideosText[i].text = "watch " + (NoofwatchvideoforUnlockvideo[i] - Constants.Getprefs(Constants.Totalvideoswatched)) + " video to Unlock this MODE ";
            //    print("TryWeapon :"+i);
            //    watchVideoBtnEnabled = true;
            //}
            //else
            //    WatchVideo[i].SetActive(false);

            if (ModesUnlocked[i])
            {
                Hover[i].SetActive(false);
                locks[i].SetActive(false);
               // Modebtn[i].GetComponent<UIAnimator>().enabled = true;
               
            }
           
            else
            {
                Hover[i].SetActive(false);
                locks[i].SetActive(true);
                //Modebtn[i].GetComponent<UIAnimator>().enabled = false;
            }
        }
       
    }
    public void ModesUnlockstatus()
    {

        if (Constants.Getprefs(Constants.lastselectedMode) == 0 && (Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)) >= 4 && Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode))<14) && Constants.Getprefs(Constants.Mode2Unlock) == 0)
        {
           
            locks[1].SetActive(false);
            ModesUnlocked[1] = true;
            Constants.SetPref(Constants.lastselectedMode, Get_LastUnlockedMode());
            PlayerPrefsX.SetBoolArray("ModesUnlocked", ModesUnlocked);
            print("Mode Unlock Second");
            //Updatestats();
            Constants.SetPref(Constants.Mode2Unlock, 1);
            UIManager.Instance.MessagePopup.SetActive(true);
            UIManager.Instance.MessagePopup.GetComponent<MessageListner>().UpdateTxt("Congratulations your Second Mode Unlock Enjoy with This Fantasic Mode ", "Congratulations");
            UIManager.Instance.MessagePopup.GetComponent<MessageListner>().set_statuspanel();

        }
        else if (Constants.Getprefs(Constants.lastselectedMode) == 1 && Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)) >= 4 && Constants.Getprefs(Constants.Mode3Unlock) == 0)
        {
            
            locks[2].SetActive(false);
            ModesUnlocked[2/*Get_LastlockedMode()*/] = true;
            Constants.SetPref(Constants.lastselectedMode, Get_LastUnlockedMode());
            PlayerPrefsX.SetBoolArray("ModesUnlocked", ModesUnlocked);
            print("Mode Unlock Third");
           // Updatestats();
            Constants.SetPref(Constants.Mode2Unlock, 1);
            Constants.SetPref(Constants.Mode3Unlock, 1);
            UIManager.Instance.MessagePopup.SetActive(true);
            UIManager.Instance.MessagePopup.GetComponent<MessageListner>().UpdateTxt("Congratulations your Third Mode Unlock Enjoy with This Fantasic Mode ", "Congratulations");
            UIManager.Instance.MessagePopup.GetComponent<MessageListner>().set_statuspanel();
        }

         else if (Constants.Getprefs(Constants.lastselectedMode) == 1 && (Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)) >= 9 && Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)) < 19) && Constants.Getprefs(Constants.Mode4Unlock) == 0)
        {
           
            locks[3/*Get_LastlockedMode()*/].SetActive(false);
            ModesUnlocked[3/*Get_LastlockedMode()*/] = true;
            Constants.SetPref(Constants.lastselectedMode, Get_LastUnlockedMode());
            PlayerPrefsX.SetBoolArray("ModesUnlocked", ModesUnlocked);
            print("Mode Unlock Fourth");
           // Updatestats();
            //Constants.SetPref(Constants.Mode2Unlock, 1);
            //Constants.SetPref(Constants.Mode3Unlock, 1);
            Constants.SetPref(Constants.Mode4Unlock, 1);
            UIManager.Instance.MessagePopup.SetActive(true);
            UIManager.Instance.MessagePopup.GetComponent<MessageListner>().UpdateTxt("Congratulations your Fourth Mode Unlock Enjoy with This Fantasic Mode ", "Congratulations");
            UIManager.Instance.MessagePopup.GetComponent<MessageListner>().set_statuspanel();
        }
         else if (Constants.Getprefs(Constants.lastselectedMode) == 3 && Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)) >= 4 && Constants.Getprefs(Constants.Mode5Unlock) == 0)
        {
            locks[1].SetActive(false);
            ModesUnlocked[1] = true;
            locks[3/*Get_LastlockedMode()*/].SetActive(false);
            ModesUnlocked[3/*Get_LastlockedMode()*/] = true;
            locks[4].SetActive(false);
            ModesUnlocked[4] = true;
            Constants.SetPref(Constants.lastselectedMode, Get_LastUnlockedMode());
            PlayerPrefsX.SetBoolArray("ModesUnlocked", ModesUnlocked);
            print("Mode Unlock Fifth");
           // Updatestats();
            //Constants.SetPref(Constants.Mode2Unlock, 1);
            //Constants.SetPref(Constants.Mode3Unlock, 1);
            Constants.SetPref(Constants.Mode4Unlock, 1);
            Constants.SetPref(Constants.Mode5Unlock, 1);

            UIManager.Instance.MessagePopup.SetActive(true);
            UIManager.Instance.MessagePopup.GetComponent<MessageListner>().UpdateTxt("Congratulations your Fifth Mode Unlock Enjoy with This Fantasic Mode ", "Congratulations");
            UIManager.Instance.MessagePopup.GetComponent<MessageListner>().set_statuspanel();
        }

        if (Constants.Getprefs(Constants.Mode2Unlock) == 1)
        {
            locks[1].SetActive(false);
        }
        if (Constants.Getprefs(Constants.Mode3Unlock) == 1)
        {
            locks[2].SetActive(false);
        }
        if (Constants.Getprefs(Constants.Mode4Unlock) == 1)
        {
            locks[3].SetActive(false);
        }
        if (Constants.Getprefs(Constants.Mode5Unlock) == 1)
        {
            print("Mode Unlock Fifth");
            locks[4].SetActive(false);
        }
        Updatestats();
    }

    public bool AreAllModesUnlocked()
    {
        for (int i = 0; i < ModesUnlocked.Length; i++)
        {
            if (!ModesUnlocked[i])
            {

                //Debug.LogError("All vehicles --NOT-- unlocked");
                return false;
            }

        }
        //Debug.LogError("All vehicles are unlocked");
        return true;
    }

    public int Get_LastUnlockedMode()
    {
        for (int i = 0; i < ModesUnlocked.Length; i++)
        {
            if (!ModesUnlocked[i])
            {
                return i-1 ;
            }
        }
        return ModesUnlocked.Length - 1;
    }

    public int Get_LastlockedMode()
    {
        for (int i = 0; i < ModesUnlocked.Length; i++)
        {
                //print("i" +i);
            if (!ModesUnlocked[i])
            {
                return i;
            }
        }
        return ModesUnlocked.Length - 1;
    }

    //Unlock By watch Videos
    private void Modesunlock()
    {
        Constants.SetPref(Constants.Totalvideoswatched, Constants.Getprefs(Constants.Totalvideoswatched) + 1);
        print("NoofwatchvideoforUnlockvideo :" + (NoofwatchvideoforUnlockvideo[Get_LastlockedMode()]) + " Totalvideoswatched :" + Constants.Getprefs(Constants.Totalvideoswatched));
        VideosText[Get_LastlockedMode()].text = "watch "+ (NoofwatchvideoforUnlockvideo[Get_LastlockedMode()]- Constants.Getprefs(Constants.Totalvideoswatched)) + " video to Unlock this MODE ";

        if (Constants.Getprefs(Constants.Totalvideoswatched) >= NoofwatchvideoforUnlockvideo[Get_LastlockedMode()])
        {
            print("UnlockModesAferwatchVideos");
            if (Get_LastlockedMode() == 1 && Constants.Getprefs(Constants.Mode2Unlock) == 0)
            {
                Constants.SetPref(Constants.Mode2Unlock, 1);
                UIManager.Instance.MessagePopup.SetActive(true);
                UIManager.Instance.MessagePopup.GetComponent<MessageListner>().UpdateTxt("Congratulations your Second Mode Unlock Enjoy with This Fantasic Mode ", "Congratulations");
                UIManager.Instance.MessagePopup.GetComponent<MessageListner>().set_statuspanel();
            }
            if (Get_LastlockedMode() == 2 && Constants.Getprefs(Constants.Mode3Unlock) == 0)
            {
                Constants.SetPref(Constants.Mode3Unlock, 1);
                UIManager.Instance.MessagePopup.SetActive(true);
                UIManager.Instance.MessagePopup.GetComponent<MessageListner>().UpdateTxt("Congratulations your Third Mode Unlock Enjoy with This Fantasic Mode ", "Congratulations");
                UIManager.Instance.MessagePopup.GetComponent<MessageListner>().set_statuspanel();
            }

            if (Get_LastlockedMode() == 3 && Constants.Getprefs(Constants.Mode4Unlock) == 0)
            {
                Constants.SetPref(Constants.Mode4Unlock, 1);
                UIManager.Instance.MessagePopup.SetActive(true);
                UIManager.Instance.MessagePopup.GetComponent<MessageListner>().UpdateTxt("Congratulations your Fourth Mode Unlock Enjoy with This Fantasic Mode ", "Congratulations");
                UIManager.Instance.MessagePopup.GetComponent<MessageListner>().set_statuspanel();
            }
            if (Get_LastlockedMode() == 4 && Constants.Getprefs(Constants.Mode5Unlock) == 0)
            {
                Constants.SetPref(Constants.Mode5Unlock, 1);
                UIManager.Instance.MessagePopup.SetActive(true);
                UIManager.Instance.MessagePopup.GetComponent<MessageListner>().UpdateTxt("Congratulations your Fifth Mode Unlock Enjoy with This Fantasic Mode ", "Congratulations");
                UIManager.Instance.MessagePopup.GetComponent<MessageListner>().set_statuspanel();
            }
            Constants.SetPref(Constants.Totalvideoswatched,0);
            locks[Get_LastlockedMode()].SetActive(false);
            ModesUnlocked[Get_LastlockedMode()] = true;
            Constants.SetPref(Constants.lastselectedMode, Get_LastUnlockedMode());
            PlayerPrefsX.SetBoolArray("ModesUnlocked", ModesUnlocked);
            Updatestats();
        }
        
    }
    #region button Press
    public void DisplayMsg(int Mode_)
    {
        if (Mode_ == 1)
        {
            UIManager.Instance.MessagePopup.SetActive(true);
            // UIManager.Instance.MessagePopup.GetComponent<MessageListner>().UpdateTxt("Unlock After " + /*lvlNo*/ "5"+ " Levels of First Mode", "Message");
            UIManager.Instance.MessagePopup.GetComponent<MessageListner>().UpdateTxt("This mode Now Lock Please complete Levels of Previous Mode", "Message");
            UIManager.Instance.MessagePopup.GetComponent<MessageListner>().set_statuspanel();
        }
        else if (Mode_ == 2)
        {
            UIManager.Instance.MessagePopup.SetActive(true);
            //UIManager.Instance.MessagePopup.GetComponent<MessageListner>().UpdateTxt("Unlock After " + /*lvlNo*/ "5" + " Levels of Second Mode", "Message");
            UIManager.Instance.MessagePopup.GetComponent<MessageListner>().UpdateTxt("This mode Now Lock Please complete Levels of Previous Mode", "Message");
            UIManager.Instance.MessagePopup.GetComponent<MessageListner>().set_statuspanel();
        }
        else if (Mode_ == 3)
        {
            UIManager.Instance.MessagePopup.SetActive(true);
            //  UIManager.Instance.MessagePopup.GetComponent<MessageListner>().UpdateTxt("Unlock After " + /*lvlNo*/ "10" + " Levels of Second Mode", "Message");
            UIManager.Instance.MessagePopup.GetComponent<MessageListner>().UpdateTxt("This mode Now Lock Please complete Levels of Previous Mode", "Message");
            UIManager.Instance.MessagePopup.GetComponent<MessageListner>().set_statuspanel();
        }
        else if (Mode_ == 4)
        {
            UIManager.Instance.MessagePopup.SetActive(true);
            //UIManager.Instance.MessagePopup.GetComponent<MessageListner>().UpdateTxt("Unlock After " + /*lvlNo*/ "5" + " Levels of Fourth Mode", "Message");
            UIManager.Instance.MessagePopup.GetComponent<MessageListner>().UpdateTxt("This mode Now Lock Please complete Levels of Previous Mode", "Message");
            UIManager.Instance.MessagePopup.GetComponent<MessageListner>().set_statuspanel();
        }
        //messagePanel.SetActive(true);
        //messagePanel.GetComponent<MessageListner>().UpdateTxt("Unlock After " + lvlNo + " Levels of First Mode", "Message");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }

    public void Selected_Mode(int index)
    {
      
        Constants.SetPref(Constants.lastselectedMode, index);
        for (int i = 0; i < Modebtn.Length; i++)
        {
          //  Modebtn[i].GetComponent<UIAnimator>().enabled = false;
            Hover[i].gameObject.SetActive(false);
        }
     //   Modebtn[index].GetComponent<UIAnimator>().enabled = true;
        Hover[index].gameObject.SetActive(true);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);


        //if (index == 2)
        //{
        //   // Envselection.SetActive(true);
        //   // Modeselection.SetActive(false);
        //}
        //else
        //{
        // Invoke(nameof(Level_selection),5.5f);
        //    UIManager.Instance.UIDummy_Loading.SetActive(true);
        //}
        Invoke(nameof(Level_selection), 5.5f);
        UIManager.Instance.UIDummy_Loading.SetActive(true);
        IAD();
        Constants.FBAnalytic_EventDesign("Selected_Mode_" + Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)).ToString());
    }
    private void Level_selection()
    {
       // print("Level_selection");
        UIManager.Instance.UIDummy_Loading.SetActive(false);
        UIManager.Instance.ShowNextUI();
    }
    public void Loadscene()
    {
        SceneManager.LoadScene(2);
    }
    private void IAD()
    {
        try
        {
            //if (FindObjectOfType<MediationHandler>())
            //    FindObjectOfType<MediationHandler>().ShowInterstitial(); by uzair
        }
        catch (Exception e)
        {
        }
    }

    public void On_presswatchvideoModesUnlock()
    {

        try
        {
            //if (FindObjectOfType<MediationHandler>())
            //    FindObjectOfType<MediationHandler>().ShowRewardedVideo(Modesunlock); by uzair
        }
        catch (Exception e)
        {
        }
    }

    public void UnlockAllModes()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);

        InAppHandler.Instance.Buy_AllModes();
    }
    public void Mega_offer()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        InAppHandler.Instance.Buy_MegaOffer();
    }

    public void On_PressBack()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        UIManager.Instance.ShowPrevUI();
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
        if (mediation != null)
        {
            if (!mediation.IsInterstitialAdReady())
                mediation.LoadInterstitial();
        }
    }
}
