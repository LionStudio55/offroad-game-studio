using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivePanel : MonoBehaviour
{
    public Text Descriptionbody;
    // Start is called before the first frame update
    void Start()
    {
        Descriptionbody.text = "";
        Descriptionbody.text = GameplayController.Instance.SelectedLevelData.Missionstatement.ToString(); ;
    }

    public void startGame()
    {
        HUDListner.Instance.set_statusEnginebutton(true);
       // this.gameObject.SetActive(false);
    }

}
