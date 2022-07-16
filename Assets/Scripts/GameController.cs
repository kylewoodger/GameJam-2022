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
    public void Start()
    {
        canThrowDice = false;
        villageHealth = 100;
        gamePhase = GamePhase.MENU;
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void NextLevel() {
        currentLevel++;
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
