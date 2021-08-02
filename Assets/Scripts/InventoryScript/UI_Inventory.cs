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
        shopping.amounts[shopping.steak] = 1;
        shopping.amounts[shopping.egg] = 1;
        shopping.amounts[shopping.bacon] = 1;
    }

    public void ShoppingListToUI()
    {
        itemName[0].SetText("Steak");
        itemName[1].SetText("Egg");
        itemName[2].SetText("Bacon");

        if (shopping.amounts[shopping.steak] > 0)
            amount[0].SetText(shopping.amounts[shopping.steak].ToString());
        else 
        {
            amount[0].gameObject.SetActive(false);
            tick[0].enabled = true;
        }

        if (shopping.amounts[shopping.egg] > 0)
            amount[1].SetText(shopping.amounts[shopping.egg].ToString());
        else
        {
            amount[1].gameObject.SetActive(false);
            tick[1].enabled = true;
        }
        if (shopping.amounts[shopping.bacon] > 0)
            amount[2].SetText(shopping.amounts[shopping.bacon].ToString());
        else
        {
            amount[1].gameObject.SetActive(false);
            tick[1].enabled = true;
        }
    }
}
