using UnityEngine;
using UnityEngine.UI;

public class MessageListner : MonoBehaviour
{
    public Text messageTxt;
    public Text HeaderTxt;
    public void UpdateTxt(string _str, string str)
    {
        this.gameObject.SetActive(true);
        messageTxt.text = _str;
        HeaderTxt.text = str;
    }
    public void OnPress_Okay()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        this.gameObject.SetActive(false);
        CancelInvoke(nameof(off));
    }
    public void set_statuspanel()
    {
        Invoke(nameof(off), 7f);
    }
    private void off()
    {
        this.gameObject.SetActive(false);
        CancelInvoke(nameof(off));
    }
}