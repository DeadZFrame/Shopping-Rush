using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private ShoppingListManager shopping;

    public TextMeshProUGUI[] itemName;
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
        for(int i = 0; i<itemName.Length; i++)
        {
            itemName[i].GetComponent<TextMeshProUGUI>();
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

    public void ShoppingList()
    {
        shopping.amounts[shopping.apple] = 1;
        shopping.amounts[shopping.cabbage] = 1;
        shopping.amounts[shopping.strawberry] = 1;

        itemName[0].gameObject.SetActive(true);
        itemName[1].gameObject.SetActive(true);
        itemName[2].gameObject.SetActive(true);

        itemName[0].SetText("Apple");
        itemName[1].SetText("Cabbage");
        itemName[2].SetText("Strawberry");

        shopping.money = 10f;
        infliation.SetText(shopping.infliation + "%");
    }

    public void ShoppingListToUI()
    {
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
        if (shopping.amounts[shopping.strawberry] > 0)
            amount[4].SetText(shopping.amounts[shopping.strawberry].ToString());
        else
        {
            amount[4].gameObject.SetActive(false);
            tick[4].enabled = true;
        }
    }
}
