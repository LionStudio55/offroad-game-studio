using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimatedLoading : MonoBehaviour
{
   
    [SerializeField] private Slider slider;

    public float Increval;
    public float val;
    public bool start = false;
    // Start is called before the first frame update
    private void OnEnable()
    {
      
       
        slider.value = 0f;
        val = 0;
         start = true;
        Invoke(nameof(MediumBanner), 1f);
       // MediumBanner();
    }

    private void OnDisable()
    {
        start = false;
        slider.value = 0f;
        Smallbanner();
    }
    // Update is called once per frame
    void Update()
    {
        if(start)
        {

            val += Increval;
                    slider.value = val/1;
            if (slider.value >= 1)
            {
                start = false;
                slider.value = 0;
                this.gameObject.SetActive(false);
            }
                    
            
        }
    }
    private void Smallbanner()
    {
        try
        {
            //if (FindObjectOfType<MediationHandler>())
            //{
            //    FindObjectOfType<MediationHandler>().ShowSmallBanner(GoogleMobileAds.Api.AdPosition.Top); by uzair
            //    FindObjectOfType<MediationHandler>().hideMediumBanner();
            //}
        }
        catch (Exception e)
        {
        }
    }
    private void MediumBanner()
    {
        try
        {
            //if (FindObjectOfType<MediationHandler>())
            //{
            //    FindObjectOfType<MediationHandler>().ShowMediumBanner(GoogleMobileAds.Api.AdPosition.BottomLeft); by uzair
            //    FindObjectOfType<MediationHandler>().hideSmallBanner();
            //}
        }
        catch (Exception e)
        {
        }
    }
}
