using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    TextMeshPro text;

    private void Start()
    {
        text = GetComponent<TextMeshPro>();
    }
}
