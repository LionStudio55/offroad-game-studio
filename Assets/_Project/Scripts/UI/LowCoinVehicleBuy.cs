using System;
using UnityEngine;

public class LowCoinVehicleBuy : MonoBehaviour
{
    private int curVehicle = 0;

    public int CurVehicle { get => curVehicle; set => curVehicle = value; }

    #region ButtonListners

    public void OnPress_Close()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        this.gameObject.SetActive(false);
    }

    public void OnPress_Unlock()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);

        if (curVehicle < 3)
        {
            //InAppHandler.Instance.Buy_Coins20000();
        }
        else if (curVehicle < 6)
        {
            //InAppHandler.Instance.Buy_Coins30000();
        }
        else
        {
            //    Toolbox.InAppHandler.Buy_Coins40000();
        }

        OnPress_Close();
    }

    public void OnPress_UnlockAll()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);

         InAppHandler.Instance.Buy_AllVehicles();
        //Toolbox.UIManager.Shop_Panel.SetActive(true);
        //Toolbox.GameManager.InstantiateUI_Shop();
        OnPress_Close();
    }
    public void OnPress_Watchvideo()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);

        try
        {
            if (FindObjectOfType<AdmobAdsManager>())
                FindObjectOfType<AdmobAdsManager>().Adbreakloading.SetActive(true);
            if (FindObjectOfType<MediationHandler>())
            {
                if (FindObjectOfType<MediationHandler>().IsRewardedAdReady())
                {
                    FindObjectOfType<MediationHandler>().ShowRewardedVideo(Reward);
                }
                else
                {
                    FindObjectOfType<MediationHandler>().LoadRewardedVideo();
                    Invoke(nameof(Video), 5f);
                }

            }


        }

        catch (Exception e)
        {
        }
    }
   

    private void Video()
    {
        if (FindObjectOfType<AdmobAdsManager>())
            FindObjectOfType<AdmobAdsManager>().Adbreakloading.SetActive(false);
        try
        {
            if (FindObjectOfType<MediationHandler>())
            {
                if (FindObjectOfType<MediationHandler>().IsRewardedAdReady())
                {
                    FindObjectOfType<MediationHandler>().ShowRewardedVideo(Reward);
                }
                else
                {
                    FindObjectOfType<MediationHandler>().LoadRewardedVideo();
                }
            }
        }
        catch (Exception e)
        {
        }
    }

    private void Reward()
    {
        if (FindObjectOfType<AdmobAdsManager>())
            FindObjectOfType<AdmobAdsManager>().Adbreakloading.SetActive(false);
        try
        {
            if (FindObjectOfType<MediationHandler>())
            {
                FindObjectOfType<MediationHandler>().LoadRewardedVideo();
            }
        }
        catch (Exception e)
        {
        }
        Constants.SetPref(Constants.Totalreward, Constants.Getprefs(Constants.Totalreward) + 200);
        if (FindObjectOfType<MainMenuListner>())
            FindObjectOfType<MainMenuListner>().UpdateTxts();
        if (FindObjectOfType<VehicleSelectionListner>())
            FindObjectOfType<VehicleSelectionListner>().Refreshview();
    }
    #endregion
}
