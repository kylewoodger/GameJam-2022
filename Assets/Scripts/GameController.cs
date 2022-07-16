using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    public int currentLevel;
    public GamePhase gamePhase;
    public int villageHealth;
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
        canThrowDice = false;
        villageHealth = 100;
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

    public void VillageTakeDamage (int damage) {
        villageHealth -= damage;
    }

    public void BonusGenerator() {

    }

    public void ResetDiceCount() {

    }

    public void CanThrowMoreDice() {

    }
}
