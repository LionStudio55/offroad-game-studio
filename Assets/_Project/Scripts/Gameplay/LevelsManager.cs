using UnityEngine;

//using UnityEngine.Scripting;
public class LevelsManager : MonoBehaviour
{


    private void Start()
    {
        LevelStartHandling();
    }
    private void LevelStartHandling()
    {
        LevelDataHandling();
        SpawnLevel();

    }

    private void SpawnLevel()
    {
        GameObject levelObj;
        levelObj = Resources.Load<GameObject>(Constants.folderPath_Prefabs + Constants.folderPath_Prefabs_Levels_Mode + Constants.Getprefs(Constants.lastselectedMode) + "/" + Constants.Getprefs(Constants.lastselectedLevel));
        Instantiate(levelObj, Vector3.zero, Quaternion.identity, this.transform);
    }

    private void LevelDataHandling()
    {
        print("Path :"+ Constants.folderPath_Scriptables + Constants.folderPath_Scriptables_Levels + Constants.Getprefs(Constants.lastselectedMode) + "/" + Constants.Getprefs(Constants.lastselectedLevel));
        GameplayController.Instance.SelectedLevelData = Resources.Load<LevelsData>(Constants.folderPath_Scriptables + Constants.folderPath_Scriptables_Levels + Constants.Getprefs(Constants.lastselectedMode) + "/" + Constants.Getprefs(Constants.lastselectedLevel));
        if (HUDListner.Instance && GameplayController.Instance)
            HUDListner.Instance.SetTotalLives(GameplayController.Instance.SelectedLevelData.Lives);
    }

}
