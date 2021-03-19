using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private float playerMoney = 0f;
    [SerializeField]
    private TextMeshProUGUI playerMoneyUI;

    [SerializeField] private GameObject gameWinUI, gameOverUI;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject objectiveUI;
    [SerializeField] private GameObject gameWinCondition;
    [SerializeField] private GameObject finishLineTrigger;

    public static GameManager instance { get; private set; }
    public float timeLeft = 0;

    [SerializeField]
    private TextMeshProUGUI timer;


    private bool gameOver = false, gameWin = false,isAll_ItemPurchased = false;
    public List<Item.ItemType> objItems;

    void Awake() {
        instance = this;
        
    }

    private void Start() {
        Cursor.visible = false;
        
    }

    public void Update() {
        CountDownTimer();
        ShowOrHideObjectiveUI();
        ShowOrHidePauseUI();
        playerMoneyUI.text = playerMoney.ToString("0.00");
    }

    

    public void ResumeGame() {
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
    }

    public float GetPlayerMoney => playerMoney;
    public void DeductMoney(float amount) {
        playerMoney -= amount;
    }

    private void CountDownTimer() {

        if(timeLeft > 0) {
            timeLeft -= Time.deltaTime;
        } else {
            timeLeft = 0;
            gameOver = true;
            GameOver();
        }
        

        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
       
    }

    public void RestartGame() {
        Cursor.visible = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu() {
        Cursor.visible = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void ShowOrHideObjectiveUI() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (objectiveUI.activeSelf) {
                objectiveUI.SetActive(false);
                Time.timeScale = 1;
            } else {
                Time.timeScale = 0;
                objectiveUI.SetActive(true);
            }

        }
    }
    private void ShowOrHidePauseUI() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (pauseMenuUI.activeSelf) {
                pauseMenuUI.SetActive(false);
                Cursor.visible = false;
                Time.timeScale = 1;
            } else {
                pauseMenuUI.SetActive(true);
                Cursor.visible = true;
                Time.timeScale = 0;
            }

        }
    }

    public void GameWinCondition() {
        isAll_ItemPurchased = true;
        gameWinCondition.SetActive(true);
        finishLineTrigger.SetActive(true);
    }
    public void GameWin() {
        Time.timeScale = 0;
        Cursor.visible = true;
        gameWinUI.SetActive(true);
    }
    private void GameOver() {
        if (gameWin)
            return;
        Time.timeScale = 0;
        Cursor.visible = true;
        gameOverUI.SetActive(true);
    }

}
