using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public float noOfEnemies;
    public float spawnInterval; 
    public float spawnCountdown;
    public GameObject enemyPrefab; 
    private int enemiesSpawned;
    public ArrayList enemyPathPositions = new ArrayList();
    
    
    // Start is called before the first frame update
    void Start()
    {
        
            

    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesSpawned < noOfEnemies)
        {
            if (spawnCountdown >= spawnInterval)
            {
                GameObject e = (GameObject)Instantiate(enemyPrefab, transform.position, transform.rotation);
                enemiesSpawned++;
                spawnCountdown = 0;
            }
            spawnCountdown += Time.deltaTime;
        }
    }
}
