using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NextLevelUI : MonoBehaviour
{
    public GameObject levelStart, LevelEnd, pausePanel, pauseMenu;
    public Button pauseButton;
    public Animator player;
    public TextMeshProUGUI countdown;

    private float time = 3;
    private int count = 3;

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

    private void FixedUpdate()
    {
        Play();
    }

    public void Play()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
            countdown.SetText(time.ToString("0"));
        }
        else
        {
            countdown.SetText("GO!");
            StartCoroutine(SetFalse(0.5f));
            levelStart.gameObject.SetActive(false);
            player.enabled = true;
        }
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
    }

    IEnumerator Break(float time) 
    {
        yield return new WaitForSeconds(time);
        levelStart.GetComponent<Animator>().enabled = false;
    }

    IEnumerator SetFalse(float time)
    {
        yield return new WaitForSeconds(time);
        countdown.gameObject.SetActive(false);
    }
}