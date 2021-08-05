using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    SavePlayer save;

    public int sceneIndex = 0;

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            save.level = sceneIndex;
            save.Save();
        }
    }

    private void Awake()
    {
        save.LoadPlayer();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void SetSave(SavePlayer save)
    {
        this.save = save;
    }
}
