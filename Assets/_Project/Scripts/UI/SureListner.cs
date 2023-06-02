using UnityEngine;

public class SureListner : MonoBehaviour
{
    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }
    public void OnPress_Yes (){

         Constants.FBAnalytic_EventDesign("Sure_Press_Yes");
        UIManager.Instance.PrivacyPolicy.SetActive(true);
        this.gameObject.SetActive(false);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);

    }

    public void OnPress_No()
    {
        Constants.FBAnalytic_EventDesign("Sure_Press_No");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);

        this.gameObject.SetActive(false);
    }
}
