using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjectiveUI : MonoBehaviour {

    private TextMeshProUGUI textPro;
    [SerializeField] private Item.ItemType itemName;
    [SerializeField] private int amount;

    void Awake() {
        textPro = GetComponent<TextMeshProUGUI>();
        textPro.text = "Buy " + amount + " " + itemName;
        if (!GameManager.instance.objItems.Contains(itemName)) {
            textPro.color = Color.red;
            textPro.fontStyle = FontStyles.Strikethrough;
        }
    }

    private void OnEnable() {
        if (!GameManager.instance.objItems.Contains(itemName)) {
            textPro.color = Color.red;
            textPro.fontStyle = FontStyles.Strikethrough;
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
