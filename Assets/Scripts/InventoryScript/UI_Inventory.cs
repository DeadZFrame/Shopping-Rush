using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private ShoppingListManager shopping;

    public TextMeshProUGUI[] itemName;
    public TextMeshProUGUI[] amount;
    public TextMeshProUGUI extraText, extraAmount;

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

        amount[0].SetText(shopping.amounts[shopping.steak].ToString());
        amount[1].SetText(shopping.amounts[shopping.egg].ToString());
        amount[2].SetText(shopping.amounts[shopping.bacon].ToString());
    }
}
