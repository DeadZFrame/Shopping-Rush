using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandWorld : MonoBehaviour
{
    public static StandWorld SpawnStandWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.standWorld, position, Quaternion.identity);

        StandWorld standWorld = transform.GetComponent<StandWorld>();
        standWorld.SetItem(item);

        return standWorld;
    }

    private Item item;
    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;
    private Transform trans;
    private BoxCollider coll;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        trans = GetComponent<Transform>();
        coll = GetComponent<BoxCollider>();
    }

    private void SetItem(Item item)
    {
        this.item = item;
        meshFilter.sharedMesh = item.GetStand().GetComponent<MeshFilter>().sharedMesh;
        meshRenderer.sharedMaterials = item.GetStand().GetComponent<MeshRenderer>().sharedMaterials;
        trans.localScale = item.GetStand().GetComponent<Transform>().localScale;
        trans.rotation = item.GetStand().GetComponent<Transform>().rotation;

    }

    public Item GetItem()
    {
        return item;
    }
}
