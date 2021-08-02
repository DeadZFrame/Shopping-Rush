using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemTypes
    {

        steak, bacon, egg, chicken, pork, sausage,
        coke, coffee, iceTea, water, soda, energyDrink,
        flourSack, bread, cookie, donut, breadSticks, cupcake,
        cabbage, tomato, eggplant, carrot, onion, potato,
        apple, banana, waterMelon, blueberries, strawberry, mango,
        milk, chocolateMilk, cheese, iceCream, fruitYogurt, puding,
    }

    public enum StandTypes
    {
        drinkFridgeL, fruitStandL, meatStandL, milkFridgeL, vegetableStandL, flourStandL,
        drinkFridgeR, fruitStandR, meatStandR, milkFridgeR, vegetableStandR, flourStandR,
    }
    public ItemTypes itemTypes;
    public StandTypes standTypes;

    public GameObject GetGameObject()
    {
        switch (itemTypes)
        {
            default:
            case ItemTypes.steak: return ItemAssets.Instance.meat[0];
            case ItemTypes.bacon: return ItemAssets.Instance.meat[1];
            case ItemTypes.egg: return ItemAssets.Instance.meat[2];
            case ItemTypes.chicken: return ItemAssets.Instance.meat[3];
            case ItemTypes.pork: return ItemAssets.Instance.meat[4];
            case ItemTypes.sausage: return ItemAssets.Instance.meat[5];
            case ItemTypes.coke: return ItemAssets.Instance.drinks[0];
            case ItemTypes.soda: return ItemAssets.Instance.drinks[1];
            case ItemTypes.coffee: return ItemAssets.Instance.drinks[2];
            case ItemTypes.iceTea: return ItemAssets.Instance.drinks[3];
            case ItemTypes.water: return ItemAssets.Instance.drinks[4];
            case ItemTypes.energyDrink: return ItemAssets.Instance.drinks[5];
            case ItemTypes.flourSack: return ItemAssets.Instance.flour[0];
            case ItemTypes.bread: return ItemAssets.Instance.flour[1];
            case ItemTypes.cookie: return ItemAssets.Instance.flour[2];
            case ItemTypes.donut: return ItemAssets.Instance.flour[3];
            case ItemTypes.breadSticks: return ItemAssets.Instance.flour[4];
            case ItemTypes.cupcake: return ItemAssets.Instance.flour[5];
            case ItemTypes.cabbage: return ItemAssets.Instance.vegetable[0];
            case ItemTypes.tomato: return ItemAssets.Instance.vegetable[1];
            case ItemTypes.eggplant: return ItemAssets.Instance.vegetable[2];
            case ItemTypes.carrot: return ItemAssets.Instance.vegetable[3];
            case ItemTypes.onion: return ItemAssets.Instance.vegetable[4];
            case ItemTypes.potato: return ItemAssets.Instance.vegetable[5];
            case ItemTypes.apple: return ItemAssets.Instance.fruit[0];
            case ItemTypes.banana: return ItemAssets.Instance.fruit[1];
            case ItemTypes.waterMelon: return ItemAssets.Instance.fruit[2];
            case ItemTypes.blueberries: return ItemAssets.Instance.fruit[3];
            case ItemTypes.strawberry: return ItemAssets.Instance.fruit[4];
            case ItemTypes.mango: return ItemAssets.Instance.fruit[5];
            case ItemTypes.milk: return ItemAssets.Instance.milk[0];
            case ItemTypes.chocolateMilk: return ItemAssets.Instance.milk[1];
            case ItemTypes.cheese: return ItemAssets.Instance.milk[2];
            case ItemTypes.iceCream: return ItemAssets.Instance.milk[3];
            case ItemTypes.fruitYogurt: return ItemAssets.Instance.milk[4];
            case ItemTypes.puding: return ItemAssets.Instance.milk[5];
        }
    }

    public GameObject GetStand()
    {
        switch (standTypes)
        {
            default:
            case StandTypes.drinkFridgeL: return ItemAssets.Instance.standsLeft[0];
            case StandTypes.fruitStandL: return ItemAssets.Instance.standsLeft[1];
            case StandTypes.meatStandL: return ItemAssets.Instance.standsLeft[2];
            case StandTypes.milkFridgeL: return ItemAssets.Instance.standsLeft[3];
            case StandTypes.vegetableStandL: return ItemAssets.Instance.standsLeft[4];
            case StandTypes.flourStandL: return ItemAssets.Instance.standsLeft[5];
            case StandTypes.drinkFridgeR: return ItemAssets.Instance.standsRight[0];
            case StandTypes.fruitStandR: return ItemAssets.Instance.standsRight[1];
            case StandTypes.meatStandR: return ItemAssets.Instance.standsRight[2];
            case StandTypes.milkFridgeR: return ItemAssets.Instance.standsRight[3];
            case StandTypes.vegetableStandR: return ItemAssets.Instance.standsRight[4];
            case StandTypes.flourStandR: return ItemAssets.Instance.standsRight[5];
        }
    }
}
