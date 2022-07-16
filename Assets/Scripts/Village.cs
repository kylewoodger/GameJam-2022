using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    public float villageHealth;
    public GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        villageHealth = 5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (villageHealth <= 0f && gameController.GetComponent<GameController>().gameOver ==false)
        {
            Debug.Log("Its a massacre");
            gameController.GetComponent<GameController>().GameOver();        }
    }
}
