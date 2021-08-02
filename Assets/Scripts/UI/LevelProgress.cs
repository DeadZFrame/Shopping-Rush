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

    private void Awake()
    {

        
    }

    private void Update()
    {
        CalculateDistance();
    }
    public void CalculateDistance()
    {
        distance = Vector3.Distance(player.position, finish.position);
        normalizedDistance = Mathf.InverseLerp(player.position.x, finish.position.x, distance);

        normalizedDistance = 1f - normalizedDistance;

        slider.value = normalizedDistance;
    }
}
