using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Envselectionlistener : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Coinstext;
    public GameObject Loading;
    public GameObject[] Hover;

    private void OnEnable()
    {
        for (int i = 0; i < Hover.Length; i++)
        {
            Hover[i].SetActive(false);
        }
        Hover[Constants.Getprefs(Constants.lastselectedEnv)].SetActive(true);
        Updatestats();
    }

    public void Updatestats()
    {
        Coinstext.text = Constants.Getprefs(Constants.Totalreward).ToString();

    }
    public void Selected_Mode(int index)
    {
        Constants.SetPref(Constants.lastselectedEnv, index);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        Invoke(nameof(Loadscene), 1f);
        Loading.SetActive(true);
        IAD();
        Constants.FBAnalytic_EventDesign("Selected_Mode_" + Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)).ToString());
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
}

