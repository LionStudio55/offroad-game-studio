using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class SettingsListner : MonoBehaviour
{
    public Slider soundSlider;
    public Slider musicSlider;
    public Text versionTxt;
    public List<GameObject> ControlsHover;
    private void OnEnable()
    {
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        versionTxt.text = "V" + Application.version;
        try
        {
            //if (FindObjectOfType<MediationHandler>())
            //{
            //    FindObjectOfType<MediationHandler>().ShowMediumBanner(GoogleMobileAds.Api.AdPosition.BottomLeft); by uzair
            //}
        }
        catch (Exception e)
        {
        }
        // set_StatusControls();
    }

    private void OnDisable()
    {
        try
        {
            //if (FindObjectOfType<MediationHandler>())
            //{
            //    FindObjectOfType<MediationHandler>().hideMediumBanner(); by uzair
            //}
        }
        catch (Exception e)
        {
        }
    }

    //private void Start()
    //{
    //}


    #region ButtonListners

    //public void OnPress_Music(bool _val)
    //{
    //    Toolbox.Soundmanager.Set_MusicStatus(_val);
    //}
    //public void OnPress_Sound(bool _val)
    //{
    //    Toolbox.Soundmanager.Set_SoundStatus(_val);
    //}

    public void OnSoundSliderValueChange(float _val)
    {

        SoundsManager.Instance.Set_SoundVolume(_val);
       
    }

    public void OnMusicSliderValueChange(float _val)
    {
        SoundsManager.Instance.Set_MusicVolume(_val);
      
    }
    #endregion

    #region GFX
    public void OnPress_Low()
    {
        //Toolbox.GameManager.FBAnalytic_EventDesign("OnPress_Low");
        //Toolbox.GameManager.Analytics_DesignEvent("OnPress_Low");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        QualitySettings.SetQualityLevel(0,true);
      
    //    Destroy(this.gameObject);
    }
    public void OnPress_Medium()
    {
        //Toolbox.GameManager.FBAnalytic_EventDesign("OnPress_Medium");
        //Toolbox.GameManager.Analytics_DesignEvent("OnPress_Medium");

        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        QualitySettings.SetQualityLevel(1,true);
      
       
   //    Destroy(this.gameObject);
    }
    public void OnPress_High()
    {
        //Toolbox.GameManager.FBAnalytic_EventDesign("OnPress_High");
        //Toolbox.GameManager.Analytics_DesignEvent("OnPress_High");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        QualitySettings.SetQualityLevel(2,true);
      
    //    Destroy(this.gameObject);
    }

    #endregion

    #region Controls 

    public void set_StatusControls()
    {
        foreach (GameObject g in ControlsHover)
            g.SetActive(false);

        switch (Constants.SelectedControltype)
        {
            case Controls.Touch:
                ControlsHover[0].SetActive(true);
                break;
            case Controls.steering:
                ControlsHover[1].SetActive(true);
                break;
            case Controls.Gyro:
                ControlsHover[2].SetActive(true);
                break;
            default:
                ControlsHover[0].SetActive(true);
                break;
        }
    }
    public void touchControls()
    {
        Constants.SelectedControltype = Controls.Touch;
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        //foreach (GameObject g in ControlsHover)
        //    g.SetActive(false);
        //ControlsHover[0].SetActive(true);
        if (FindObjectOfType<HUDListner>())
            FindObjectOfType<HUDListner>().check_statuscontrols();
    }
    public void SteeringControls()
    {
        Constants.SelectedControltype = Controls.steering;
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        //foreach (GameObject g in ControlsHover)
        //    g.SetActive(false);
        //ControlsHover[1].SetActive(true);
        if (FindObjectOfType<HUDListner>())
            FindObjectOfType<HUDListner>().check_statuscontrols();
    }
    public void JyroControls()
    {
        Constants.SelectedControltype = Controls.Gyro;
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        //foreach (GameObject g in ControlsHover)
        //    g.SetActive(false);
        //ControlsHover[2].SetActive(true);
        if (FindObjectOfType<HUDListner>())
            FindObjectOfType<HUDListner>().check_statuscontrols();
    }
    //#endregion
    public void OnPress_Close()
    {
        //Toolbox.GameManager.FBAnalytic_EventDesign("Settings_Press_Close");
        //Toolbox.GameManager.Analytics_DesignEvent("Settings_Press_Close");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        this.gameObject.SetActive(false);
    //    Destroy(this.gameObject);
    }
    public void OnPress_PrivacyPolicy()
    {
        //Toolbox.GameManager.FBAnalytic_EventDesign("Settings_Press_PrivacyPolicy");
        //Toolbox.GameManager.Analytics_DesignEvent("Settings_Press_PrivacyPolicy");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        Application.OpenURL("");
    }

    public void OnPress_RestorePurchase()
    {
        //Toolbox.GameManager.FBAnalytic_EventDesign("Settings_Press_RestorePurchase");
        //Toolbox.GameManager.Analytics_DesignEvent("Settings_Press_RestorePurchase");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
       // InAppHandler.Instance.RestorePurchases();
    }

    public void OnPress_Withdraw()
    {
        //Toolbox.GameManager.FBAnalytic_EventDesign("Settings_Press_Withdraw");
        //Toolbox.GameManager.Analytics_DesignEvent("Settings_Press_Withdraw");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        this.gameObject.SetActive(false);
    }
    #endregion
}