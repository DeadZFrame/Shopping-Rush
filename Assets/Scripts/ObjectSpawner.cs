using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Transform leftLayer, rightLayer, center;
    private float[] layerZ = new float[3];
    private float standLayerLeft, standLayerRight;
    private float[] spawnX;
    private int[] randomX;
    public float distanceIndex;

    [SerializeField]
    private List<int> randomizer = new List<int>();

    Vector3 position, leftStandPosition, rightStandPosition;
    private float standX = -15f;

    public int itemSpawnCount, standSpawnCount, sameItemSpawnCount;
    private int x;
    private int sameItemSpawnCountControl = 1;

    [System.NonSerialized]
    public bool spawned, _fixed = false;

    int switchIndex;
    bool regenerated = false;
    bool firstSpawn = true;

    private void Start()
    {
        spawnX = new float[itemSpawnCount*sameItemSpawnCount];
        randomX = new int[itemSpawnCount*sameItemSpawnCount];
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
        standLayerLeft = leftLayer.position.z + 2.2f;
        standLayerRight = rightLayer.position.z - 2.2f;
    }

    public void Spawner()
    {
        for (int i = 0; i < itemSpawnCount; i++)
        {
            while (x < itemSpawnCount * sameItemSpawnCount)
            {
                position = new Vector3(spawnX[randomX[x]], 1, layerZ[Random.Range(0, 3)]);
                x++;
                break;
            }
            
            switch (i)
            {
                case 0: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.chicken}); break;
                case 1: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.bacon}); break;
                case 2: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.sausage}); break;
                case 3: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.steak}); break;
                case 4: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.egg}); break;
                case 5: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.pork}); break;

                case 6: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.apple }); break;
                case 7: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.banana }); break;
                case 8: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.blueberries }); break;
                case 9: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.mango }); break;
                case 10: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.strawberry }); break;
                case 11: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.waterMelon }); break;

                case 12: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.tomato }); break;
                case 13: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.potato }); break;
                case 14: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.onion }); break;
                case 15: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.eggplant }); break;
                case 16: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.carrot }); break;
                case 17: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.cabbage }); break;

                case 18: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.water }); break;
                case 19: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.coffee }); break;
                case 20: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.coke }); break;
                case 21: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.energyDrink }); break;
                case 22: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.iceTea }); break;
                case 23: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.soda }); break;

                case 24: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.puding }); break;
                case 25: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.milk }); break;
                case 26: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.iceCream }); break;
                case 27: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.fruitYogurt }); break;
                case 28: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.chocolateMilk }); break;
                case 29: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.cheese }); break;

                case 30: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.bread }); break;
                case 31: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.breadSticks }); break;
                case 32: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.cookie }); break;
                case 33: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.cupcake }); break;
                case 34: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.donut }); break;
                case 35: ItemWorld.SpawnItemWorld(position, new Item { itemTypes = Item.ItemTypes.flourSack }); break;
                default:
                    break;
            }
            if (i == itemSpawnCount - 1 && sameItemSpawnCountControl < sameItemSpawnCount)
            {
                sameItemSpawnCountControl++;
                i = 0;
            }
        }
        x = 0;

        for (int i = 0; i < standSpawnCount; i++)
        {
            leftStandPosition = new Vector3(standX, 0.5f, standLayerLeft);
            rightStandPosition = new Vector3(standX, 0.5f, standLayerRight);

            while (x == 0)
            {
                if (i % 5 == 5)
                    regenerated = true;

                if(regenerated)
                    switchIndex = Random.Range(0, 6);
                else if (firstSpawn)
                    switchIndex = Random.Range(0, 6);

                regenerated = false;
                switch (switchIndex)
                {
                    default:
                        break;
                    case 0:
                        StandWorld.SpawnStandWorld(leftStandPosition, new Item { standTypes = Item.StandTypes.fruitStandL });
                        StandWorld.SpawnStandWorld(rightStandPosition, new Item { standTypes = Item.StandTypes.vegetableStandR });
                        break;
                    case 1:
                        StandWorld.SpawnStandWorld(leftStandPosition, new Item { standTypes = Item.StandTypes.vegetableStandL });
                        StandWorld.SpawnStandWorld(rightStandPosition, new Item { standTypes = Item.StandTypes.fruitStandR });
                        break;
                    case 2:
                        StandWorld.SpawnStandWorld(leftStandPosition, new Item { standTypes = Item.StandTypes.drinkFridgeL });
                        StandWorld.SpawnStandWorld(rightStandPosition, new Item { standTypes = Item.StandTypes.milkFridgeR });
                        break;
                    case 3:
                        StandWorld.SpawnStandWorld(leftStandPosition, new Item { standTypes = Item.StandTypes.milkFridgeL });
                        StandWorld.SpawnStandWorld(rightStandPosition, new Item { standTypes = Item.StandTypes.drinkFridgeR });
                        break;
                    case 4:
                        StandWorld.SpawnStandWorld(leftStandPosition, new Item { standTypes = Item.StandTypes.flourStandL });
                        StandWorld.SpawnStandWorld(rightStandPosition, new Item { standTypes = Item.StandTypes.meatStandR });
                        break;
                    case 5:
                        StandWorld.SpawnStandWorld(leftStandPosition, new Item { standTypes = Item.StandTypes.meatStandL });
                        StandWorld.SpawnStandWorld(rightStandPosition, new Item { standTypes = Item.StandTypes.flourStandR });
                        break;
                }

                x++;
            }
            standX = standX + 10f;
            x = 0;
        }
        spawnX[0] = spawnX[itemSpawnCount*sameItemSpawnCount - 1];
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
