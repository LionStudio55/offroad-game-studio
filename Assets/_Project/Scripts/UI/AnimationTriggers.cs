using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        this.gameObject.GetComponent<Animator>().enabled = true;
    }
    public void OffAimation ()
    {
        this.gameObject.GetComponent<Animator>().enabled = false;
    }
  
}
