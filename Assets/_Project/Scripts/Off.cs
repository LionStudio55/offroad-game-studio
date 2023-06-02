using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Off : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Go_Off", 1.5f);
    }
    private void Go_Off()
    {
        //GAMEPLAY_UZ.inst.Counting_Text[3].SetActive(false);
    }
}
