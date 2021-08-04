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
    public TextMeshProUGUI extraText, extraAmount;
    public Image[] tick;

    public int listElements;

    private void Awake()
    {
        shopping = GameObject.Find("Player").GetComponent<ShoppingListManager>();
        extraText.GetComponent<TextMeshProUGUI>();
        extraAmount.GetComponent<TextMeshProUGUI>();
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
        extraText.gameObject.SetActive(false);
        extraAmount.gameObject.SetActive(false);
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
    }

    public void ShoppingListToUI()
    {
        itemName[0].gameObject.SetActive(true);
        itemName[1].gameObject.SetActive(true);
        itemName[2].gameObject.SetActive(true);
        itemName[0].SetText("Apple");
        itemName[1].SetText("Cabbage");
        itemName[2].SetText("Strawberry");

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
    }
}
