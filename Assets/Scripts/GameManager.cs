using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    
    public static GameManager instance { get; private set; }
    public float timeLeft = 0;

    [SerializeField]
    private TextMeshProUGUI timer;

    void Awake() {
        instance = this;
        
    }

    private void Start() {
        Cursor.visible = false;
    }

    public void Update() {
        //timeLeft -= Time.deltaTime;
        //timer.text = timeLeft.ToString();
    }

    private void CountDownTimer(float sec) {
        
    }
}
