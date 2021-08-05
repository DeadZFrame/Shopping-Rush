using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        for(int i = 0; i < sprites.Length; i++)
        {
            //sprites[i] = GetComponent<Sprite>();
        }
    }

    public Transform itemWorld;
    public Transform standWorld;

    public GameObject[] meat;
    public GameObject[] milk;
    public GameObject[] fruit;
    public GameObject[] vegetable;
    public GameObject[] flour;
    public GameObject[] drinks;
    public GameObject[] stands;

    public Sprite[] sprites;
}
