using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase3 : MonoBehaviour
{
    public static int amt = 3;
    public static int currentMoney;
    public int newMoney;

    void Start ()
    {
        
        currentMoney = WalletController.moneyLeft;
        Debug.Log(currentMoney);
        newMoney = currentMoney - amt;
    }
    
    void Update ()
    {
        WalletController.moneyLeft = newMoney;
        
    }
}
