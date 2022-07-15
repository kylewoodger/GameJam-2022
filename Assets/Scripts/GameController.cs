using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public int currentLevel;
    public GamePhase gamePhase;
    public int villageHealth;
    public int aliveEnemies;
    public bool canThrowDice;

    // Start is called before the first frame update
    void Start()
    {
        canThrowDice = false;
        villageHealth = 100;
        gamePhase = GamePhase.MENU;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextLevel() {
        currentLevel++;
    }

    void StartGame() {

    }

    void ChangePhase(GamePhase g) {
        gamePhase = g;
    }

    void EndGame() {

    }

    void VillageTakeDamage (int damage) {
        villageHealth -= damage;
    }

    void BonusGenerator() {

    }

    void ResetDiceCount() {

    }

    void CanThrowMoreDice() {

    }
}
