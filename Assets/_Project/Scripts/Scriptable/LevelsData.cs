using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/Level")]
public class LevelsData : ScriptableObject
{
    public int Lives = 3;
    public bool Hascutscene = true;
    public string Missionstatement;
  
}

