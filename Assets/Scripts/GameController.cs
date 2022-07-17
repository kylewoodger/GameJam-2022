using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    public GameObject mainCamera;
    public GameObject gameOverCamera;

    public enemySpawner enemySpawner;

    public int currentLevel;
    public GamePhase gamePhase;
    public bool gameOver = false;
    public int aliveEnemies;
    public int noOfStandardDice; 
    public int noOfPrecisionDice;
    public int noOfChoiceDice;
    public bool canThrowDice;
    public UIManager uiManager;

    public bool progressingToNextRound;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    public void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        gameOverCamera = GameObject.FindGameObjectWithTag("GameOverCamera");
        mainCamera.SetActive(true);
        gameOverCamera.SetActive(false);
        uiManager.gameOverUi.SetActive(false);
        canThrowDice = false;
        noOfStandardDice = 3;
        noOfPrecisionDice = 1;
        noOfChoiceDice = 1;
        gamePhase = GamePhase.MENU;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextLevel();
        }
        if (gamePhase == GamePhase.ROUND_IN_PROGRESS && enemySpawner.enemiesSpawned == enemySpawner.noOfEnemies) {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
                uiManager.youWonRound.SetActive(true);
                uiManager.dicePanel.SetActive(false);
                uiManager.nextRoundButton.SetActive(true);
                gamePhase = GamePhase.ROUND_ENDED;
                Debug.Log("Round ended");
            }
        }
    }

    public void OnSceneLoaded(Scene currentLevel, LoadSceneMode Single) 
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        gameOverCamera = GameObject.FindGameObjectWithTag("GameOverCamera");
        mainCamera.SetActive(true);
        gameOverCamera.SetActive(false);
        // uiManager.StartLevel(currentLevel);
        uiManager.SetLabels();
        enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<enemySpawner>();
    }

    public void NextLevel() {
        currentLevel++;
        uiManager.nextRoundButton.SetActive(false);
        uiManager.youWonRound.SetActive(false);
        uiManager.dicePanel.SetActive(true);
        gamePhase = GamePhase.PICK_DICE;
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        noOfChoiceDice += 1;
        noOfPrecisionDice += 1;
        noOfStandardDice += 1;
    }

    public void StartGame() {

    }

    public void ChangePhase(GamePhase g) {
        gamePhase = g;
    }

    public void EndGame() {

    }

    public void GameOver()
    {
        gamePhase = GamePhase.GAME_OVER;
        gameOver = true;
        uiManager.gameOverUi.SetActive(true);
        gameOverCamera.SetActive(true);
        uiManager.dicePanel.SetActive(false);
        mainCamera.SetActive(false);
    }


    public void BonusGenerator() {

    }

    public void ResetDiceCount() {

    }

}
