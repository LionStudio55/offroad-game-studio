using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class purchaser : MonoBehaviour
{
    public void RemoveAds()
    {
        InAppHandler.Instance.Buy_NoAds();
    }
    public void Unlocklevels()
    {
        InAppHandler.Instance.Buy_AllLevels();
    }
    public void Unlockguns()
    {
        InAppHandler.Instance.Buy_AllVehicles();
    }
    public void UnlockEverything()
    {
        InAppHandler.Instance.Buy_MegaOffer();
    }

    public void UnlockEverything_gameplay()
    {
        InAppHandler.Instance.Buy_MegaOffer();
    }
}
