using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    public GameObject mainCamera;
    public GameObject gameOverCamera;

    public int currentLevel;
    public GamePhase gamePhase;
    public bool gameOver = false;
    public int aliveEnemies;
    public int noOfStandardDice; 
    public int noOfPrecisionDice;
    public int noOfChoiceDice;
    public bool canThrowDice;
    public UIManager uiManager;

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
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        gameOverCamera = GameObject.FindGameObjectWithTag("GameOverCamera");
        mainCamera.SetActive(true);
        gameOverCamera.SetActive(false);
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
    }

    public void NextLevel() {
        currentLevel++;
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);

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
        gameOver = true;
        gameOverCamera.SetActive(true);
        mainCamera.SetActive(false);
        

    }


    public void BonusGenerator() {

    }

    public void ResetDiceCount() {

    }

    public void CanThrowMoreDice() {

    }
}
