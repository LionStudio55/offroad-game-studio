using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public VehicleSelectionListner vehiclelistener;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StopVehicles()
    {
        vehiclelistener.spawnedGunObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        vehiclelistener.spawnedGunObj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        vehiclelistener.spawnedGunObj.GetComponent<Rigidbody>().drag = 2.0f;
    }
    
}
