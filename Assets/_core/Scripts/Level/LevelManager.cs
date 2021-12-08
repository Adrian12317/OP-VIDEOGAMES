using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Ins;
    public int coins = 0;
    public TextMeshProUGUI coinsText;

    //[0][1][2]
    public List<Life> lifeList;
    public GameObject gameOverMenu;
    public GameObject levelCompleteMenu;
    public GameObject levelSelectMenu;
    public GameObject loadingMenu;
    public GameObject pauseMenu;
    public GameObject lootUI;
    public Player player;
    public Life life;
    public TextMeshProUGUI heartsContainer;
    public AddKey addKey;
    public GameObject moveJoystick;
    public GameObject jumpButton;

    private void Awake() {
        Ins = this;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void ResetGame(){
        player.ResetPlayer();
        for(int i = 0; i<lifeList.Count; i++){
            lifeList[i].PrenderVida();
        }
    }

    public void ShowPause(){
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
        // moveJoystick.gameObject.SetActive(false);
        // jumpButton.gameObject.SetActive(false);
    }

    private void OnSceneUnloaded(Scene scene){
        SceneManager.LoadScene("Level"+nivelActual, LoadSceneMode.Additive);
    }

    public void OnPlayerAddHeart(int _life){
        lifeList[_life-1].PrenderVida();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode modo){
        loadingMenu.gameObject.SetActive(false);
        levelCompleteMenu.gameObject.SetActive(false);
        levelSelectMenu.gameObject.SetActive(false);
    }

    public void OnLevelComplete(){
        Invoke("OnLevelCompleteDelay" , 1);
    }

    private void OnLevelCompleteDelay(){
        levelCompleteMenu.gameObject.SetActive(true);
        // moveJoystick.gameObject.SetActive(false);
        // jumpButton.gameObject.SetActive(false);
    }

    public void AddCoins(){
        coins++;
        coinsText.text = coins.ToString();
    }

    public void GameOver(){
        gameOverMenu.gameObject.SetActive(true);
        // moveJoystick.gameObject.SetActive(false);
        // jumpButton.gameObject.SetActive(false);
    }

    public void OnPlayerDamage(int _lifes){
        if(_lifes < 0){return;}
        lifeList[_lifes].ApagarVida();
    }
    public void OnRetryClick(){
        // SceneManager.LoadScene("Game");
        ResetGame();
        gameOverMenu.gameObject.SetActive(false);
        LoadLevel(nivelActual);
    }

    private int nivelActual = 1;
    public void LoadLevel(int _levelNumber){
        loadingMenu.gameObject.SetActive(true);
        // moveJoystick.gameObject.SetActive(true);
        // jumpButton.gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync("Level" + nivelActual);
        nivelActual = _levelNumber;
    }

    public void SelectLevel(){
        // moveJoystick.gameObject.SetActive(false);
        // jumpButton.gameObject.SetActive(false);
        levelSelectMenu.gameObject.SetActive(true);
        levelCompleteMenu.gameObject.SetActive(false);
    }
}
