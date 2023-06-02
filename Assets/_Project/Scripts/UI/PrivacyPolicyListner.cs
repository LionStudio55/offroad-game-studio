using UnityEngine;

public class PrivacyPolicyListner : MonoBehaviour
{

    private void Start()
    {
        //  DontDestroyOnLoad(this.gameObject);
    }

    private void OnDisable()
    {
        //Toolbox.GameManager.Remove_ActiveUI(this.gameObject);
    }
    #region ButtonListner

    public void Close()
    {

        if (!Constants.GetBoolpref(Constants.UserConsent))
        {
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
}
