using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public float noOfEnemies;
    public float spawnInterval; 
    public float spawnCountdown;
    public GameObject gameController;
    public GameObject enemyPrefab; 
    public int enemiesSpawned;
    public ArrayList enemyPathPositions = new ArrayList();
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesSpawned < noOfEnemies)
        {
            if (spawnCountdown >= spawnInterval)
            {
                if(gameController.GetComponent<GameController>().gamePhase == GamePhase.ROUND_IN_PROGRESS) 
                {
                    GameObject e = (GameObject)Instantiate(enemyPrefab, transform.position, transform.rotation);
                    enemiesSpawned++;
                    spawnCountdown = 0;
                }
                
            }
            spawnCountdown += Time.deltaTime;
        }
    }
}
