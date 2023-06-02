using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardHandler : MonoBehaviour
{
    public Text dailyRewardTimeTxt;
    public GameObject DailrewardPanel;
    // Start is called before the first frame update
    private void OnEnable()
    {
        //if (Toolbox.DB.Prefs.Dailyrewardclaimed)
        //     DailyRewardTxtHandling();
        InitDailyreward();
    }
    private void OnDisable()
    {
      //  StopCoroutine(CR_TimeHandling());
    }
    #region DailyReward Handling 
    public void DailyRewardTxtHandling()
    {

        //if (DateTime.Now >= Toolbox.DB.Prefs.NextDailyRewardTime)
        //{
        //    dailyRewardTimeTxt.text = "Ready";
        //}

        //else
        //{
        //    StartCoroutine(CR_TimeHandling());
        //}
    }

    //IEnumerator CR_TimeHandling()
    //{
    //    while (true)
    //    {
    //        dailyRewardTimeTxt.text = Get_DailyRewardTimeString();
    //        yield return new WaitForSeconds(1);
    //    }
    //}

    //string Get_DailyRewardTimeString()
    //{

    //    TimeSpan diff = Toolbox.DB.Prefs.NextDailyRewardTime - DateTime.Now;
    //    int hours = diff.Hours;
    //    hours += (diff.Days * 24);
    //    return string.Format("{0}H {1}M {2}S", hours, diff.Minutes, diff.Seconds);
    //}

    #endregion

    #region DailyReward
    private void InitDailyreward()
    {
        if (!PlayerPrefs.HasKey(Constants.NextDailyRewardTime))
            return;

        if (DateTime.Now >= DateTime.Parse(Constants.Getprefstring(Constants.NextDailyRewardTime)))
        {
            print("Now: " + DateTime.Now + "NextDailyRewardTime :" + DateTime.Parse(Constants.Getprefstring(Constants.NextDailyRewardTime)));
            DailrewardPanel.SetActive(true);
            DailrewardPanel.GetComponent<DailyRewardListner>().Dailyrewardclaimed = false;
        }
        else
        {
            DailrewardPanel.SetActive(false);
            DailrewardPanel.GetComponent<DailyRewardListner>().Dailyrewardclaimed = true;
            print("Now: " + DateTime.Now + "NextDailyRewardTime :" + DateTime.Parse(Constants.Getprefstring(Constants.NextDailyRewardTime)));
        }
    }
    #endregion
}
