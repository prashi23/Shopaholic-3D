using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase100 : MonoBehaviour
{
    public static int amt = 100;
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
