using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_InventoryHandler : MonoBehaviour {

    private Inventory inventory;
    [SerializeField]
    private Transform itemSlotContainer;
    [SerializeField]
    private Transform itemSlotTemplate;


    private void Awake() {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
        inventory.OnItemListChanged += InventoryOnItemListChanged;
        RefreshInventoryItems();
    }

    private void InventoryOnItemListChanged(object sender,System.EventArgs e) {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems() {

        foreach(Transform c in itemSlotContainer) {
            if (c == itemSlotTemplate) continue;
            Destroy(c.gameObject);
        }

        int x = 0, y = 0;
        float itemSlotCellSize = 150f;
        foreach(Item item in inventory.GetItemList()) {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("background").Find("image").GetComponent<Image>();

            TextMeshProUGUI textCount = itemSlotRectTransform.Find("background").Find("count").GetComponent<TextMeshProUGUI>();
            image.sprite = item.GetSprite();
           
            textCount.text = item.amount.ToString() ;
            x++;
            if(x > 5) {
                x = 0;
                y--;
            }
        }
    }

}
