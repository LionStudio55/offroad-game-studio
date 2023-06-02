using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : /*MonoBehaviour*/GenericSingletonClass<GameManager>
{
    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    #region Scene management
    public void Load_Scene(string scenename, float _delay)
    {
        StartCoroutine(CR_LoadScene(scenename, _delay));
    }
    public IEnumerator CR_LoadScene(string _sceneIndex, float duration)
    {

      Constants.Permanent_Logs("Loading Scene");
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(_sceneIndex);
    }
    #endregion

    public string Get_CurrentModeScenename()
    {
        switch(Constants.Getprefs(Constants.lastselectedMode))
        {
            case 0:
                return Constants.scenename_Mode1;
                break;
            case 1:
                return Constants.scenename_Mode2;
                break;
            case 2:
                return Constants.scenename_Mode3;
                break;
            case 3:
                return Constants.scenename_Mode4;
                break;
            case 4:
                return Constants.scenename_Mode5;
                break;
            default:
                return Constants.scenename_Mode1;
                break;

        }
    }
}
