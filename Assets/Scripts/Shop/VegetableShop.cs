using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableShop : MonoBehaviour {

    [SerializeField]
    GameObject VegetableShopUI;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {

            VegetableShopUI.SetActive(true);
            Cursor.visible = true;


        }
    }

    private void OnTriggerExit(Collider other) {
        VegetableShopUI.SetActive(false);
        Cursor.visible = false;
    }
}
