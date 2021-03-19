using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnterFlowerShop : MonoBehaviour
{
    public GameObject openShop;
    public Canvas FlowerShop;
    
    public void OnMouseDown()
    {
        openShop.SetActive(true);

    }

    public void Update()
    {

        if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    //Replace this with whatever logic you want to use to validate the objects you want to click on
                    if(hit.collider.gameObject.tag == "Clickable")
                    {
                        //  SceneManager.LoadScene("Candy Shop");
                        Debug.Log("I got clicked!");
                        // openShop.SetActive(true);
                        FlowerShop.enabled = true;
                    }
                }
            }
    }
}
