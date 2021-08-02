using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Playerdata
{
    public int SceneIndex;
    private LevelLoader level;

    public Playerdata(LevelLoader level)
    {
        this.level = level;
    }

    public void PlayerData (LevelLoader level)
    {
        SceneIndex = level.sceneIndex;
    }
}