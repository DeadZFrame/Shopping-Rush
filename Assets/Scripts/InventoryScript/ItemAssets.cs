using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform itemWorld;

    public GameObject[] meat;
    public GameObject[] milk;
    public GameObject[] fruit;
    public GameObject[] vegetable;
    public GameObject[] flour;
    public GameObject[] drinks;
}
