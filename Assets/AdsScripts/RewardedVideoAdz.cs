using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardedVideoAdz : MonoBehaviour
{

    MediationHandler mediation;

    private void Awake()
    {
        mediation = FindObjectOfType<MediationHandler>();
    }

    
    public void ShowRewarded()
    {
        if (mediation != null && Application.internetReachability != NetworkReachability.NotReachable)        {
            mediation.ShowRewardedVideo(GiveReward);
        }
    }

     void GiveReward()
    {
        Debug.Log("Give Your Reward Here");
    }
}
