using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        drinkFridge, fruitStand, meatStand, milkFridge, vegetableStand, flourStand,
        blueMan, forklift, crate
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
            case StandTypes.drinkFridge: return ItemAssets.Instance.stands[0];
            case StandTypes.fruitStand: return ItemAssets.Instance.stands[1];
            case StandTypes.meatStand: return ItemAssets.Instance.stands[2];
            case StandTypes.milkFridge: return ItemAssets.Instance.stands[3];
            case StandTypes.vegetableStand: return ItemAssets.Instance.stands[4];
            case StandTypes.flourStand: return ItemAssets.Instance.stands[5];
            case StandTypes.blueMan: return ItemAssets.Instance.obstacles[0];
            case StandTypes.forklift: return ItemAssets.Instance.obstacles[1];
            case StandTypes.crate: return ItemAssets.Instance.obstacles[2];
        }
    }
}
