using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject openShop;
    
    void Back ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            openShop.SetActive(false);
        }
    }
}
