using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Firebase;
using Firebase.Analytics;
using UnityEngine.Networking;
public class FirebaseHandler : MonoBehaviour
{
   
    public static FirebaseHandler instance;
	private bool NetworkService;
	private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                var dependencyStatus = task.Result;
                if (dependencyStatus == Firebase.DependencyStatus.Available)
                {
                    // Create and hold a reference to your FirebaseApp,
                    // where app is a Firebase.FirebaseApp property of your application class.
                    Firebase.FirebaseApp app = Firebase.FirebaseApp.DefaultInstance;

                    // Set a flag here to indicate whether Firebase is ready to use by your app.
                    FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
				//	Debug.LogError(" resolve all Firebase dependencies");
					
				}
				else
                {
                    UnityEngine.Debug.LogError(System.String.Format(
                      "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                    // Firebase Unity SDK is not safe to use here.
                }
            });
          
        }
		if (CheckInternet())
			return;
	}

	public void logLevelStarted(string Mode)
	{

		if (!CheckInternet())
			return;

		try
		{
			Firebase.Analytics.FirebaseAnalytics.LogEvent("Mode_started_" + Mode );
			Debug.Log("Analytics: level_started" + Mode);

		}
		catch (Exception e)
		{
			Debug.Log("Analytics: Error in Analytics: " + e.ToString());

		}

	}

	public  void logLevelStarted(string Mode, string levelNo)
	{

		if (!CheckInternet())
			return;

		try
		{
			Firebase.Analytics.FirebaseAnalytics.LogEvent("Mode_started_" + Mode + "level_started_" + levelNo);
			Debug.Log("Analytics: level_started" + Mode + "_" + levelNo);
			
		}
		catch (Exception e)
		{
			Debug.Log("Analytics: Error in Analytics: " + e.ToString());

		}

	}



	public void logLevelCompleted( string levelNo)
	{
		if (!CheckInternet())
			return;
		try
		{
			Firebase.Analytics.FirebaseAnalytics.LogEvent( "Level_completed_" + levelNo);
			Debug.Log("Analytics: level_completed_" + levelNo);

		}
		catch (Exception e)
		{
			Debug.Log("Analytics: Error in Analytics: " + e.ToString());

		}
	}



	public  void logLevelCompleted(string Mode, string levelNo)
	{
		if (!CheckInternet())
			return;
		try
		{
			Firebase.Analytics.FirebaseAnalytics.LogEvent("Mode_completed_" + Mode + "Level_completed_" + levelNo);
			Debug.Log("Analytics: level_completed_" + Mode + "_" + levelNo);

		}
		catch (Exception e)
		{
			Debug.Log("Analytics: Error in Analytics: " + e.ToString());

		}
	}

	public void logLevelFailed(int levelNo)
	{
		if (!CheckInternet())

			try
			{
				Firebase.Analytics.FirebaseAnalytics.LogEvent("level_failed_" + levelNo);
				Debug.Log("Analytics: level_failed_" + levelNo);
			}
			catch (Exception e)
			{
				Debug.Log("Analytics: Error in Analytics: " + e.ToString());

			}

	}

	public void logLevelFailed(string Mode, string levelNo)
	{
		if (!CheckInternet())
			return;
		try
		{
			Firebase.Analytics.FirebaseAnalytics.LogEvent("Mode_Failed_" + Mode + "Level_Failed_" + levelNo);
			Debug.Log("Analytics: level_Failed_" + Mode + "_" + levelNo);

		}
		catch (Exception e)
		{
			Debug.Log("Analytics: Error in Analytics: " + e.ToString());

		}
	}

	public bool CheckInternet()
	{


		StartCoroutine(CheckInternetConnection(isConnected =>
		{

			NetworkService = isConnected;

		}));
		return NetworkService;
	}

	IEnumerator CheckInternetConnection(Action<bool> action)
	{
		UnityWebRequest request = new UnityWebRequest("http://google.com");
		yield return request.SendWebRequest();
		action(!request.isNetworkError && !request.isHttpError && request.responseCode == 200);


	}


}
