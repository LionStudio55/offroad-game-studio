using UnityEngine;
using UnityEngine.UI;


public class LevelButtonListner : MonoBehaviour
{

    public Text levelNoTxt;
    //public Text rewardslevelTxt;
    //public GameObject rewardbar;
    public GameObject Hover;
    //public GameObject Levelselected;
    //public Image Render;

    public GameObject watchVideoUnlockBtn;
    public GameObject lockObj;
    //public Text LevelName;
    //public GameObject IndicatorArrow;
    //public GameObject PlayedState;
    //public GameObject NewLevel;
    //public GameObject[] stars;

    //public void Stars_Status(bool _val, int _enabledStars)
    //{
    //    starsParent.SetActive(_val);

    //    if (_val) {

    //        for (int i = 0; i < _enabledStars; i++)
    //        {
    //            stars[i].SetActive(true);
    //        }
    //    }
    //}

    public void Lock_Status(bool _val)
    {

        lockObj.SetActive(_val);
    }

    public void Hover_status(bool _val)
    {
        Hover.SetActive(_val);
        //if (Hover.GetComponent<RotateAlways>())
        //{
        //    Hover.SetActive(_val);
        //    Hover.GetComponent<RotateAlways>().enabled = _val;
        //}
    }
    public void set_LevelName(string _Val, Color clr)
    {
        // LevelName.text = _Val.ToString();
        // LevelName.color = clr;
    }
    public void Set_LevleNameTxt(int _val/*, Color clr*/)
    {
        levelNoTxt.text =/*"LEVEL " +*/_val.ToString();
        //levelNoTxt.color = clr;
    }
    //public void Set_LevelrewardstatusTxt(int reward)
    //{
    //    rewardslevelTxt.text = reward.ToString();
    //}

    //public void check_OutlineStatus(bool _val)
    //{
    //    Levelselected.SetActive(_val);
    //}

    public void Set_NewArrow(bool _Val)
    {
        //if (Toolbox.DB.Prefs.Tutorialshowfirsttime)
        //    IndicatorArrow.SetActive(_Val);
        //else
        //    IndicatorArrow.SetActive(false);
    }

    public void WatchVideoUnlock_Status(bool _val)
    {
        //if (_val)
        //    rewardbar.SetActive(false);
        watchVideoUnlockBtn.SetActive(_val);
    }

    #region ButtonListners

    public void OnPress_LevelButton(GameObject _buttonTransform)
    {
        //  Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        this.GetComponentInParent<LevelSelectionListner>().OnPress_LevelButton(_buttonTransform);

    }

    public void OnPress_LevelLockButton(GameObject _buttonTransform)
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        this.GetComponentInParent<LevelSelectionListner>().Levellock();
       
    }
    public void OnPress_watchVideoUnlockLevel()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        //if (FindObjectOfType<AbstractAdsmanager>())
        //{
        //    if (FindObjectOfType<AbstractAdsmanager>().IsRewardedAdReady())
        //        FindObjectOfType<AbstractAdsmanager>().ShowRewardedVideo(RewardType.UNLOCK_NEXT_Level);
        //    else
        //    {
        //        Toolbox.UIManager.MessagePopup.SetActive(true);
        //        Toolbox.UIManager.MessagePopup.GetComponent<MessageListner>().UpdateTxt("Video Not Loaded right Now.Please try Again .", "VIDEO AVAILABILITY");
        //    }
        //}
    }
    #endregion

}
