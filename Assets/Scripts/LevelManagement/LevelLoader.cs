using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public int sceneIndex = 0;

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
