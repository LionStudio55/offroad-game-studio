using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverController : MonoBehaviour
{
    public Animator Driveranimatorcontroller;
    public float steeringinput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        steeringinput = GameplayController.Instance.SelectedVehicleRccv3.steerInput + HUDListner.steering;
        Driveranimatorcontroller.SetFloat("Steering ", steeringinput);
    }
}
