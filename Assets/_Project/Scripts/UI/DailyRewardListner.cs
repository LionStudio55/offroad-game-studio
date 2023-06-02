using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DailyRewardListner : MonoBehaviour
{
    private bool isNextDayVideoReward = false;

    #region DailyReward 
    //[SerializeField] private int dailyRewardDay = 0;
    [SerializeField] private DateTime nextDailyRewardTime;
    [SerializeField] private string dailyRewardTime;
    [SerializeField] private bool dailyrewardclaimed = false;
    #endregion


    public Text coinsTxt;
    public Text Daytext;
    public GameObject nextDayRewardVideoBtn;

    public Transform buttonsParent;
    //public Image dynamicRewardImg1;
    //public GameObject dynamicRewardObj1;
    //public GameObject inPlaceOfDynamicRewardObj1;

    //public Image dynamicRewardImg2;
    //public GameObject dynamicRewardObj2;
    //public GameObject inPlaceOfDynamicRewardObj2;

    //public Image dynamicRewardImg3;
    //public GameObject dynamicRewardObj3;
    //public GameObject inPlaceOfDynamicRewardObj3;

    public GameObject claimBtn;
    public GameObject closeBtn;
    public GameObject Congratspanel;

    private int tileWidth = 347;
    private int tileSpacing = 20;

    //[Tooltip("Will be false if all the items . purchased")]
    //public bool hasDynamicReward = false;

    //[SerializeField] private int dynamicRewardDay1;
    //[SerializeField] private int dynamicRewardDay2;
    //[SerializeField] private int dynamicRewardDay3; //it should be the last day
    //[SerializeField] private int dynamicReward;

    public Sprite[] dynamicRewardImages; // List of all the rewards to be given from the shop ---- first locked item will be shown

    private List<DailyRewardBtnListner> rewardButtons;

    //public int DynamicRewardDay1 { get => dynamicRewardDay1; set => dynamicRewardDay1 = value; }
    //public int DynamicRewardDay2 { get => dynamicRewardDay2; set => dynamicRewardDay2 = value; }
    //public int DynamicRewardDay3 { get => dynamicRewardDay3; set => dynamicRewardDay3 = value; }
    //public int DynamicReward { get => dynamicReward; set => dynamicReward = value; }
    //public int DailyRewardDay { get => dailyRewardDay; set => dailyRewardDay = value; }
    public DateTime NextDailyRewardTime { get => nextDailyRewardTime; set => nextDailyRewardTime = value; }
    public string DailyRewardTime { get => dailyRewardTime; set => dailyRewardTime = value; }
    public bool Dailyrewardclaimed { get => dailyrewardclaimed; set => dailyrewardclaimed = value; }

    private void OnEnable()
    {
        UpdateTxts();
        try
        {

            //if (FindObjectOfType<MediationHandler>())
            //    FindObjectOfType<MediationHandler>().hideSmallBanner(); by uzair
        }
        catch (Exception e)
        {

        }
        if (!PlayerPrefs.HasKey(Constants.NextDailyRewardTime))
        {
            print("FIRST NextDailyRewardTime");
            Constants.SetPrefstring(Constants.NextDailyRewardTime, NextDailyRewardTime.ToString());
            //DailyRewardTime = NextDailyRewardTime.ToString();
        }
        else
        {
            print("nOTFIRST NextDailyRewardTime");
            NextDailyRewardTime = DateTime.Parse(Constants.Getprefstring(Constants.NextDailyRewardTime));
           // DailyRewardTime = NextDailyRewardTime.ToString();
        }
        if (!PlayerPrefs.HasKey(Constants.Dailyrewardclaimed))
        {
            print("FIRST Dailyrewardclaimed");
            Constants.SetBoolpref(Constants.Dailyrewardclaimed, Dailyrewardclaimed);
        }
        else
        {
            print("nOTFIRST Dailyrewardclaimed");
            Dailyrewardclaimed = Constants.GetBoolpref(Constants.Dailyrewardclaimed);
        }
        if (!PlayerPrefs.HasKey(Constants.DailyRewardTime))
        {
            print("FIRST DailyRewardTime");
            Constants.SetPrefstring(Constants.DailyRewardTime, DailyRewardTime.ToString());
        }
        else
        {
            print("nOTFIRST DailyRewardTime");
            DailyRewardTime = Constants.Getprefstring(Constants.DailyRewardTime);
        }

    }

    private void OnDisable()
    {
        // Toolbox.GameManager.Remove_ActiveUI(this.gameObject);

        if (FindObjectOfType<DailyRewardHandler>())
            FindObjectOfType<DailyRewardHandler>().DailyRewardTxtHandling();
        try
        {

            //if (FindObjectOfType<MediationHandler>())
            //    FindObjectOfType<MediationHandler>().ShowSmallBanner(GoogleMobileAds.Api.AdPosition.Top); by uzair
        }
        catch (Exception e)
        {

        }
        Constants.SetPrefstring(Constants.NextDailyRewardTime, NextDailyRewardTime.ToString());
        Constants.SetBoolpref(Constants.Dailyrewardclaimed, Dailyrewardclaimed);
        Constants.SetPrefstring(Constants.DailyRewardTime, DailyRewardTime.ToString());
    }


    private void Start()
    {
        rewardButtons = new List<DailyRewardBtnListner>();

        //if (Toolbox.DB.Prefs.DailyRewardDay > 4) {

        //    buttonsParent.localPosition = new Vector3(
        //        -(Toolbox.DB.Prefs.DailyRewardDay * tileWidth)
        //        - (Toolbox.DB.Prefs.DailyRewardDay * tileSpacing), 0, 0);
        //}


        //print("NextDailyRewardTime :" + Toolbox.DB.Prefs.NextDailyRewardTime);
        Daytext.text = "Day " + Constants.Getprefs(Constants.DailyRewardDay).ToString();
        if (DateTime.Now >= NextDailyRewardTime)
        {
            claimBtn.SetActive(true);
            closeBtn.SetActive(false);

            NoRewardShowHandling();
            print("DateTime Greater");
            //RewardPlayerHandling();
        }
        else
        {
            claimBtn.SetActive(false);
            closeBtn.SetActive(true);
            HandleRewardedVideoBtn();
            print("DateTime Less");
            NoRewardShowHandling();
        }
    }
    public void RewardPlayerHandling()
    {
        //Debug.LogError("Reward");

        HandleRewardedVideoBtn();

        UpdateNextDayRewardTime();

        //HandleDynamicRewardItems();

        RewardPlayer(Constants.Getprefs(Constants.DailyRewardDay));

        IncrementDailyRewardDay();

        UpdateButtons();

        UpdateTxts();
    }

    public void NoRewardShowHandling()
    {

        //Debug.LogError("NO Reward");
        //int day = Toolbox.DB.Prefs.DailyRewardDay;

        //if (Toolbox.DB.Prefs.DailyRewardDay > 0)
        //    Toolbox.DB.Prefs.DailyRewardDay--;

        HandleRewardedVideoBtn();
       // HandleDynamicRewardItems();
        UpdateButtons();
        UpdateTxts();

        //Toolbox.DB.Prefs.DailyRewardDay = day;
    }

    private void HandleRewardedVideoBtn()
    {
        TimeSpan diff = NextDailyRewardTime - DateTime.Now;
        //print("diff :"+ diff + "IsRewardedAdReady :" + AdsManager.Instance.IsRewardedAdReady());
        if ((diff.Days <= 0 && Constants.Getprefs(Constants.DailyRewardDay) < 6) /*&& FindObjectOfType<MediationHandler>().IsRewardedAdReady()*/)
        {
            if (!claimBtn.activeSelf)
                nextDayRewardVideoBtn.SetActive(true);
        }
        else
        {
            nextDayRewardVideoBtn.SetActive(false);
        }
    }

    public void UpdateTxts()
    {
        coinsTxt.text = Constants.Getprefs(Constants.Totalreward).ToString();
        Daytext.text = "Day " +Constants.Getprefs(Constants.DailyRewardDay).ToString();
    }

    //private void HandleDynamicRewardItems()
    //{
    //    try
    //    {
    //        //int lockedItemIndex = Toolbox.DB.Prefs.GetLockedItemIndex(1);
    //        int lockedItemIndex = Constants.Firstdynamicreward;
    //        //print("lockedItemIndex :" + lockedItemIndex);
    //        // int secondLockedItemIndex = Toolbox.DB.Prefs.GetLockedItemIndex(6);
    //        int secondLockedItemIndex = Constants.Seconndynamicreward; ;
    //        //print("secondLockedItemIndex :"+ secondLockedItemIndex);

    //        //int thirdLockedItemIndex = Toolbox.DB.Prefs.GetLockedItemIndex(3);
    //        int thirdLockedItemIndex = Constants.Thirddynamicreward; ;
    //        //print("secondLockedItemIndex :" + thirdLockedItemIndex);

    //        if (!Constants.AreAllGunsUnlocked() | Constants.AreAllGunsUnlocked()/*&& lockedItemIndex >= 0*/)
    //        {
    //            hasDynamicReward = true;

    //            if (DailyRewardDay >= DynamicRewardDay1)
    //            {
    //                dynamicRewardImg1.sprite = dynamicRewardImages[lockedItemIndex];
    //                DynamicReward = Constants.Firstdynamicreward;
    //                //secondLockedItemIndex = Toolbox.DB.Prefs.GetLockedItemIndex(1);
    //                //print("DynamicRewardDay1");
    //            }
    //            else
    //            {
    //                DynamicDailyRewardItemNumber1 = lockedItemIndex;
    //                dynamicRewardImg1.sprite = dynamicRewardImages[lockedItemIndex];
    //                //print("DynamicRewardDay1 :"+ lockedItemIndex);
    //            }

    //            dynamicRewardObj1.SetActive(true);
    //            inPlaceOfDynamicRewardObj1.SetActive(false);

    //            if (DailyRewardDay >= DynamicRewardDay2)
    //            {
    //                dynamicRewardImg2.sprite = dynamicRewardImages[secondLockedItemIndex];
    //                DynamicReward = Constants.Seconndynamicreward;
    //                //secondLockedItemIndex = Toolbox.DB.Prefs.GetLockedItemIndex(2);
    //                // print("DynamicRewardDay2");
    //            }
    //            else
    //            {
    //                DynamicDailyRewardItemNumber1 = secondLockedItemIndex;
    //                dynamicRewardImg2.sprite = dynamicRewardImages[secondLockedItemIndex];
    //                //print("DynamicRewardDay2 :" + secondLockedItemIndex);
    //            }

    //            dynamicRewardObj2.SetActive(true);
    //            inPlaceOfDynamicRewardObj2.SetActive(false);

    //            //Handling of second dynamic item. To make this code work 2nd dynamic item should always be the last item - Otherwise add code handling like item 1

    //            if (DailyRewardDay >= DynamicRewardDay3)
    //            {
    //                dynamicRewardImg3.sprite = dynamicRewardImages[thirdLockedItemIndex];
    //                DynamicReward = Constants.Thirddynamicreward;
    //                //secondLockedItemIndex = Toolbox.DB.Prefs.GetLockedItemIndex(2);
    //                //print("DynamicRewardDay3");
    //            }
    //            else
    //            {
    //                DynamicDailyRewardItemNumber1 = thirdLockedItemIndex;
    //                dynamicRewardImg3.sprite = dynamicRewardImages[thirdLockedItemIndex];
    //                //print("DynamicRewardDay3 :" + thirdLockedItemIndex);
    //            }
    //            dynamicRewardObj3.SetActive(true);
    //            inPlaceOfDynamicRewardObj3.SetActive(false);

    //            //if (thirdLockedItemIndex >= 0)
    //            //{
    //            //    if (Toolbox.DB.Prefs.DailyRewardDay < DynamicRewardDay3)
    //            //        dynamicRewardImg3.sprite = dynamicRewardImages[thirdLockedItemIndex];
    //            //    DynamicReward = Constants.Thirddynamicreward;
    //            //    print("DynamicRewardDay3 :" + thirdLockedItemIndex);
    //            //    dynamicRewardObj3.SetActive(true);
    //            //    inPlaceOfDynamicRewardObj3.SetActive(false);
    //            //}
    //            //else
    //            //{
    //            //    dynamicRewardObj3.SetActive(false);
    //            //    inPlaceOfDynamicRewardObj3.SetActive(true);
    //            //}
    //        }
    //        else
    //        { //No Item in shop is availble --- All items are bought

    //            //if (Toolbox.DB.Prefs.DailyRewardDay >= DynamicRewardDay1)
    //            //{
    //            //    dynamicRewardImg1.sprite = dynamicRewardImages[Toolbox.DB.Prefs.DynamicDailyRewardItemNumber1];
    //            //    secondLockedItemIndex = Toolbox.DB.Prefs.GetLockedItemIndex(1);
    //            //}
    //            //else
    //            //{
    //            //    dynamicRewardObj1.SetActive(false);
    //            //    inPlaceOfDynamicRewardObj1.SetActive(true);
    //            //}

    //            //dynamicRewardObj2.SetActive(false);
    //            //inPlaceOfDynamicRewardObj2.SetActive(true);

    //            hasDynamicReward = false;
    //        }

    //        //handle case if all is unlocked and day is greater than 1st dynamic reward day
    //        //if (Toolbox.DB.Prefs.DynamicDailyRewardItemNumber1 >= 0)
    //        //{

    //        //    dynamicRewardImg1.sprite = dynamicRewardImages[Toolbox.DB.Prefs.DynamicDailyRewardItemNumber1];

    //        //    dynamicRewardObj1.SetActive(true);
    //        //    inPlaceOfDynamicRewardObj1.SetActive(false);
    //        //}
    //    }
    //    catch (Exception ex)
    //    {

    //    }

    //}

    void UpdateButtons()
    {
        try
        {
            for (int i = 0; i < buttonsParent.childCount; i++)
            {
                DailyRewardBtnListner btn = buttonsParent.GetChild(i).GetComponent<DailyRewardBtnListner>();
                btn.Daytxt.text = "Day "+ (i + 1).ToString();
               // btn.Render.sprite = dynamicRewardImages[i];
               // btn.Render.SetNativeSize();
                if (i < Constants.Getprefs(Constants.DailyRewardDay))
                {
                    //Toolbox.GameManager.Log("LESS_Button = " + i + "DR = " + Toolbox.DB.prefs.DailyRewardDay);

                    //btn.coinsTxt.text = Constants.dailyReward[i].ToString() + "CASH";
                    //btn.GetComponent<UIShiny>().enabled = false;
                    btn.Hover.SetActive(false);
                    btn.gameObject.GetComponent<Button>().interactable = false;
                    btn.GetComponent<UIAnimatorCore.UIAnimator>().enabled = false;
                    Debug.Log("Less");
                }
                else if (i == Constants.Getprefs(Constants.DailyRewardDay) /*&& claimBtn.activeSelf*/)
                {

                    //if (!btn.IsDynamicRewrad)
                    //    btn.coinsTxt.text = Constants.dailyReward[i].ToString() + "CASH";
                    btn.GetComponent<UIAnimatorCore.UIAnimator>().enabled = true;
                    btn.Hover.SetActive(true);
                    btn.gameObject.GetComponent<Button>().interactable = true;
                    Debug.Log("Equal");
                }
                else
                {


                    //if (!btn.IsDynamicRewrad)
                    //    btn.coinsTxt.text = Constants.dailyReward[i].ToString() + "CASH";
                    btn.Hover.SetActive(false);
                    btn.GetComponent<UIAnimatorCore.UIAnimator>().enabled = false;
                    btn.gameObject.GetComponent<Button>().interactable = false;
                    Debug.Log("More");
                }

                rewardButtons.Add(btn);
            }
        }
        catch (Exception ex)
        {

        }

    }

    void IncrementDailyRewardDay()
    {
        //If it is the last day of the week
        if (Constants.Getprefs(Constants.DailyRewardDay) + 1 > Constants.dailyReward.Length - 1)
        {
            Constants.SetPref(Constants.DailyRewardDay,0);
           
        }
        else
        {
            Constants.SetPref(Constants.DailyRewardDay, Constants.Getprefs(Constants.DailyRewardDay) + 1);
            //DailyRewardDay++;
            //print("DailyRewardDay :" + Toolbox.DB.Prefs.DailyRewardDay);
        }
    }

    void UpdateNextDayRewardTime()
    {

        if (isNextDayVideoReward)
        {
            DateTime tempTIme = NextDailyRewardTime;
            //tempTIme = tempTIme.AddDays(1);
            NextDailyRewardTime = tempTIme;
            isNextDayVideoReward = false;

            Debug.Log("Next Day Reward Video. TIME = " + NextDailyRewardTime);
        }
        else
        {
            NextDailyRewardTime = DateTime.Now.AddDays(1);
        }

        //Toolbox.GameManager.ScheduleDailyRewardNotification();
    }

    public void RewardPlayer(int _day)
    {
        
        if (isDynamicRewardDay(_day) )
        {
            //print("Give Reward To User :"+ DynamicReward);
            int DynamicReward = Constants.dailyRewardDynamic[_day];
            Constants.SpecificGun(DynamicReward);
            //Toolbox.DB.PrefVehiclesUnlocked[DynamicReward] = true;

        }
        else
        {
             int reward = Constants.dailyReward[_day];
            Constants.SetPref(Constants.Totalreward,Constants.Getprefs(Constants.Totalreward)+reward);
           // Toolbox.DB.Prefs.GoldCoins += Constants.dailyReward[_day];

        }
        Congratspanel.SetActive(true);
        if (Congratspanel.GetComponent<MessageListner>())
        {
            Congratspanel.GetComponent<MessageListner>().UpdateTxt("YOU HAVE RECEIVED THE DAILY REWARD "+ buttonsParent.GetChild(_day).GetComponent<DailyRewardBtnListner>().Reward.text, "CONGRATULATIONS");
            Congratspanel.GetComponent<MessageListner>().set_statuspanel();
        }
    }

    IEnumerator CR_ShowMessageAfterDelay(string _str, string str, bool showCoins)
    {

        yield return new WaitForSeconds(0.5f);

     //   Toolbox.GameManager.Instantiate_Message(_str, str);

    }

    bool isDynamicRewardDay(int _day)
    {

        for (int i = 0; i < buttonsParent.childCount; i++)
        {
            DailyRewardBtnListner btn = buttonsParent.GetChild(i).GetComponent<DailyRewardBtnListner>();
            if (i == _day)
                if (btn.IsDynamicRewrad)
                    return true;
        }
        return false;
    }

    public void OnPress_Close()
    {

        this.gameObject.SetActive(false);
    }

    public void OnPress_Shop()
    {

        //Toolbox.GameManager.InstantiateUI_Shop();
        OnPress_Close();
    }

    public void OnPress_WatchVideo()
    {

        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);

        // comment by uzair
        //if (FindObjectOfType<MediationHandler>().IsRewardedAdReady())
        //{
        //    isNextDayVideoReward = true;
        //    nextDayRewardVideoBtn.SetActive(false);

        //    if (FindObjectOfType<MediationHandler>())
        //        FindObjectOfType<MediationHandler>().ShowRewardedVideo(OnPress_Claim);
        //}
        //else
        //{

        // //   Toolbox.GameManager.ShowMessage("Rewarded Ad not available. Please try again later.", "Message");
        //}
    }

    public void OnPress_Claim()
    {
        //Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.dailyrewardVocalSoundEffect);
        //Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.CheckPoint);

        NextDailyRewardTime = DateTime.Now.AddDays(1);
        Constants.SetPrefstring(Constants.NextDailyRewardTime, NextDailyRewardTime.ToString());
        Constants.SetPrefstring(Constants.DailyRewardTime, Constants.Getprefstring(Constants.NextDailyRewardTime));

        DailyRewardTime = NextDailyRewardTime.ToString();
        Dailyrewardclaimed = true;
        Constants.SetBoolpref(Constants.Dailyrewardclaimed, Dailyrewardclaimed);

        claimBtn.SetActive(false);
        closeBtn.SetActive(true);
        HandleRewardedVideoBtn();
        RewardPlayerHandling();
       // Menu_Manager.instance.updatestats(); 
        
    }
    public void On_Presswatchvideo2xreward()
    {
        try
        {
          
            //if (FindObjectOfType<MediationHandler>())
            //    FindObjectOfType<MediationHandler>().ShowRewardedVideo(Reward200); by uzair
        }
        catch (Exception e)
        {

        }
    }
    private void Reward200()
    {
        Constants.SetPref(Constants.Totalreward, Constants.Getprefs(Constants.Totalreward)+200);
       // Menu_Manager.instance.updatestats();
    }
}
