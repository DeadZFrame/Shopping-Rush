using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingListManager : MonoBehaviour
{
    [SerializeField] private UI_Inventory uI;

    [System.NonSerialized] public int[] amounts;

    public int[] setamounts;

    [System.NonSerialized]
    public int steak, bacon, egg, chicken, pork, sausage,
        coke, coffee, iceTea, water, soda, energyDrink,
        flour, bread, cookie, donut, breadSticks, cupcake,
        cabbage, tomato, eggplant, carrot, onion, potato,
        apple, banana, waterMelon, blueberries, strawberry, mango,
        milk, chocolateMilk, cheese, iceCream, fruitYogurt, puding;

    [System.NonSerialized] public int extras;
    private int notEqual, timesCollided = 0;

    private void Start()
    {
        amounts = new int[setamounts.Length];
        Initialize();
    }

    public void Initialize()
    {
        for (int i = 0; i < setamounts.Length; i++)
        {
            amounts[i] = setamounts[i];
        }

        steak = 0; bacon = 1; egg = 2; chicken = 3; pork = 4; sausage = 5;
        coke = 6; coffee = 7; iceTea = 8; water = 9; soda = 10; energyDrink = 11;
        flour = 12; bread = 13; cookie = 14; donut = 15; breadSticks = 16; cupcake = 17;
        cabbage = 18; tomato = 19; eggplant = 20; carrot = 21; onion = 22; potato = 24;
        apple = 24; banana = 25; waterMelon = 26; blueberries = 27; strawberry = 28; mango = 29;
        milk = 30; chocolateMilk = 31; cheese = 32; iceCream = 33; fruitYogurt = 34; puding = 35;
    }

    private void OnTriggerEnter(Collider other)
    {
        timesCollided++;
        for (int i = 0; i < uI.listElements-1 ; i++)
        {
            if (!uI.itemName[i].text.Equals(other.name))
            {
                notEqual++; 
            }
            if (notEqual == 2)
            {
                extras++;
                uI.extraText.gameObject.SetActive(true);
                uI.extraAmount.gameObject.SetActive(true);
                uI.extraAmount.SetText("(" + extras.ToString() + ")");
                notEqual = 0;
            }
        }
        if (timesCollided == 1 && notEqual == 1)
            notEqual = 0;
        timesCollided = 0;

        if (other.name.Equals("Steak"))
            amounts[steak]--;    
        if (other.name.Equals("Bacon"))
            amounts[bacon]--;
        if (other.name.Equals("Egg"))
            amounts[egg]--;
        if (other.name.Equals("Chicken"))
            amounts[chicken]--;
        if (other.name.Equals("Pork"))
            amounts[pork]--;
        if (other.name.Equals("Sausage"))
            amounts[sausage]--;

        if (other.name.Equals("Coke"))
            amounts[coke]--;
        if (other.name.Equals("Coffee"))
            amounts[coffee]--;
        if (other.name.Equals("Ice Tea"))
            amounts[iceTea]--;
        if (other.name.Equals("Water"))
            amounts[water]--;
        if (other.name.Equals("Soda"))
            amounts[soda]--;
        if (other.name.Equals("Energy Drink"))
            amounts[energyDrink]--;

        if (other.name.Equals("Flour"))
            amounts[flour]--;
        if (other.name.Equals("Bread"))
            amounts[bread]--;
        if (other.name.Equals("Cookie"))
            amounts[cookie]--;
        if (other.name.Equals("Donut"))
            amounts[donut]--;
        if (other.name.Equals("Breadsticks"))
            amounts[breadSticks]--;
        if (other.name.Equals("Cupcake"))
            amounts[cupcake]--;

        if (other.name.Equals("Cabbage"))
            amounts[cabbage]--;
        if (other.name.Equals("Tomato"))
            amounts[tomato]--;
        if (other.name.Equals("Eggplant"))
            amounts[eggplant]--;
        if (other.name.Equals("Carrot"))
            amounts[carrot]--;
        if (other.name.Equals("Onion"))
            amounts[onion]--;
        if (other.name.Equals("Potato"))
            amounts[potato]--;

        if (other.name.Equals("Apple"))
            amounts[apple]--;
        if (other.name.Equals("Banana"))
            amounts[banana]--;
        if (other.name.Equals("Watermelon"))
            amounts[waterMelon]--;
        if (other.name.Equals("Blueberries"))
            amounts[blueberries]--;
        if (other.name.Equals("Strawberry"))
            amounts[strawberry]--;
        if (other.name.Equals("Mango"))
            amounts[mango]--;

        if (other.name.Equals("Milk"))
            amounts[milk]--;
        if (other.name.Equals("Chocolate Milk"))
            amounts[chocolateMilk]--;
        if (other.name.Equals("Cheese"))
            amounts[cheese]--;
        if (other.name.Equals("Ice Cream"))
            amounts[iceCream]--;
        if (other.name.Equals("Fruit Yogurt"))
            amounts[fruitYogurt]--;
        if (other.name.Equals("Pudding"))
            amounts[puding]--;
    }
}
