using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public static void SavePlayer(SavePlayer player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.values";
        FileStream stream = new FileStream(path, FileMode.Create);

        Playerdata data = new Playerdata(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Playerdata LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.values";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Playerdata data = formatter.Deserialize(stream) as Playerdata;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
