using System;
using UnityEngine;

public class PrivacyPolicyListner : MonoBehaviour
{

    private void Start()
    {
    }

    private void OnDisable()
    {
    }
    #region ButtonListner

    public void Close()
    {

        if (!Constants.GetBoolpref(Constants.UserConsent))
        {
            Invoke(nameof(App_Open), 9f);
            GameManager.Instance.Load_Scene(Constants.scene_Menu, 10f);
        }
        else
        {
            GameManager.Instance.Load_Scene(Constants.scene_Menu, 0);
        }
        Constants.SetBoolpref(Constants.UserConsent, true);
        Constants.FBAnalytic_EventDesign("PrivacyPolicy_Press_Close");
        this.gameObject.SetActive(false);
    }

    public void OnPress_PrivacyLink()
    {
        Constants.FBAnalytic_EventDesign("PrivacyPolicy_Press_PrivacyLink");
        Application.OpenURL(Constants.link_PrivacyPolicy);

    }

    public void OnPress_Yes()
    {

        Constants.FBAnalytic_EventDesign("PrivacyPolicy_Press_Yes");
        //Constants.SetBoolpref(Constants.UserConsent, true);
        Close();

        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
    }

    public void OnPress_No()
    {
        Constants.FBAnalytic_EventDesign("PrivacyPolicy_Press_No");
        Constants.SetBoolpref(Constants.UserConsent, false);
        Close();
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
    }

    #endregion
    private void App_Open()
    {
        try
        {
            if (FindObjectOfType<MediationHandler>())
                FindObjectOfType<MediationHandler>().ShowAppOpenAd();
        }
        catch (Exception e)
        {

        }
    }
}
