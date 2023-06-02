using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class QualitySettingsAdjuster : MonoBehaviour 
{
	public enum SceneType {Mainmenu,Gameplay};
	public SceneType thisSceneType;

	public float currentFrameRate;
	public float timerForFPS_Low;
	private float updateRate = 1.0f;
	private float accum = 0; // FPS accumulated over the interval
	private int frames = 0; // Frames drawn over the interval
	private float timeleft; // Left time for current interval

	private int counter;
	private float timer;
	private float screenWidth;
	private float screenHeight;

    public Text fpsCounterLabel;

    public void Awake()
	{
		Screen.fullScreen = true;
		
		if (PlayerPrefs.HasKey ("GotOriginals")) {
			screenWidth = PlayerPrefs.GetInt ("OriginalResolutionWidth");
			screenHeight = PlayerPrefs.GetInt ("OriginalResolutionHeight");
		} else {
			GetOriginalResolution ();
		}

		if (thisSceneType == SceneType.Gameplay) {
			if (PlayerPrefs.HasKey ("ScreenResolutionWidth")) {
				Screen.SetResolution (PlayerPrefs.GetInt ("ScreenResolutionWidth"), PlayerPrefs.GetInt ("ScreenResolutionHeight"), false);
			}

			if (PlayerPrefs.HasKey ("ScreenResolutionCounter"))
				counter = PlayerPrefs.GetInt ("ScreenResolutionCounter");
			else
				counter = 0;
		} else {
			if (PlayerPrefs.HasKey ("GotOriginals")) {
				Screen.SetResolution (PlayerPrefs.GetInt ("OriginalResolutionWidth"), PlayerPrefs.GetInt ("OriginalResolutionHeight"), false);
			}
		}
	}

	public void GetOriginalResolution()
	{
		screenWidth = Screen.currentResolution.width;
		screenHeight = Screen.currentResolution.height;
		PlayerPrefs.SetInt ("OriginalResolutionWidth",Screen.currentResolution.width);
		PlayerPrefs.SetInt ("OriginalResolutionHeight",Screen.currentResolution.height);
		PlayerPrefs.SetInt ("GotOriginals", 1);
	}

	void Start () 
	{
		Time.fixedDeltaTime = 0.0334f;
	}

	void Update ()
	{
       // fpsCounterLabel.text = currentFrameRate.ToString("F0");

        timeleft -= Time.deltaTime;
		accum += Time.timeScale/Time.deltaTime;
		++frames;
		if (timeleft <= 0.0) StartNewInterval();

		if (thisSceneType == SceneType.Gameplay) {
			//if (!GameplayHandler.gameOver) {
				if (currentFrameRate < 20) {
					timer += Time.deltaTime;
					if (timer >= timerForFPS_Low) {
						timer = 0;
						if (counter <= 3)
							AdjustResolution ();
					//}
				}
			}
		}
	}
    private void StartNewInterval(){
		currentFrameRate = accum/frames;
		ResetTimeLeft();
		accum = 0.0F;
		frames = 0;
	}

	public void ResetTimeLeft(){
		timeleft = 1.0f/updateRate;
	}

	public void AdjustResolution()
	{
		switch (counter) {
		case 0:
			Screen.SetResolution (Mathf.FloorToInt (screenWidth * 0.9f), Mathf.FloorToInt (screenHeight * 0.9f), false);
			counter++;
			PlayerPrefs.SetInt ("ScreenResolutionWidth", Mathf.FloorToInt (screenWidth * 0.9f));
			PlayerPrefs.SetInt ("ScreenResolutionHeight", Mathf.FloorToInt (screenHeight * 0.9f));
			PlayerPrefs.SetInt ("ScreenResolutionCounter", counter);
			break;
		case 1:
			Screen.SetResolution (Mathf.FloorToInt(screenWidth * 0.8f), Mathf.FloorToInt(screenHeight * 0.8f),false);
			PlayerPrefs.SetInt ("ScreenResolutionWidth", Mathf.FloorToInt (screenWidth * 0.8f));
			PlayerPrefs.SetInt ("ScreenResolutionHeight", Mathf.FloorToInt (screenHeight * 0.8f));
			PlayerPrefs.SetInt ("ScreenResolutionCounter", counter);
			counter++;
			break;
		case 2:
			Screen.SetResolution (Mathf.FloorToInt(screenWidth * 0.7f), Mathf.FloorToInt(screenHeight * 0.7f),false);
			PlayerPrefs.SetInt ("ScreenResolutionWidth", Mathf.FloorToInt (screenWidth * 0.7f));
			PlayerPrefs.SetInt ("ScreenResolutionHeight", Mathf.FloorToInt (screenHeight * 0.7f));
			PlayerPrefs.SetInt ("ScreenResolutionCounter", counter);
			counter++;
			break;
		case 3:
			Screen.SetResolution (Mathf.FloorToInt(screenWidth * 0.6f), Mathf.FloorToInt(screenHeight * 0.6f),false);
			PlayerPrefs.SetInt ("ScreenResolutionWidth", Mathf.FloorToInt (screenWidth * 0.6f));
			PlayerPrefs.SetInt ("ScreenResolutionHeight", Mathf.FloorToInt (screenHeight * 0.6f));
			PlayerPrefs.SetInt ("ScreenResolutionCounter", counter);
			counter++;
			break;
		}
	}

//	private void OnGUI(){
//		ShowFpsInCorner();
//	}

	const int FPS_BOX_WIDTH = 420;
	const int FPS_BOX_HEIGHT = 64;

	private void ShowFpsInCorner(){
			var fpsTextStyle = new GUIStyle (GUI.skin.box) {
				fontSize = 22,
				alignment = TextAnchor.MiddleCenter,
				richText = true
			};
		var txt = string.Format (currentFrameRate.ToString ("0") + " :  Level " + counter.ToString () + " : (" + screenWidth.ToString() + "x" + screenHeight.ToString() + ") : " + Screen.currentResolution.width.ToString () + "x" + Screen.currentResolution.height.ToString ());
			GUI.Box (new Rect (0, 0, FPS_BOX_WIDTH, FPS_BOX_HEIGHT), txt, fpsTextStyle);
	}

	public void UseOptimalResolution()
	{
		if (PlayerPrefs.HasKey ("ScreenResolutionWidth")) {
			Screen.SetResolution (PlayerPrefs.GetInt ("ScreenResolutionWidth"), PlayerPrefs.GetInt ("ScreenResolutionHeight"), false);
		}
	}

	public void UseOriginalResolution()
	{
		if (PlayerPrefs.HasKey ("GotOriginals")) {
			Screen.SetResolution (PlayerPrefs.GetInt ("OriginalResolutionWidth"), PlayerPrefs.GetInt ("OriginalResolutionHeight"), false);
		}
	}

	public void QualityChange()
	{
		if (PlayerPrefs.HasKey ("GotOriginals")) {
			Screen.SetResolution (PlayerPrefs.GetInt ("OriginalResolutionWidth"), PlayerPrefs.GetInt ("OriginalResolutionHeight"), false);
			PlayerPrefs.DeleteKey ("ScreenResolutionWidth");
			PlayerPrefs.DeleteKey ("ScreenResolutionCounter");
		}
		counter = 0;
		timer = 0;
	}
}
