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
    public TextMeshProUGUI money, infliation;
    public TextMeshPro floatingText;
    public Image[] tick;
    public int listElements;

    private void Awake()
    {
        shopping = GameObject.Find("Player").GetComponent<ShoppingListManager>();
        money.GetComponent<TextMeshProUGUI>();
        infliation.GetComponent<TextMeshProUGUI>();
        floatingText.GetComponent<TextMeshPro>();
        for(int i = 0; i< itemSprite.Length; i++)
        {
            itemSprite[i].GetComponent<Sprite>();
            itemSprite[i].GetComponent<Image>();
            amount[i].GetComponent<TextMeshProUGUI>();
            tick[i].GetComponent<Image>();
        }
        levelLoader = GameObject.Find("LevelManager").GetComponent<LevelLoader>();

    }

    private void Start()
    {
        ShoppingList();
        if(levelLoader.sceneIndex==1)
        {
            shopping.money = 13f;
        }
    }
    private void Update()
    {
        ShoppingListToUI();
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void SetIteMAssets(ItemAssets itemAssets)
    {
        this.itemAssets = itemAssets;
    }
    public void ShoppingList()
    {
        if (levelLoader.sceneIndex == 0)
        {
            shopping.amounts[shopping.apple] = 2;
            shopping.amounts[shopping.strawberry] = 1;

            itemSprite[0].gameObject.SetActive(true);
            itemSprite[1].gameObject.SetActive(true);

            shopping.money = 6f;
        }
        if (levelLoader.sceneIndex == 1)
        {
            shopping.amounts[shopping.potato] = 2;
            shopping.amounts[shopping.waterMelon] = 1;
            shopping.amounts[shopping.donut] = 2;

            shopping.money = 15f;
        }
        shopping.amounts[shopping.apple] = 2;
        shopping.amounts[shopping.strawberry] = 1;


        itemSprite[0].gameObject.SetActive(true);
        itemSprite[1].gameObject.SetActive(true);

        
        infliation.SetText(shopping.infliation + "%");
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
        if (levelLoader.sceneIndex == 1)
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
        else
        {
            if (shopping.amounts[shopping.apple] > 0)
                amount[0].SetText(shopping.amounts[shopping.apple].ToString());
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
            if (shopping.amounts[shopping.strawberry] > 0)
                amount[2].SetText("x" + shopping.amounts[shopping.strawberry].ToString());
            else
            {
                amount[2].gameObject.SetActive(false);
                tick[2].enabled = true;
            }
            if (shopping.amounts[shopping.cabbage] > 0)
                amount[3].SetText("x" + shopping.amounts[shopping.cabbage].ToString());
            else
            {
                amount[3].gameObject.SetActive(false);
                tick[3].enabled = true;
            }

        }
        
    }
}
