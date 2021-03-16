using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondsLeft = 600;
    public bool takingAway = false;

    public string sceneLoad;

    void Start()
    {
        textDisplay.GetComponent<Text>().text = "10:00";
    }

    void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }

        if(secondsLeft == 0)
        {
            Application.LoadLevel("Game Over");
        }
    }
    
    IEnumerator TimerTake() 
    {
        int sec = 0;
        int min = 0;

        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;

        min = (int) secondsLeft / 60;
        sec = secondsLeft - (min*60);

        if(min < 10)
        {
            if(sec >= 10)
            {
                textDisplay.GetComponent<Text>().text = "0" + min + ":" + sec;
            }
            else
            {
                textDisplay.GetComponent<Text>().text = "0" + min + ":0" + sec;
            }
        }
        else
        {
            if(sec >= 10)
            {
                textDisplay.GetComponent<Text>().text = min + ":" + sec;
            }
            else
            {
                textDisplay.GetComponent<Text>().text = min + ":0" + sec;
            }
        }

        takingAway = false;

    }
    
    
}
