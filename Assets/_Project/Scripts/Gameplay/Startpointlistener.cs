using UnityEngine;

public class Startpointlistener : MonoBehaviour
{
    public GameObject Fireworks;
    public bool Startcross = false;
    // Start is called before the first frame update
    //void Start()
    //{

    //}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !Startcross && this.gameObject.CompareTag("StartPoint"))
        {
            //print("Player");
            Startcross = true;
            if (Fireworks)
                Fireworks.gameObject.SetActive(true);
            SoundsManager.Instance.PlaySound(SoundsManager.Instance.GetReady);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Startcross  &&this.gameObject.CompareTag("StartPoint"))
        {
            if (Fireworks)
                Fireworks.gameObject.SetActive(false);
        }
    }
}
