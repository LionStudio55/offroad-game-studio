using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsListener : MonoBehaviour
{
    public GameObject Steering;
    public GameObject Touch;
    public GameObject Jyro;
    // Start is called before the first frame update
    void OnEnable()
    {

        switch (Constants.SelectedControltype)
        {
            case Controls.Touch:
                Steering.SetActive(true);
                Touch.SetActive(false);
                Jyro.SetActive(false);
                break;
            case Controls.steering:
                Steering.SetActive(false);
                Touch.SetActive(true);
                Jyro.SetActive(false); 
                break;
            case Controls.Gyro:
                Steering.SetActive(false);
                Touch.SetActive(true);
                Jyro.SetActive(false);
                break;
            default:
                Steering.SetActive(false);
                Touch.SetActive(true);
                Jyro.SetActive(false);
                break;
        }
    }

}
