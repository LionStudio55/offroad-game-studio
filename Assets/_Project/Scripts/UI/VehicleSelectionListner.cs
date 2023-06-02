//using GoogleMobileAds.Api;
using System;
using System.Collections;
using UnityEngine;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using GameAnalyticsSDK;

public class VehicleSelectionListner : MonoBehaviour
{
    MediationHandler mediation;
    public bool[] GunsUnlocked;
    //public AssetReferenceGameObject[] Guns;
    public GameObject[] Gunsbutton;
    public GameObject[] BarHover;
    public GameObject[] GunsbuttonLock;
    public Text[] Nameofvehicle;
    public Image[] attributeFillImg;
    public Text[] attributeValue;
    public Button next;
    public Button prev;
    public Button unlockVehicle;
    public Button play;
    public Button Back;
    public GameObject lockPanel;
    public GameObject unlockBtn;
    public GameObject unlockAllCarsBtn;
    public GameObject TryWeapon;
    public Text vehicleName;
    public Text vehicleCost;
    public Text coinsEarning;
    public Text DaimondEarning;   
    public Transform vehicleSpawnPosition;
    public GameObject spawnedGunObj;
    private int curGunIndex = 2;

    private GunSelection_Gun vehiclesData;

    private void OnEnable()
    {
        curGunIndex = Constants.Getprefs(Constants.LastSelectedVehicle);
        if (!PlayerPrefs.HasKey("GunsUnlocked"))
        {
            // print("FIRST");
            PlayerPrefsX.SetBoolArray("GunsUnlocked", GunsUnlocked);
        }
        else
        {
            //print("nOTFIRST");
            GunsUnlocked = PlayerPrefsX.GetBoolArray("GunsUnlocked");
        }

        for (int i = 0; i < Nameofvehicle.Length; i++)
        {
            vehiclesData = Resources.Load<GunSelection_Gun>(Constants.folderPath_Scriptables + Constants.folderPath_Scriptables_VehicleSelection_Vehicles + i);
            Nameofvehicle[i].text = vehiclesData.name.ToString();
        }
        FetchVehiclesDataFromResources();
        ShowVehicle(curGunIndex);
        vehicleSpawnPosition.gameObject.SetActive(true);
        Smallbanner();
        Refreshview();
    }
    private void Start()
    {
        mediation = FindObjectOfType<MediationHandler>();
        // Invoke("ShowMegaOffers",1f);
        //Addressables.InitializeAsync();

    }

    private void ShowMegaOffers()
    {
        if (!AreAllCarsUnlocked()/* && !Toolbox.DB.Prefs.MegaOfferPurchased*/)
        {
            //Toolbox.UIManager.MegaOffers.SetActive(true);
        }
    }
    private void OnDisable()
    {
        CancelInvoke();
        StopAllCoroutines();
        PlayerPrefsX.SetBoolArray("vehiclesUnlocked", GunsUnlocked);
    }
    private void Update()
    {
        Updatestats();
    }
    private void Updatestats()
    {
        if (attributeFillImg[0]) attributeFillImg[0].fillAmount = Mathf.Lerp(attributeFillImg[0].fillAmount, (vehiclesData.Damage), Time.deltaTime * 5.0f);
        if (attributeFillImg[1]) attributeFillImg[1].fillAmount = Mathf.Lerp(attributeFillImg[1].fillAmount, (vehiclesData.FireRange), Time.deltaTime * 5.0f);
        if (attributeFillImg[2]) attributeFillImg[2].fillAmount = Mathf.Lerp(attributeFillImg[2].fillAmount, (vehiclesData.Ammo), Time.deltaTime * 5.0f);
        if (attributeFillImg[3]) attributeFillImg[3].fillAmount = Mathf.Lerp(attributeFillImg[3].fillAmount, (vehiclesData.Firerate), Time.deltaTime * 5.0f);
    }
    public void Updatestatscoin()
    {
        coinsEarning.text = Constants.Getprefs(Constants.Totalreward).ToString();
        DaimondEarning.text = Constants.Getprefs(Constants.Daimond).ToString();
    }
    public void Refreshview()
    {
        InitGunsButtonsState();
        Updatestatscoin();
        if (Constants.WeaponTrialFinished)
            weapontrailfinished();

        //if (AreAllCarsUnlocked())
        //    UnlockAllCarsBtn(false);
        //else
        //    UnlockAllCarsBtn(true);
    }
    private void InitGunsButtonsState()
    {
        bool watchVideoBtnEnabled = false;
        int GunUnlocked = Get_LastUnlockedGuns();
      //  Debug.Log("InitLevelButtonsState :"+ GunUnlocked);
        for (int i = 0; i < Gunsbutton.Length; i++)
        {
            Gunsbutton[i].gameObject.SetActive(true);
          
            //Watch video Btn for Unlock Next Level
            //if (!watchVideoBtnEnabled && !GunsUnlocked[i])
            //{
            //    TryWeapon.SetActive(true);
            //   // print("TryWeapon");
            //    watchVideoBtnEnabled = true;
            //}
            //else
            //    TryWeapon.SetActive(false);


            // btnListner.WatchVideoUnlock_Status(false);
            ////hightlight last selected level
            if (GunsUnlocked[i])
            {
                BarHover[i].SetActive(false);
                GunsbuttonLock[i].SetActive(false);
            }
            else
            {
                BarHover[i].SetActive(false);
                GunsbuttonLock[i].SetActive(true);
            }
            if (i == GunUnlocked)
            {
                BarHover[i].SetActive(true);
                GunsbuttonLock[i].SetActive(false);
            }

            //if (i == GunUnlocked)
            //{
            //    BarHover[i].SetActive(true);
            //    GunsbuttonLock[i].SetActive(false);
            //}
            //else if (i <= GunUnlocked)
            //{
            //    BarHover[i].SetActive(false);
            //    GunsbuttonLock[i].SetActive(false);
            //}
            //else
            //{
            //    BarHover[i].SetActive(false);
            //    GunsbuttonLock[i].SetActive(true);
            //}
        }
    }

    public void FetchVehiclesDataFromResources()
    {
        //for(int i=0; i<Guns.Length;i++)
        //{
        //    Guns[i].SetActive(false);
        //}
        //if (vehiclesData)
        //    Destroy(vehiclesData);
        if (spawnedGunObj)
            Destroy(spawnedGunObj);

        vehiclesData = Resources.Load<GunSelection_Gun>(Constants.folderPath_Scriptables + Constants.folderPath_Scriptables_VehicleSelection_Vehicles + curGunIndex);
        spawnedGunObj = Instantiate(Resources.Load<GameObject>(Constants.folderPath_Prefabs + Constants.folderPath_Prefabs_VehicleSelection_Vehicles + curGunIndex), vehicleSpawnPosition.transform.position, vehicleSpawnPosition.rotation,vehicleSpawnPosition) as GameObject;
        spawnedGunObj.SetActive(true);
        vehicleSpawnPosition.gameObject.SetActive(false);
        vehicleSpawnPosition.gameObject.SetActive(true);

        if (attributeValue[0]) attributeValue[0].text = Mathf.RoundToInt((vehiclesData.Damage) * 100).ToString() +"%";
        if (attributeValue[1]) attributeValue[1].text = Mathf.RoundToInt((vehiclesData.FireRange) * 100).ToString() + "%";
        if (attributeValue[2]) attributeValue[2].text = Mathf.RoundToInt((vehiclesData.Ammo) * 100).ToString() + "%";
        if (attributeValue[3]) attributeValue[3].text = Mathf.RoundToInt((vehiclesData.Firerate) * 100).ToString() + "%";
        // lOAD();


    }
   
    //void lOAD()
    //{

    //    Guns[curGunIndex].LoadAssetAsync<GameObject>().Completed += OnLoadDone;
    //}
    //private void OnLoadDone(AsyncOperationHandle<GameObject> obj)
    //{
    //    // In a production environment, you should add exception handling to catch scenarios such as a null result;
    //    if (obj.Result == null)
    //    {
    //        Debug.LogError("no sheets here.");
    //        return;
    //    }
    //    if (obj.Status == AsyncOperationStatus.Succeeded)
    //    {
    //        GameObject gameObject = obj.Result;
    //        spawnedGunObj = obj.Result;
    //        // Texture ready for use...

    //        // Done. Release resource
    //        Addressables.Release(obj);
    //      Addressables.InstantiateAsync(spawnedGunObj/*, vehicleSpawnPosition.transform.position, vehicleSpawnPosition.rotation*/);
    //      spawnedGunObj.SetActive(true);
    //    }

    //}
    private void ShowVehicle(int _index)
    {
        foreach (GameObject g in BarHover)
            g.SetActive(false);
        vehicleName.text = vehiclesData.name.ToString();
        vehicleCost.text = vehiclesData.cost.ToString();
        SetButtonState(GunsUnlocked[_index]);
    }

    private void SetButtonState(bool _gunUnlocked)
    {

        // Just for Weapon Try
        //if (Toolbox.DB.Prefs.Tryweapon)
        //    TryWeapon.gameObject.SetActive(false);
        //else
        //    TryWeapon.gameObject.SetActive(!_gunUnlocked);

       // TryWeapon.gameObject.SetActive(!_gunUnlocked);
        play.gameObject.SetActive(_gunUnlocked);
        // if Directly showing shop then always keep this button off
        //if (Toolbox.GameManager.GodirectshopfromMenu)
        //    play.gameObject.SetActive(false);
        // if(Toolbox.GameManager.GoDirectGamePlayAfterCompleteDirectShop1)
        //    play.gameObject.SetActive(true);

        unlockVehicle.gameObject.SetActive(!_gunUnlocked);

        lockPanel.SetActive(!_gunUnlocked);
        unlockBtn.SetActive(!_gunUnlocked);
        if (_gunUnlocked)
            BarHover[curGunIndex].SetActive(_gunUnlocked);
        else
            BarHover[Get_LastUnlockedGuns()].SetActive(true);
        //print("Get_LastUnlockedGuns :" + Get_LastUnlockedGuns());
        //    unlockPanel.SetActive(_vehicleUnlocked);

        vehicleCost.gameObject.SetActive(!_gunUnlocked);
    }

    private void UnlockAllCarsBtn(bool _val)
    {

        unlockAllCarsBtn.SetActive(_val);
    }

    #region ButtonListners

    public void OnPress_Prev()
    {

        curGunIndex--;

        if (curGunIndex < 0)
            curGunIndex = GunsUnlocked.Length - 1;


        spawnedGunObj.SetActive(false);
        FetchVehiclesDataFromResources();
        ShowVehicle(curGunIndex);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }

    public void OnPress_Next()
    {

        curGunIndex++;

        if (curGunIndex >= GunsUnlocked.Length)
            curGunIndex = 0;

        spawnedGunObj.SetActive(false);

        FetchVehiclesDataFromResources();
        ShowVehicle(curGunIndex);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        //Toolbox.DB.Prefs.LastSelectedVehicle = curVehicleIndex;
    }

    public void ShowGun(int _index)
    {
        curGunIndex = _index;
        spawnedGunObj.SetActive(false);
        FetchVehiclesDataFromResources();
        ShowVehicle(curGunIndex);
        SetButtonState(GunsUnlocked[_index]);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);

    }

    public void OnPress_UnlockVehicle()
    {

        if (Constants.Getprefs(Constants.Totalreward) >= vehiclesData.cost)
        {
            Constants.SetPref(Constants.Totalreward, Constants.Getprefs(Constants.Totalreward) - vehiclesData.cost);
            GunsUnlocked[curGunIndex] = true;
            SetButtonState(true);
        }
        else
        {
            UIManager.Instance.LowCoinUnlockCar_Panel.SetActive(true);
            UIManager.Instance.LowCoinUnlockCar_Panel.GetComponent<LowCoinVehicleBuy>().CurVehicle = curGunIndex;
        }
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }

    public void OnPress_UnlockAllVehicle()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        //InAppHandler.Instance.Buy_AllGuns();
    }


    public void OnPress_Back()
    {
        //if (UIManager.Instance.DirectShowingShop)
        //    UIManager.Instance.DirectShowMain();
        //else
        //    Toolbox.UIManager.Go_BackFromWeaponselection();
        //this.GetComponentInParent<UIManager>().ShowPrevUI();
        LoadInterstitial();
        UIManager.Instance.ShowPrevUI();

        //Toolbox.GameManager.Analytics_DesignEvent("GunSelection_Press_Back");
        //if ( Toolbox.GameManager.GodirectshopfromMenu )
        //    Toolbox.GameManager.GodirectshopfromMenu = false;
        //UIManager.Instance.UIDummy_Loading.SetActive(true);
        //StartCoroutine(LoadScene(Constants.scene_Menu));
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }
    //IEnumerator LoadScene(string name)
    //{
    //    yield return null;

    //    //Begin to load the Scene you specify
    //    AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name);
    //    //Don't let the Scene activate until you allow it to
    //    asyncOperation.allowSceneActivation = false;
    //    //Debug.Log("Pro :" + asyncOperation.progress);
    //    //When the load is still in progress, output the Text and progress bar
    //    while (!asyncOperation.isDone)
    //    {
    //        //Output the current progress
    //        loadingslider.value += 0.005f;
    //        string percent = (loadingslider.value * 100).ToString("F0");
    //        // loadingText.text = string.Format("<size=35>{0}%</size>", percent);
    //        // Check if the load has finished
    //        if (asyncOperation.progress >= 0.9f && loadingslider.GetComponent<Slider>().value == 1.0f)
    //        {
    //            //Change the Text to show the Scene is ready
    //            asyncOperation.allowSceneActivation = true;

    //        }

    //        yield return null;
    //    }
    //}
    public void OnPress_Play()
    {
        LoadInterstitial();
        Constants.SetPref(Constants.LastSelectedVehicle, curGunIndex);
        //  Toolbox.GameManager.FBAnalytic_EventDesign("GunSelection_Press_Play");
        //  Toolbox.GameManager.Analytics_DesignEvent("GunSelection_Press_Play");
        ////  Invoke("Ads",1.2f);
        //  this.GetComponentInParent<UIManager>().ShowNextUI();
        //StartCoroutine(LoadScene(Constants.scene_GamePlay));

        //UIManager.Instance.UIDummy_Loading.SetActive(true);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);

        UIManager.Instance.ShowNextUI();
    }

    public void OnPress_Store()
    {
        //Toolbox.GameManager.FBAnalytic_EventDesign("GunSelection_Press_Store");
        //Toolbox.GameManager.Analytics_DesignEvent("GunSelection_Press_Store");
        //Toolbox.UIManager.Shop_Panel.SetActive(true);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }

    public void OnPress_3DView(bool _Val)
    {
        //Toolbox.GameManager.FBAnalytic_EventDesign("OnPress_3DView");
        //Toolbox.GameManager.Analytics_DesignEvent("OnPress_3DView");
        //   View3DPanel.SetActive(_Val);
        //   View2DPanel.SetActive(!_Val);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }

    public void TRYWeapon()
    {
        try
        {
            //if (FindObjectOfType<MediationHandler>())
            //{
            //    if (FindObjectOfType<MediationHandler>().IsRewardedAdReady())
            //        FindObjectOfType<MediationHandler>().ShowRewardedVideo(RewardunlockTryWeapon);
            //    else
            //    {
            //        MessagePopup.SetActive(true);
            //        MessagePopup.GetComponent<MessageListner>().UpdateTxt("Please check you Internet Connection is Going Down.","NETWORK FAILED"); by uzair
            //        MessagePopup.GetComponent<MessageListner>().set_statuspanel();
            //    }
            //}
        }
        catch(Exception e )
        {
            
        }

        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }
    private void RewardunlockTryWeapon()
    {
        Constants.TryWeapon = true;
        GunsUnlocked[curGunIndex] = true;
        SetButtonState(true);
        Constants.SetPref(Constants.TyrweaponNo, curGunIndex);
    }
    private void weapontrailfinished()
    {
       
        Constants.TryWeapon = false;
        Constants.WeaponTrialFinished = false;
        GunsUnlocked[Constants.Getprefs(Constants.TyrweaponNo)] = false;
        SetButtonState(GunsUnlocked[Constants.Getprefs(Constants.TyrweaponNo)]);
        Constants.SetPref(Constants.TyrweaponNo, 0);
    }
    
    public bool AreAllCarsUnlocked()
    {
        for (int i = 0; i < GunsUnlocked.Length; i++)
        {
            if (!GunsUnlocked[i])
            {

                //Debug.LogError("All vehicles --NOT-- unlocked");
                return false;
            }

        }
        //Debug.LogError("All vehicles are unlocked");
        return true;
    }

    public int Get_LastUnlockedGuns()
    {
        int lastunlocked=0;
        for (int i = 0; i < GunsUnlocked.Length; i++)
        {
            if (GunsUnlocked[i])
            {
                lastunlocked = i;
               // return i - 1;
            }
        }
        return lastunlocked;
        //return GunsUnlocked.Length - 1;
    }
    #endregion

    #region Ads Calling 
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
    private void IAD()
    {
        try
        {
            //if (FindObjectOfType<MediationHandler>())
            //    FindObjectOfType<MediationHandler>().ShowInterstitial(); by uzair
        }
        catch (Exception e)
        {
        }
    }
    #endregion
    public void SHOWInterstitialIAD()
    {
        if (mediation != null && (PlayerPrefs.GetInt("RemoveAds") != 1))
        {
            mediation.ShowInterstitial();
        }
    }
    public void LoadInterstitial()
    {
        if (mediation != null && (PlayerPrefs.GetInt("RemoveAds") != 1))
        {
            mediation.LoadInterstitial();
        }
    }
}
