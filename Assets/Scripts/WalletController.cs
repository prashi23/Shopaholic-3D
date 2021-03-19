using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WalletController : MonoBehaviour
{
    public GameObject textDisplay;
    public static int moneyLeft = 5000;
    public bool takingAway = false;
    public static int purchaseAmount;

    public string sceneLoad;
    void Start()
    {
        textDisplay.GetComponent<Text>().text = "$5000";
    }

    void Update()
    {
        if (takingAway == false && moneyLeft > 0)
        {
            // StartCoroutine(MoneyTake());
            textDisplay.GetComponent<Text>().text = "$" + moneyLeft;
        }

        if(moneyLeft <= 0)
        {
            
            SceneManager.LoadScene("Game Over");
        }
    }
    
    IEnumerator MoneyTake() 
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        moneyLeft -= purchaseAmount;
        
        if(moneyLeft >= 0)
        {
            textDisplay.GetComponent<Text>().text = "$" + moneyLeft;
        }
                
        takingAway = false;
    }
}
