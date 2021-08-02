using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelUI : MonoBehaviour
{
    public GameObject levelStart, LevelEnd;
    public Button playButton, nextLevelButton;
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
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        levelStart.GetComponent<Animator>().enabled = true;
        playButton.gameObject.SetActive(true);
        yield break;
    }

    IEnumerator Break(float time) 
    {
        yield return new WaitForSeconds(time);
        levelStart.GetComponent<Animator>().enabled = false;
        yield break;
    }
}