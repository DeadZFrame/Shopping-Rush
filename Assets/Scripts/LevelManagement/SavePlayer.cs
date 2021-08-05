using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    public int level;

    public void Save()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        Playerdata data = SaveSystem.LoadPlayer();

        level = data.level;
    }
}
