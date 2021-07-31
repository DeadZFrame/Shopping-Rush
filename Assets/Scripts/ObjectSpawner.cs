using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Transform leftLayer, rightLayer, center;
    private float[] layerZ = new float[3];
    private float[] spawnX;
    private int[] randomX;
    public float distanceIndex;

    [SerializeField]
    private List<int> randomizer = new List<int>();

    Vector3 position;

    public int spawnCount;

    [System.NonSerialized]
    public bool spawned, _fixed = false;

    private void Start()
    {
        spawnX = new float[spawnCount];
        randomX = new int[spawnCount];
        IntersectFix();
        StartCoroutine(DelayAction(0.2f));
    }

    private void Update()
    {
        if(!spawned)
            SpawnRandomizer();
    }

    public IEnumerator DelayAction(float time)
    {
        if (spawned)
            yield break;

        yield return new WaitForSeconds(time);
        Spawner();
    }

    public void SpawnRandomizer()
    {
        layerZ[0] = leftLayer.position.z;
        layerZ[1] = center.position.z;
        layerZ[2] = rightLayer.position.z;
    }

    public void Spawner()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            position = new Vector3(spawnX[randomX[i]], 1, layerZ[Random.Range(0, 3)]);
            switch (i)
            {
                case 0: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.chicken, itemAmount = 1 }); break;
                case 1: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.bacon, itemAmount = 1 }); break;
                case 2: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.sausage, itemAmount = 1 }); break;
                case 3: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.steak, itemAmount = 1 }); break;
                case 4: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.egg, itemAmount = 1 }); break;
                case 5: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.pork, itemAmount = 1 }); break;
                default:
                    break;
            }
        }

        spawnX[0] = spawnX[spawnCount - 1];
        spawned = true;
    }

    public void IntersectFix()
    {
        for(int i = 0; i < spawnX.Length; i++)
        {
            if(i == 0)
                spawnX[i] = Random.Range(distanceIndex-20, distanceIndex);
            else
                spawnX[i] = spawnX[i - 1] + Random.Range(distanceIndex-20, distanceIndex);
        }

        for(int i = 0; i < randomX.Length; i++)
        {
            int randomIndex = Random.Range(0, randomizer.Count);
            randomX[i] = randomizer[randomIndex];
            randomizer.RemoveAt(randomIndex);
        }

        _fixed = true;
    }
}
