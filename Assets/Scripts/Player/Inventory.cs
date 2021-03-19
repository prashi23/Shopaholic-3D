using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory {

    private List<Item> itemList;
    public event EventHandler OnItemListChanged;

    public Inventory() {
        itemList = new List<Item>();
        
    }

    public void AddItem(Item item) {
        if (GameManager.instance.objItems.Count == 0) {
            GameManager.instance.GameWinCondition();
        }
        GameManager.instance.objItems.Remove(item.itemType);
        GameManager.instance.DeductMoney(item.itemPrice);
        bool isAlreadyInventory = false;
        foreach(Item inventoryItem in itemList) {
            if(inventoryItem.itemType == item.itemType) {
                inventoryItem.amount += 1;
                isAlreadyInventory = true;
            }
            
        }
        if (!isAlreadyInventory) {
            itemList.Add(item);
        }

        if (GameManager.instance.objItems.Count == 0) {
            GameManager.instance.GameWinCondition();
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);


    }

    public List<Item> GetItemList() {
        return itemList;
    }


}
