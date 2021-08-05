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
    }

    private void Start()
    {
        ShoppingList();
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
        shopping.amounts[shopping.apple] = 1;
        shopping.amounts[shopping.cabbage] = 1;
        shopping.amounts[shopping.strawberry] = 1;

        itemSprite[0].gameObject.SetActive(true);
        itemSprite[1].gameObject.SetActive(true);
        itemSprite[2].gameObject.SetActive(true);

        //itemSprite[0].sprite = itemAssets.sprites[shopping.apple];
        //itemSprite[1].sprite = itemAssets.sprites[shopping.cabbage];
        //itemSprite[2].sprite = itemAssets.sprites[shopping.strawberry];

        shopping.money = 2f;
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


        if (shopping.amounts[shopping.apple] > 0)
            amount[0].SetText(shopping.amounts[shopping.apple].ToString());
        else 
        {
            amount[0].gameObject.SetActive(false);
            tick[0].enabled = true;
        }

        if (shopping.amounts[shopping.cabbage] > 0)
            amount[1].SetText(shopping.amounts[shopping.cabbage].ToString());
        else
        {
            amount[1].gameObject.SetActive(false);
            tick[1].enabled = true;
        }
        if (shopping.amounts[shopping.strawberry] > 0)
            amount[2].SetText(shopping.amounts[shopping.strawberry].ToString());
        else
        {
            amount[2].gameObject.SetActive(false);
            tick[2].enabled = true;
        }
        if (shopping.amounts[shopping.cabbage] > 0)
            amount[3].SetText(shopping.amounts[shopping.cabbage].ToString());
        else
        {
            amount[3].gameObject.SetActive(false);
            tick[3].enabled = true;
        }
    }
}
