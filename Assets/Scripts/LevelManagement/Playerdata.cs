using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Playerdata
{
    public int level;

    public Playerdata(SavePlayer player)
    {
        level = player.level;
    }

    //public void PlayerData (LevelLoader level)
    //{
    //    SceneIndex = level.sceneIndex;
    //}
}