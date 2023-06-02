using UnityEngine;

public class RateUsListner : MonoBehaviour
{

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }
    private void Start()
    {
      //  Toolbox.DB.Prefs.AppRated = true;
    }

    void Close() {
        HUDListner.Instance.CompletePanel.SetActive(true);
         this.gameObject.SetActive(false);
    }

    #region ButtonListners

    public void OnPress_Rate()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        //Toolbox.GameManager.Analytics_DesignEvent("RateUs_Pressed");
        Constants.FBAnalytic_EventDesign("RateUs_Pressed");
        Constants.SetBoolpref(Constants.AppRated,true);
        Application.OpenURL(Constants.link_StoreInitial+Application.identifier);
        Close();
    }

    public void OnPress_Close()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        Constants.FBAnalytic_EventDesign("RateUs_Closed");
        //Toolbox.GameManager.Analytics_DesignEvent("RateUs_Closed");

        Close();
    }

    #endregion
}
