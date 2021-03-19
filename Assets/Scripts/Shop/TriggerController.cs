using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerController : MonoBehaviour {

    private GameObject canvas;
    public Item.ItemType itemType = Item.ItemType.Cereal;
    [SerializeField]
    private TextMeshProUGUI titleText;

    void Start() {
        canvas = transform.Find("Canvas").gameObject;
        titleText.text = "Press E to Buy " + itemType.ToString();
    }

   

    private void OnTriggerEnter(Collider other) {
       
        if(other.gameObject.CompareTag("Player")) {
            canvas.SetActive(true);
        }
    }

    public Item GetItem() {
        return new Item { itemType = this.itemType, amount = 1 };
    }

    

    private void OnTriggerExit(Collider other) {
        canvas.SetActive(false);
    }

}
