using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelUI : MonoBehaviour
{
    public GameObject levelStart, LevelEnd, pausePanel, pauseMenu;
    public Button playButton, pauseButton;
    public Animator player;

    private void Awake()
    {
        levelStart.GetComponent<Animator>();
        levelStart.SetActive(true);
    }

    private void Start()
    {
        StartCoroutine(Delay(1f));
        StartCoroutine(Break(2f));
    }

    public void PlayButton()
    {
        levelStart.SetActive(false);
        playButton.gameObject.SetActive(false);
        player.enabled = true;
        pauseButton.gameObject.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseButton.gameObject.SetActive(true);
        pauseMenu.SetActive(true);
        pausePanel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        pauseButton.gameObject.SetActive(true);
        pauseMenu.SetActive(false);
        pausePanel.SetActive(false);
    }

    public void Reload()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        levelStart.GetComponent<Animator>().enabled = true;
        playButton.gameObject.SetActive(true);
    }

    IEnumerator Break(float time) 
    {
        yield return new WaitForSeconds(time);
        levelStart.GetComponent<Animator>().enabled = false;
    }
}