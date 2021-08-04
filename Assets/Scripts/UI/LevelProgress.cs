using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    public GameObject progressBar;
    public Slider slider;

    public Transform player, finish;

    float distance, normalizedDistance;

    private void Update()
    {
        CalculateDistance();
    }
    public void CalculateDistance()
    {
        float distance = player.position.x / finish.position.x;

        slider.value = distance;
    }
}
