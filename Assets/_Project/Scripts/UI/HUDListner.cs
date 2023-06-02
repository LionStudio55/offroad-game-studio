//using GameAnalyticsSDK;
//using GoogleMobileAds.Api;
//using CnControls;
//using GameAnalyticsSDK;
using System;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class InputValues
{

    public float Throtle = 0f;
    public float Brake = 0f;
    public float steering = 0f;
    public float Boostinput = 0f;
    public float Handbrake = 0f;
}



public class HUDListner : /*MonoBehaviour*/GenericSingletonClass<HUDListner>
{
    /// <summary>
    /// UI menus
    /// </summary>
    /// 
    public GameObject objectivepanel;
    public GameObject PausePanel;
    public GameObject FailPanel;
    public GameObject CompletePanel;
    public GameObject RevivePanel;
    public GameObject WatchVideoPanel;
    public GameObject RateUs_Panel;
    public GameObject Mega_OfferPanel;
    public GameObject Loadingpanel;
    public GameObject Message;
    public GameObject Fadeimage;
    public GameObject Startengine;
    //public GameObject WrongwayIndicator;
    //public GameObject AircontrolsTutorial;
    //public GameObject AircontrolsLeftIndicator;
    //public GameObject AircontrolsRightIndicator;s
    //public GameObject GetInCar;
    //public GameObject GetOutCar;
    /// <summary>
    /// Other Text 
    /// </summary>
    /// 
    public Image Nosfillbar;
    public Text totalLivesTxt;
    public Text LevelText;
    public GameObject Checkpoint;
    public GameObject MissionFailtext;
    public GameObject ObjectiveClear;
    public GameObject PlayerHudCanvas;
    public Button pauseBtn;
    public Button skipStartCinematicBtn;
    public GameObject playerControlsPanel;
    public GameObject Skip;
    public CanvasGroup canvasGroup;
    /// <summary>
    /// Below All of the Items related to vehicles 
    /// </summary>
    /// 
    public Text Speed;
    public GameObject Needle;
    public Image heatGauge;
    public Image fuelGauge;
    public GameObject Left, right, brake, race, Resetbtn;
    public GameObject Steering;
    public GameObject leftindicators, Rightindicators;
    private float RPMNeedleRotation = 0f;
    private float KMHNeedleRotation = 0f;
    private float BoostNeedleRotation = 0f;
    private float NoSNeedleRotation = 0f;
    private float heatNeedleRotation = 0f;
    private float fuelNeedleRotation = 0f;

    private Vector3 orgBrakeButtonPos;
    //private int time;
    private bool brakeinput;
    private bool brakepress;
    private Rigidbody RCCV3rigidbody;
    private RCC_CarControllerV3 RCCV3;
    public bool ShowInput = false;
    public InputValues inputs;
    public static float Throtle = 0f;
    public static float Brake = 0f;
    public static float steering = 0f;
    public static float Boostinput = 0f;
    public static float Handbrake = 0f;
    public static bool onpressleft = false;
    public static bool onpressright = false;

    private void Start()
    {
        if (brake)
            orgBrakeButtonPos = brake.transform.position;


        Throtle = 0f;
        Brake = 0f;
        steering = 0f;
        Boostinput = 0f;
        Handbrake = 0f;
        onpressleft = false;
        onpressright = false;
        if (Application.isMobilePlatform)
            RCC_Settings.Instance.mobileControllerEnabled = true;
            check_statuscontrols();
    }
  
    public override void Awake()
    {
        base.Awake();
        ShowBanner();
    }

    private void Adload()
    {
        try
        {
            //if (FindObjectOfType<AbstractAdsmanager>())
            //{
            //    FindObjectOfType<AbstractAdsmanager>().LoadInterstitial();
            //}
        }
        catch (Exception e)
        {
            //GameAnalytics.NewErrorEvent(GAErrorSeverity.Info, "MediationHandler Not Found!");


        }
        CancelInvoke(nameof(Adload));
    }

    public void ShowBanner()
    {

        try
        {
            //if (FindObjectOfType<AbstractAdsmanager>())
            //    FindObjectOfType<AbstractAdsmanager>().ShowSmallBanner(GoogleMobileAds.Api.AdPosition.TopRight);

        }

        catch (Exception e)
        {

        }

    }

    void Update()
    {
        Updatestats();
    }

    private void Updatestats()
    {
        if (GameplayController.Instance.SelectedVehicleRccv3)
            Setstatus_speed(GameplayController.Instance.SelectedVehicleRccv3.speed);
        if (Constants.SelectedControltype == Controls.Gyro)
            steering = Mathf.Lerp(steering, Input.acceleration.x * RCC_Settings.Instance.gyroSensitivity, Time.deltaTime * 5f);



        if (ShowInput)
        {
            inputs.Throtle = Throtle;
            inputs.Brake = Brake;
            inputs.steering = steering;
            inputs.Boostinput = Boostinput;
            inputs.Handbrake = Handbrake;


        }
    }

    public void SetTime(int _val)
    {
        //time = _val;
        //int min = time / 60;
        //   timeTxt.text = string.Format("{0:D2}:{1:D2}", min, time - (min * 60));
    }

    public void Setstatus_Lives()
    {
        totalLivesTxt.text = GameplayController.Instance.Lives.ToString();
    }
    public void Setstatus_speed(float speed)
    {
        if (Speed)
            Speed.text = speed.ToString("0");
        if (Nosfillbar)
            Nosfillbar.fillAmount = Mathf.Lerp(Nosfillbar.fillAmount, (speed / GameplayController.Instance.SelectedVehicleRccv3.maxspeed), Time.deltaTime * 2.0f);
        
        if (RCC_Settings.Instance.units == RCC_Settings.Units.KMH)
            KMHNeedleRotation = (speed*3f);
        else
            KMHNeedleRotation = ((speed *3f)* 0.62f);
        Needle.transform.eulerAngles = new Vector3(Needle.transform.eulerAngles.x, Needle.transform.eulerAngles.y, (40f-KMHNeedleRotation));
       
        if (heatGauge)
        {
         //   print("heatGauge :"+ (GameplayController.Instance.SelectedVehicleRccv3.engineHeat/110));
            heatGauge.fillAmount = (GameplayController.Instance.SelectedVehicleRccv3.engineHeat / 110f);
            if (heatGauge.fillAmount > 0.4f)
                heatGauge.color = Color.blue;
            else if (heatGauge.fillAmount > 0.7f)
                heatGauge.color = Color.red;
            else
                heatGauge.color = Color.green;
        }
        if (fuelGauge)
        {
            //print("fuelGauge :" + ((GameplayController.Instance.SelectedVehicleRccv3.fuelTank / GameplayController.Instance.SelectedVehicleRccv3.fuelTankCapacity) * 270f)/270f);
            fuelGauge.fillAmount = ((GameplayController.Instance.SelectedVehicleRccv3.fuelTank / GameplayController.Instance.SelectedVehicleRccv3.fuelTankCapacity) * 270f)/270f;
        }
    }

    public void SetTotalLives(int _val)
    {
        totalLivesTxt.text = _val.ToString();
        GameplayController.Instance.Lives = _val;
    }

    public void set_statusEnginebutton(bool _Val)
    {
        Startengine.SetActive(_Val);
    }
    //public float Get_Time() {

    //   return time;
    //}

    //public void set_StatusWrongwayIndicator(bool _val)
    //{
    //    WrongwayIndicator.SetActive(_val);
    //}
    public void Set_PlayerControls(bool _val)
    {

        playerControlsPanel.SetActive(_val);
    }

    //public void Set_TpsPlayerControls(bool _val)
    //{

    //    TpsControlsPanel.SetActive(_val);
    //}
    public void SetStatus_SkipAnimationButton(bool _val)
    {
        if (skipStartCinematicBtn.gameObject)
            skipStartCinematicBtn.gameObject.SetActive(_val);
    }

  

    public void set_StatusAicontrolsTutorial(bool _Val)
    {
   //     AircontrolsTutorial.SetActive(_Val);
    }

    public void set_StatusAicontrolsIndicators(bool _Val)
    {
      //  AircontrolsLeftIndicator.SetActive(_Val);
      // AircontrolsRightIndicator.SetActive(_Val);
    }

    public void set_statusLevelCounter()
    {
        LevelText.text = "LEVEL " + (Constants.Getprefs(Constants.lastselectedLevel) + 1).ToString();
    }
    public void set_Statuscheckpoint(bool _status/*, string _val*/)
    {
        //Checkpoint.text = _val.ToString();
        Checkpoint.transform.gameObject.SetActive(false);
        Checkpoint.transform.gameObject.SetActive(_status);
    }
    public void Set_PlayerHealth()
    {
        Time.timeScale = 1.0f;
        //HealthInjection.GetComponent<InjectionListner>().StartTimer();
    }

    #region ButtonListners
    int i = 0;
    public void set_StatusRadioMusic()
    {

       SoundsManager.Instance.PlayMusic_Game(i);
        i++;
        if (i >= SoundsManager.Instance.gameBG.Length)
        {
            i = 0;
        }
        //Debug.Log(i);
    }
    public void check_statuscontrols()
    {
        switch (Constants.SelectedControltype)
        {
            case Controls.Touch:
                setstatus_MobileController(0);
                break;
            case Controls.steering:
                setstatus_MobileController(1);
                break;
            case Controls.Gyro:
                setstatus_MobileController(2);
                break;
            default:
                setstatus_MobileController(0);
                break;
        }
    }
    public void setstatus_MobileController(int index)
    {

        switch (index)
        {

            case 0:
                RCC.SetMobileController(RCC_Settings.MobileController.TouchScreen);
                Constants.SelectedControltype = Controls.Touch;
                brake.transform.position = orgBrakeButtonPos;
                Steering.SetActive(false);
                Left.SetActive(true);
                right.SetActive(true);
                brake.SetActive(true);
                race.SetActive(true);
                Debug.Log("TouchScreen");
                break;

            case 1:
                RCC.SetMobileController(RCC_Settings.MobileController.SteeringWheel);
                Constants.SelectedControltype = Controls.steering;
                brake.transform.position = orgBrakeButtonPos;
                Steering.SetActive(true);
                Left.SetActive(false);
                right.SetActive(false);
                brake.SetActive(true);
                race.SetActive(true);
                Debug.Log("SteeringWheel");
                break;
            case 2:
                RCC.SetMobileController(RCC_Settings.MobileController.Gyro);
                Constants.SelectedControltype = Controls.Gyro;
                Steering.SetActive(false);
                Left.SetActive(false);
                right.SetActive(false);
                brake.SetActive(true);
                race.SetActive(true);
                brake.transform.position = Left.transform.position;
                Debug.Log("Gyro");
                break;
            default:
                RCC.SetMobileController(RCC_Settings.MobileController.TouchScreen);
                Constants.SelectedControltype = Controls.Touch;
                brake.transform.position = orgBrakeButtonPos;
                Steering.SetActive(false);
                Left.SetActive(true);
                right.SetActive(true);
                brake.SetActive(true);
                race.SetActive(true);
                Debug.Log("DefaultTouchScreen");
                break;
        }

    }
    public void OnPress_Pause()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Constants.FBAnalytic_EventDesign(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedLevel)) + "_" + Constants.Getprefs(Constants.lastselectedLevel).ToString() + "Pause_sPress") ;
        PausePanel.SetActive(true);
    }
    public void OnPress_Fail()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Constants.FBAnalytic_EventDesign(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedLevel)) + "_" + Constants.Getprefs(Constants.lastselectedLevel).ToString() + "Pause_sPress");
        FailPanel.SetActive(true);
    }
    public void OnPress_Complete()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Constants.FBAnalytic_EventDesign(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedLevel)) + "_" + Constants.Getprefs(Constants.lastselectedLevel).ToString() + "Pause_sPress");
        CompletePanel.SetActive(true);
    }
    public void OnPress_OkTutorial()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.GameUIclicks);
        Set_PlayerControls(true);
        handleplayerhud(true);
        SetStatus_SkipAnimationButton(false);
    }
    public void SkipSAnimations()
    {
        //Toolbox.CutsceneManager.SkipAnimation();
    }
    public void handleplayerhud(bool _Val)
    {
        PlayerHudCanvas.gameObject.SetActive(_Val);
    }
    public void onpress_Engine()
    {
        GameplayController.Instance.SelectedVehicleRccv3.StartEngine(true);
        Startengine.SetActive(false);
        handleplayerhud(true);
        Set_PlayerControls(true);
        pauseBtn.gameObject.SetActive(true);
    }
    public void OnPress_resetButton()
    {
       GameplayController.Instance.Resetvehicle();
    }
    #endregion

    #region Control System
    public static void onpress_Gas()
    {
        Throtle = 1f;
    }
    public static void onpress_ReleaseGas()
    {
        Throtle = 0f;
    }
    public static void onpress_Left()
    {
        steering = -1f;
        onpressleft = true; ;
    }
    public static void onpress_ReleaseLeft()
    {
        steering = 0f;
        onpressleft = false;
    }
    public static void onpress_Right()
    {
        steering = 1f;
        onpressright = true;
    }
    public static void onpress_ReleaseRight()
    {
        steering = 0f;
        onpressright = false;
    }
    public static void OnPress_Nos()
    {
        //if (Toolbox.GameplayController.SelectedVehicleRccv3.direction == -1)
        //    return;
        //Toolbox.GameplayController.SelectedVehicleRccv3.nos_IsActive = true;
        Boostinput = 2f;
        Throtle = 1f;
    }
    public static void OnPress_ReleaseNos()
    {
        //if (Toolbox.GameplayController.SelectedVehicleRccv3.direction == -1)
        //    return;
        //Toolbox.GameplayController.SelectedVehicleRccv3.nos_IsActive = false;
        Boostinput = 0f;
        Throtle = 0f;
    }
    public static void Onpress_Brake()
    {

        Brake = 1f;
        OnPress_ReleaseNos();
    }
    public static void Onpress_ReleaseBrake()
    {
        Brake = 0f;
    }
    public void Onpress_InstantBrake()
    {
        if (!RCCV3)
        {
        }
    }
    public void Onpress_ReleaseinstantBrake()
    {
    }
    public static void Resetconrtrol()
    {
        Throtle = 0f;
        Brake = 0f;
        steering = 0f;
        Boostinput = 0f;
        Handbrake = 0f;
        onpressleft = false;
        onpressright = false;
    }
    public void onpress_LeftIndicators()
    {
        if (GameplayController.Instance.SelectedVehicleRccv3)
        {

            if (GameplayController.Instance.SelectedVehicleRccv3.indicatorsOn != RCC_CarControllerV3.IndicatorsOn.Left)
            {
                GameplayController.Instance.SelectedVehicleRccv3.indicatorsOn = RCC_CarControllerV3.IndicatorsOn.Left;
                leftindicators.GetComponent<Image>().color = Color.yellow;
                Rightindicators.GetComponent<Image>().color = Color.white;
                print("onpress_LeftIndicators");
            }
            else
            {
                leftindicators.GetComponent<Image>().color = Color.white;
                GameplayController.Instance.SelectedVehicleRccv3.indicatorsOn = RCC_CarControllerV3.IndicatorsOn.Off;
            }

        }
    }
    public void onpress_RightIndicators()
    {
        if (GameplayController.Instance.SelectedVehicleRccv3)
        {
            if (GameplayController.Instance.SelectedVehicleRccv3.indicatorsOn != RCC_CarControllerV3.IndicatorsOn.Right)
            {
                GameplayController.Instance.SelectedVehicleRccv3.indicatorsOn = RCC_CarControllerV3.IndicatorsOn.Right;
                Rightindicators.GetComponent<Image>().color = Color.yellow;
                leftindicators.GetComponent<Image>().color = Color.white;
                print("onpress_RightIndicators");
            }
            else
            {
                Rightindicators.GetComponent<Image>().color = Color.white;
                GameplayController.Instance.SelectedVehicleRccv3.indicatorsOn = RCC_CarControllerV3.IndicatorsOn.Off;
            }
            
        }
    }
    public void Right_Indicators()
    {

    }
    #endregion

    #region FadeInout

    public void setstatus_FadeEffect(bool _val)
    {
        Fadeimage.SetActive(_val);
    }


    #endregion

  

}
