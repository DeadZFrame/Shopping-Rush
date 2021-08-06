using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingListManager : MonoBehaviour
{
    private UI_Inventory uI;
    private LevelLoader levelLoader;

    [System.NonSerialized] public int[] amounts;

    public int[] setamounts;

    [System.NonSerialized]
    public int steak, bacon, egg, chicken, pork, sausage,
        coke, coffee, iceTea, water, soda, energyDrink,
        flour, bread, cookie, donut, breadSticks, cupcake,
        cabbage, tomato, eggplant, carrot, onion, potato,
        apple, banana, waterMelon, blueberries, strawberry, mango,
        milk, chocolateMilk, cheese, iceCream, fruitYogurt, puding;

    [System.NonSerialized] public float money, infliation, price;

    private void Awake()
    {
        levelLoader = GameObject.Find("LevelManager").GetComponent<LevelLoader>();
        uI = FindObjectOfType<UI_Inventory>();
    }

    private void Start()
    {
        amounts = new int[setamounts.Length];
        Initialize();
        ShoppingList();
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
        cabbage = 18; tomato = 19; eggplant = 20; carrot = 21; onion = 22; potato = 23;
        apple = 24; banana = 25; waterMelon = 26; blueberries = 27; strawberry = 28; mango = 29;
        milk = 30; chocolateMilk = 31; cheese = 32; iceCream = 33; fruitYogurt = 34; puding = 35;
    }

    public void ShoppingList()
    {
        if (levelLoader.sceneIndex == 0)
        {
            amounts[apple] = 2;
            amounts[strawberry] = 1;
            money = 6f;
        }
        if (levelLoader.sceneIndex == 1)
        {
            amounts[potato] = 2;
            amounts[waterMelon] = 1;
            amounts[donut] = 2;

            money = 15f;
        }
        if (levelLoader.sceneIndex == 2)
        {
            amounts[pork] = 2;
            amounts[mango] = 1;
            amounts[coffee] = 1;
            amounts[milk] = 2;

            money = 24f;
        }
        if (levelLoader.sceneIndex == 3)
        {
            amounts[energyDrink] = 1;
            amounts[cookie] = 1;
            amounts[blueberries] = 1;
            amounts[cheese] = 2;
            money = 16f;
        }
        if (levelLoader.sceneIndex == 4)
        {
            amounts[coke] = 2;
            amounts[cupcake] = 1;
            amounts[onion] = 2;
            amounts[chicken] = 1;
            money = 22f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.name.Equals("Steak"))
        {
            amounts[steak]--;
            price = 10f;
        }
        if (other.name.Equals("Bacon"))
        {
            price = 5f;
            amounts[bacon]--;
        }
        if (other.name.Equals("Egg"))
        {
            amounts[egg]--;
            price = 0.5f;
        }
        if (other.name.Equals("Chicken"))
        {
            amounts[chicken]--;
            price = 10f;
        }
        if (other.name.Equals("Pork"))
        {
            amounts[pork]--;
            price = 7f;
        }
        if (other.name.Equals("Sausage"))
        {
            amounts[sausage]--;
            price = 3f;
        }


        if (other.name.Equals("Coke"))
        {
            amounts[coke]--;
            price = 2f;
        }
        if (other.name.Equals("Coffee"))
        {
            amounts[coffee]--;
            price = 1.5f;
        }
        if (other.name.Equals("Ice Tea"))
        {
            amounts[iceTea]--;
            price = 2f;
        }
        if (other.name.Equals("Water"))
        {
            amounts[water]--;
            price = 0.5f;
        }
        if (other.name.Equals("Soda"))
        {
            amounts[soda]--;
            price = 2f;
        }
        if (other.name.Equals("Energy Drink"))
        {
            amounts[energyDrink]--;
            price = 4f;
        }


        if (other.name.Equals("Flour"))
        {
            amounts[flour]--;
            price = 1f;
        } 
        if (other.name.Equals("Bread"))
        {
            amounts[bread]--;
            price = 2.50f;
        }
        if (other.name.Equals("Cookie"))
        {
            amounts[cookie]--;
            price = 4f;
        }     
        if (other.name.Equals("Donut"))
        {
            amounts[donut]--;
            price = 3f;
        }    
        if (other.name.Equals("Breadsticks"))
        {
            amounts[breadSticks]--;
            price = 3f;
        }  
        if (other.name.Equals("Cupcake"))
        {
            amounts[cupcake]--;
            price = 3f;
        }
            

        if (other.name.Equals("Cabbage"))
        {
            amounts[cabbage]--;
            price = 1f;
        }
        if (other.name.Equals("Tomato"))
        {
            amounts[tomato]--;
            price = 2f;
        }
        if (other.name.Equals("Eggplant"))
        {
            amounts[eggplant]--;
            price = 1f;
        }
        if (other.name.Equals("Carrot"))
        {
            amounts[carrot]--;
            price = 1f;
        }   
        if (other.name.Equals("Onion"))
        {
            amounts[onion]--;
            price = 1f;
        }     
        if (other.name.Equals("Potato"))
        {
            amounts[potato]--;
            price = 1f;
        }
            

        if (other.name.Equals("Apple"))
        {
            amounts[apple]--;
            price = 1f;
        }      
        if (other.name.Equals("Banana"))
        {
            amounts[banana]--;
            price = 1f;
        }    
        if (other.name.Equals("Watermelon"))
        {
            amounts[waterMelon]--;
            price = 3f;
        }
        if (other.name.Equals("Blueberry"))
        {
            amounts[blueberries]--;
            price = 1f;
        }
        if (other.name.Equals("Strawberry"))
        {
            amounts[strawberry]--;
            price = 1f;
        }
        if (other.name.Equals("Mango"))
        {
            amounts[mango]--;
            price = 2f;
        }
            

        if (other.name.Equals("Milk"))
        {
            amounts[milk]--;
            price = 2f;
        }
        if (other.name.Equals("Chocolate Milk"))
        {
            amounts[chocolateMilk]--;
            price = 2f;
        }
        if (other.name.Equals("Cheese"))
        {
            amounts[cheese]--;
            price = 2f;
        }
        if (other.name.Equals("Ice Cream"))
        {
            amounts[iceCream]--;
            price = 2f;
        }
        if (other.name.Equals("Fruit Yogurt"))
        {
            amounts[fruitYogurt]--;
            price = 2f;
        }
        if (other.name.Equals("Pudding"))
        {
            amounts[puding]--;
            price = 2f;
        }

        if (other.tag.Equals("item") || other.tag.Equals("Stand"))
        {
            uI.floatingText.gameObject.SetActive(false);
            uI.floatingText.gameObject.SetActive(true);
            uI.floatingText.SetText("-$" + price.ToString());
        }
        money -= price;
        price = 0f;
    }
}
