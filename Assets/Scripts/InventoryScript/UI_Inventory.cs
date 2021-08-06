using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private ShoppingListManager shopping;
    private ItemAssets itemAssets;
    private LevelLoader levelLoader;

    public Image[] itemSprite;
    public TextMeshProUGUI[] amount;
    public TextMeshProUGUI money;
    public TextMeshPro floatingText;
    public Image[] tick;
    public int listElements;

    private void Awake()
    {
        money.GetComponent<TextMeshProUGUI>();
        floatingText.GetComponent<TextMeshPro>();
        shopping = FindObjectOfType<ShoppingListManager>();
        for (int i = 0; i< itemSprite.Length; i++)
        {
            itemSprite[i].GetComponent<Sprite>();
            itemSprite[i].GetComponent<Image>();
            amount[i].GetComponent<TextMeshProUGUI>();
            tick[i].GetComponent<Image>();
        }
        levelLoader = GameObject.Find("LevelManager").GetComponent<LevelLoader>();

    }

    private void Update()
    {
        ShoppingListToUI();
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void ShoppingListToUI()
    {
        if(shopping.money < 0)
        {
            money.color = new Color(255, 0, 0);
        }
        else
        {
            money.color = new Color(0, 255, 0);
        }
        money.SetText("$" + shopping.money);

        if(levelLoader.sceneIndex==0)
        {
            if (shopping.amounts[shopping.apple] > 0)
                amount[0].SetText("x" + shopping.amounts[shopping.apple].ToString());
            else
            {
                amount[0].gameObject.SetActive(false);
                tick[0].enabled = true;
            }

            if (shopping.amounts[shopping.strawberry] > 0)
                amount[1].SetText("x" + shopping.amounts[shopping.strawberry].ToString());
            else
            {
                amount[1].gameObject.SetActive(false);
                tick[1].enabled = true;
            }
        }
        else if (levelLoader.sceneIndex == 1)
        {
            if (shopping.amounts[shopping.potato] > 0)
                amount[0].SetText("x" + shopping.amounts[shopping.potato].ToString());
            else
            {
                amount[0].gameObject.SetActive(false);
                tick[0].enabled = true;
            }

            if (shopping.amounts[shopping.waterMelon] > 0)
                amount[1].SetText("x" + shopping.amounts[shopping.waterMelon].ToString());
            else
            {
                amount[1].gameObject.SetActive(false);
                tick[1].enabled = true;
            }
            if (shopping.amounts[shopping.donut] > 0)
                amount[2].SetText("x" + shopping.amounts[shopping.donut].ToString());
            else
            {
                amount[2].gameObject.SetActive(false);
                tick[2].enabled = true;
            }
        }
        else if (levelLoader.sceneIndex == 2)
        {
            if (shopping.amounts[shopping.pork] > 0)
                amount[0].SetText("x" + shopping.amounts[shopping.pork].ToString());
            else
            {
                amount[0].gameObject.SetActive(false);
                tick[0].enabled = true;
            }

            if (shopping.amounts[shopping.mango] > 0)
                amount[1].SetText("x" + shopping.amounts[shopping.mango].ToString());
            else
            {
                amount[1].gameObject.SetActive(false);
                tick[1].enabled = true;
            }
            if (shopping.amounts[shopping.coffee] > 0)
                amount[2].SetText("x" + shopping.amounts[shopping.coffee].ToString());
            else
            {
                amount[2].gameObject.SetActive(false);
                tick[2].enabled = true;
            }
            if (shopping.amounts[shopping.milk] > 0)
                amount[3].SetText("x" + shopping.amounts[shopping.milk].ToString());
            else
            {
                amount[3].gameObject.SetActive(false);
                tick[3].enabled = true;
            }
        }
        else if(levelLoader.sceneIndex == 3)
        {
            if (shopping.amounts[shopping.energyDrink] > 0)
                amount[0].SetText("x" + shopping.amounts[shopping.energyDrink].ToString());
            else
            {
                amount[0].gameObject.SetActive(false);
                tick[0].enabled = true;
            }

            if (shopping.amounts[shopping.cookie] > 0)
                amount[1].SetText("x" + shopping.amounts[shopping.cookie].ToString());
            else
            {
                amount[1].gameObject.SetActive(false);
                tick[1].enabled = true;
            }
            if (shopping.amounts[shopping.blueberries] > 0)
                amount[2].SetText("x" + shopping.amounts[shopping.blueberries].ToString());
            else
            {
                amount[2].gameObject.SetActive(false);
                tick[2].enabled = true;
            }
            if (shopping.amounts[shopping.cheese] > 0)
                amount[3].SetText("x" + shopping.amounts[shopping.cheese].ToString());
            else
            {
                amount[3].gameObject.SetActive(false);
                tick[3].enabled = true;
            }
        }
        else if(levelLoader.sceneIndex == 4)
        {
            if (shopping.amounts[shopping.coke] > 0)
                amount[0].SetText(shopping.amounts[shopping.coke].ToString());
            else
            {
                amount[0].gameObject.SetActive(false);
                tick[0].enabled = true;
            }

            if (shopping.amounts[shopping.cupcake] > 0)
                amount[1].SetText("x" + shopping.amounts[shopping.cupcake].ToString());
            else
            {
                amount[1].gameObject.SetActive(false);
                tick[1].enabled = true;
            }
            if (shopping.amounts[shopping.onion] > 0)
                amount[2].SetText("x" + shopping.amounts[shopping.onion].ToString());
            else
            {
                amount[2].gameObject.SetActive(false);
                tick[2].enabled = true;
            }
            if (shopping.amounts[shopping.chicken] > 0)
                amount[3].SetText("x" + shopping.amounts[shopping.chicken].ToString());
            else
            {
                amount[3].gameObject.SetActive(false);
                tick[3].enabled = true;
            }

        }
        
    }
}
