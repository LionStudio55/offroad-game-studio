using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Networking;

public class PlayerTriggerListener : MonoBehaviour
{
    public Transform LastCheckpoint;
    public GameObject DirtParticles;
    // Start is called before the first frame update
    void Start()
    {
        LastCheckpoint = GameplayController.Instance.VehicleSpawnPoint;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            //Constants.Logs("Save CheckPoint");
            LastCheckpoint = other.gameObject.transform;
            HUDListner.Instance.set_Statuscheckpoint(true);
            other.gameObject.SetActive(false);
            SoundsManager.Instance.PlaySound(SoundsManager.Instance.Savepointclip);

        }
       //else if (other.gameObject.CompareTag("CoinsPicker"))
       // {
       //     GameplayController.Instance.Rcccamera.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
       //     other.gameObject.SetActive(false);
       //     SoundsManager.Instance.PlaySound(SoundsManager.Instance.Savepointclip);
       // }

        else if (other.gameObject.CompareTag("CoinsPicker"))
        {
            GameObject par = GameplayController.Instance.Rcccamera.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;

            if (par.activeInHierarchy)
            {
                par.SetActive(false);
                par.SetActive(true);
            }
            else
            {
                par.SetActive(true);
            }
            other.gameObject.SetActive(false);
            SoundsManager.Instance.PlaySound(SoundsManager.Instance.Savepointclip);
        }
        else if (other.gameObject.CompareTag("Mud"))
        {
            DirtParticles.SetActive(true) ;
            //RCC_CarControllerV3.instance.maxEngineTorque = 60;
            //RCC_CarControllerV3.instance.maxEngineTorqueAtRPM = 1500;
            RCC.SetBehavior(2);
            GetComponent<Rigidbody>().drag = 1f;
            //Invoke(nameof(DragOff), 0.5f);
            // GameplayController.Instance.SelectedVehicleRccv3.FrontLeftWheelCollider.wheelCollider.forwardFriction.extremumSlip= 1.0f;
            SoundsManager.Instance.PlaySound(SoundsManager.Instance.Savepointclip);
        }
        else if (other.gameObject.CompareTag("FinishPoint"))
        {
            GameplayController.Instance.LevelFinished();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Failed"))
        {
            GameplayController.Instance.LevelFailHandling();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Barrier"))
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("open");
        }
        
        else if (other.gameObject.CompareTag("Stones"))
        {
            print("Stones");
            if (other.gameObject.GetComponent<TriggersProps>())
                other.gameObject.GetComponent<TriggersProps>().Releasestones();
        }
        else if (other.gameObject.CompareTag("Treebreaking"))
        {
            print("Treebreaking");
            if (other.gameObject.GetComponent<Animator>())
                other.gameObject.GetComponent<Animator>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("close");
        }
        else if (other.gameObject.CompareTag("Mud"))
        {
            DirtParticles.SetActive(false);
             RCC.SetBehavior(0);
            //RCC_CarControllerV3.instance.maxEngineTorque = 400;
            //RCC_CarControllerV3.instance.maxEngineTorqueAtRPM = 4500;
            //RCC_CarControllerV3.instance.maxspeed = 50;
            GetComponent<Rigidbody>().drag = 0.01F;
            SoundsManager.Instance.PlaySound(SoundsManager.Instance.Savepointclip);
        }
    }

    public void Resetposition()
    {
        Constants.Logs("ResetPosition");
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GameplayController.Instance.SelectedVehiclePrefab.transform.position = LastCheckpoint.transform.position;
        GameplayController.Instance.SelectedVehiclePrefab.transform.rotation = LastCheckpoint.transform.rotation;
    }
    public void DragOff()
    {
        GameplayController.Instance.SelectedVehiclePrefab.GetComponent<Rigidbody>().drag = 0.01f;
    }
}
