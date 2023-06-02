using System.Collections.Generic;
using UnityEngine;

public class TriggersProps : MonoBehaviour
{
    public List<GameObject> Stones;

    void Start()
    {
        foreach (GameObject g in Stones)
        {
            if (g.GetComponent<Rigidbody>())
                g.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void Releasestones()
    {
        foreach (GameObject g in Stones)
        {
            g.SetActive(true);
            if (g.GetComponent<Rigidbody>())
            { 
                g.GetComponent<Rigidbody>().isKinematic = false;
                print("Releasestones");
                g.GetComponent<Rigidbody>().AddExplosionForce(800f,GameplayController.Instance.SelectedVehiclePrefab.transform.position/*g.transform.position*/,1000f,1000f,ForceMode.Acceleration);
            }

        }
    }

}
