//using Cinemachine;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
/// <summary>
/// This script will hold everything that is needed to be global only in Game scene
/// </summary>
public class GameplayController : /*MonoBehaviour*/GenericSingletonClass<GameplayController>
{
    MediationHandler mediation;
    public GameObject Rcccamera;
    public GameObject Rain;
    //public GameObject[] CutScene_Cam;
    //public GameObject[] Counting_Text;
    public Transform VehicleSpawnPoint;
    private GameObject selectedVehiclePrefab;
    private RCC_CarControllerV3 selectedVehicleRccv3;
    private LevelHandler levelhandler;
    private LevelsData selectedLevelData;

    private bool levelComplete = false;
    private bool levelFail = false;
    private bool isRevived = false;
    private bool isFinish = false;
    private int lives = 3;

    public bool LevelComplete { get => levelComplete; set => levelComplete = value; }
    public bool LevelFail { get => levelFail; set => levelFail = value; }
    public bool IsRevived { get => isRevived; set => isRevived = value; }
    public GameObject SelectedVehiclePrefab { get => selectedVehiclePrefab; set => selectedVehiclePrefab = value; }
    public LevelHandler Levelhandler { get => levelhandler; set => levelhandler = value; }
    public RCC_CarControllerV3 SelectedVehicleRccv3 { get => selectedVehicleRccv3; set => selectedVehicleRccv3 = value; }
    public int Lives { get => lives; set => lives = value; }
    public LevelsData SelectedLevelData { get => selectedLevelData; set => selectedLevelData = value; }
    public bool IsFinish { get => isFinish; set => isFinish = value; }


    public override void Awake()
    {
        base.Awake();
        Time.timeScale = 1;
        LevelFail = false;
        LevelComplete = false;
        IsRevived = false;
        IsFinish = false;
    }
    void Start()
    {
        mediation = FindObjectOfType<MediationHandler>();
        SoundsManager.Instance.Set_MusicVolume(0.25f);
        Constants.FBAnalytic_EventLevel_Started(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)), Constants.Getprefs(Constants.lastselectedLevel));
        //Toolbox.GameManager.Analytics_ProgressionEvent_Start(Toolbox.GameManager.Get_CurGameModeName(), Toolbox.DB.Prefs.Get_LastSelectedLevelOfCurrentGameMode());
        
        //if (Constants.Getprefs(Constants.lastselectedMode) == 1)
        //    RCC_Settings.Instance.behaviorSelectedIndex = 5;
        //else
        //    RCC_Settings.Instance.behaviorSelectedIndex = 6;
    }
    public void End_Pointcamera()
    {
        Rcccamera.SetActive(false);
       /// levelhandler.EndLookAtCamera.SetActive(true);
        ConstraintSource constraintSource = new ConstraintSource();
        constraintSource.sourceTransform = SelectedVehiclePrefab.transform;
        constraintSource.weight = 1f;
        //if (levelhandler.EndLookAtCamera.GetComponent<LookAtConstraint>())
        //{
        //    levelhandler.EndLookAtCamera.GetComponent<LookAtConstraint>().AddSource(constraintSource);
        //}
    }
    public void Driver_Ready()
    {
        selectedVehicleRccv3 = selectedVehiclePrefab.GetComponent<RCC_CarControllerV3>();


        selectedVehicleRccv3.StartEngine(true);
        selectedVehicleRccv3.SetCanControl(true);
        Rcccamera.SetActive(true);
        Rcccamera.GetComponent<RCC_Camera>().SetTarget(selectedVehicleRccv3);
        SoundsManager.Instance.PlayMusic_Game(Random.Range(0, SoundsManager.Instance.gameBG.Length));
        IsFinish = false;
        HUD_Status(true);
    }
    public void SpawnVehicle()
    {
        if (SelectedVehiclePrefab)
        {
            Debug.Log("SpawnVehicle");
            selectedVehiclePrefab = Instantiate(selectedVehiclePrefab, VehicleSpawnPoint.position, VehicleSpawnPoint.rotation);
            if (selectedVehiclePrefab)
            {
                selectedVehiclePrefab.SetActive(true);
                selectedVehicleRccv3 = selectedVehiclePrefab.GetComponent<RCC_CarControllerV3>();
            }
            HUDListner.Instance.objectivepanel.SetActive(true);
            //Invoke(nameof(Startenginesound), 2f);
            Rcccamera.SetActive(true);
            //HUD_Status(true);
        }
    }
    public void Startenginesound()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        HUDListner.Instance.set_statusEnginebutton(true);
    }
    private void GamePlaysoundPlay()
    {
        SoundsManager.Instance.PlayMusic_Game(Random.Range(0, SoundsManager.Instance.gameBG.Length));
        CancelInvoke(nameof(GamePlaysoundPlay));
    }
    int ran = 0;
    public void Gamestart()
    {
        //HUDListner.Instance.Loadingpanel.gameObject.SetActive(true);
        //AudioListener.volume = 0;
        SpawnVehicle();
        print("Gamestart");
    }
   
    public void Level_Andcutscenehandling()
    {
        SpawnVehicle();
    }

    public void UnloadAssetsFromMemory()
    {
        Resources.UnloadAsset(SelectedLevelData);
        Resources.UnloadUnusedAssets();
    }
    public void LevelFinished()
    {
        if (isFinish)
            return;
        HUD_Status(false);
        SelectedVehiclePrefab.GetComponent<Rigidbody>().drag = 50f;
        selectedVehicleRccv3.SetEngine(false);
        selectedVehicleRccv3.SetCanControl(false);
        if (selectedVehicleRccv3.transform.Find("All Audio Sources"))
            selectedVehicleRccv3.transform.Find("All Audio Sources").gameObject.SetActive(false);
        HUDListner.Resetconrtrol();
        SoundsManager.Instance.Stop_PlayingMusic();
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.levelComplete);
        Levelhandler.Fireworks.SetActive(true);
        //Invoke(nameof(EndEffect_character), 2f);
        StartCoroutine(LevelComplete_Delay(2f));
        IsFinish = true;
       // LoadingAdd();
    }

    private void EndEffect_character()
    {
        //HUDListner.Instance.setstatus_FadeEffect(false);
       // Rcccamera.SetActive(false);
       // Levelhandler.endCamera.SetActive(true);

        selectedVehicleRccv3.SetEngine(false);
        selectedVehicleRccv3.SetCanControl(false);
        if (selectedVehicleRccv3.transform.Find("All Audio Sources"))
            selectedVehicleRccv3.transform.Find("All Audio Sources").gameObject.SetActive(false);
        HUDListner.Resetconrtrol();
    }
    public void HUD_Status(bool _val)
    {
        HUDListner.Instance.handleplayerhud(_val);
        HUDListner.Instance.Set_PlayerControls(_val);
        HUDListner.Instance.pauseBtn.gameObject.SetActive(_val);

    }
    public IEnumerator LevelComplete_Delay(float delay)
    {
        yield return new WaitForSeconds(delay + 1f);
        HUDListner.Instance.ObjectiveClear.SetActive(true);
        HUDListner.Instance.set_statusLevelCounter();
        yield return new WaitForSeconds(5f);
        HUDListner.Instance.ObjectiveClear.SetActive(false);
        LevelCompleteHandling();
        StopCoroutine(LevelComplete_Delay(0.1f));
    }
    public void LevelCompleteHandling()
    {

        if (LevelComplete || LevelFail)
            return;

        LevelComplete = true;

        //HUD_Status(false);
        //if ((!Toolbox.DB.Prefs.AppRated && Toolbox.DB.Prefs.Get_LastSelectedLevelOfCurrentGameMode() == 2) || (!Toolbox.DB.Prefs.AppRated && Toolbox.DB.Prefs.Get_LastSelectedLevelOfCurrentGameMode() == 5))
        //{
        //    Toolbox.HUDListner.RateUs_Panel.SetActive(true);
        //}

        //else
        //{
        //    Toolbox.HUDListner.CompletePanel.SetActive(true);
        //}
        HUDListner.Instance.CompletePanel.SetActive(true);
        SHOWInterstitialIAD();

    }
    public void LevelFail_Delay(float delay)
    {
        if (LevelFail || isFinish)
            return;
        IsFinish = true;


        if (HUDListner.Instance.MissionFailtext)
            HUDListner.Instance.MissionFailtext.SetActive(true);
        HUD_Status(false);
        Invoke("LevelFailHandling", delay);
        selectedVehiclePrefab.GetComponent<Rigidbody>().velocity = Vector3.zero;
        selectedVehiclePrefab.GetComponent<Rigidbody>().drag = 0.1f;
        selectedVehicleRccv3.SetEngine(false);
        selectedVehicleRccv3.SetCanControl(false);
    }

    public void LevelFailHandling()
    {

        if (LevelComplete || LevelFail)
            return;

        LevelFail = true;
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.levelFail);
        if (HUDListner.Instance.MissionFailtext)
            HUDListner.Instance.MissionFailtext.SetActive(false);
        //HUD_Status(false);
        HUDListner.Instance.FailPanel.SetActive(true);
        SHOWInterstitialIAD();
    }

    public void CR_Revive()
    {
        HUD_Status(false);
        HUDListner.Instance.RevivePanel.SetActive(true);
        // Toolbox.GameManager.Reviveplayer = true;

    }

    IEnumerator CR_ReviveAfterDelay()
    {

        yield return new WaitForSeconds(1);
        HUD_Status(false);
        HUDListner.Instance.RevivePanel.SetActive(true);

    }

    public void RevivePlayer()
    {

        if (LevelComplete || LevelFail)
            return;
        Time.timeScale = 1;
        LevelFail = false;
        IsRevived = true;
        HUD_Status(true);
        Constants.FBAnalytic_EventDesign(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)) + "_" + Constants.Getprefs(Constants.lastselectedLevel));

    }

    #region Ads
    private void LoadingAdd()
    {
        //try
        //{
        //    if (FindObjectOfType<AbstractAdsmanager>())
        //        FindObjectOfType<AbstractAdsmanager>().LoadInterstitial();  by uzair
        //}
        //catch (Exception e)
        //{

        //}
    }
    private void Show_Add()
    {
        //try
        //{
        //    if (FindObjectOfType<AbstractAdsmanager>())
        //        FindObjectOfType<AbstractAdsmanager>().ShowInterstitial(); by uzair
        //}
        //catch (Exception e)
        //{

        //}
    }
    #endregion


    #region Vehiclestatus
    public void Resetvehicle()
    {
        if (SelectedVehiclePrefab)
        {
            SelectedVehiclePrefab.GetComponent<PlayerTriggerListener>().Resetposition();
            HUDListner.Instance.Setstatus_Lives();
        }
    }
    #endregion
    //public void OneTwoThreeGo()
    //{
    //    StartCoroutine(Cut_Scene());  //ali
    //}
    //IEnumerator Go_Off()
    //{
    //    Counting_Text[3].SetActive(true);
    //    yield return new WaitForSeconds(2f);
    //    Counting_Text[3].SetActive(false);

    //}
    //public void Skip_CutScene()
    //{
    //    HUDListner.Instance.Skip.SetActive(false);
    //   // CarSelectionPanel.SetActive(false);
    //    HUD_Status(true);
    //   Rcccamera.SetActive(true);
    //    StartCoroutine(Go_Off());
    //    CutScene_Cam[0].SetActive(false);
    //    CutScene_Cam[1].SetActive(false);
    //    CutScene_Cam[2].SetActive(false);
    //    Counting_Text[0].SetActive(false);
    //    Counting_Text[1].SetActive(false);
    //    Counting_Text[2].SetActive(false);
    //    StopAllCoroutines();

    //    //Header.SetActive(false);
    //    //Footer.SetActive(false);

    //}
    //IEnumerator Cut_Scene()
    //{
    //    CutScene_Cam[0].SetActive(true);
    //    Counting_Text[0].SetActive(true);
    //    yield return new WaitForSeconds(2f);
    //    Counting_Text[0].SetActive(false);
    //    Counting_Text[1].SetActive(true);
    //    CutScene_Cam[0].SetActive(false);
    //    CutScene_Cam[1].SetActive(true);
    //    yield return new WaitForSeconds(2f);
    //    Counting_Text[2].SetActive(true);
    //    Counting_Text[1].SetActive(false);
    //    CutScene_Cam[1].SetActive(false);
    //    CutScene_Cam[2].SetActive(true);
    //    // Header.gameObject.GetComponent<Animator>().enabled = true;
    //    //Footer.gameObject.GetComponent<Animator>().enabled = true;
    //    yield return new WaitForSeconds(2f);
    //    StartCoroutine(Go_Off());
    //    Counting_Text[2].SetActive(false);
    //    CutScene_Cam[2].SetActive(false);
    //    // CarSelectionPanel.SetActive(false);
    //    //Header.SetActive(false);
    //    //Footer.SetActive(false);
    //    HUDListner.Instance.Skip.SetActive(false);
    //    HUD_Status(true);
    //    Rcccamera.SetActive(true);
    //}

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
