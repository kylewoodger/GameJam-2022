using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{

    //UI Elements
    public GameObject standardDiceNumberLabel;
    public GameObject precisionDiceNumberLabel;
    public GameObject choiceDiceNumberLabel;
    public GameObject curDiceObj;
    public GameObject dicePrefab;
    public GameObject curTubeObj;
    public GameObject tubePrefab;
    public GameObject preciseTubePrefab;
    public GameObject startRoundButton;
    public GameObject youWonRound;
    public GameObject nextRoundButton;
    public Material mouseCircleMat;
    public GameObject choiceDice;
    public GameObject gameOverUi;
    public GameObject dicePanel;

    private string curDiceType;

    //Game elements
    public GameController gameController;
    public GameObject ballisticPrefab;
    public GameObject rubberPrefab;
    public GameObject sniperPrefab;
    public GameObject firePrefab;
    public GameObject electricPrefab;
    public GameObject laserPrefab;

    //Control variables
    private bool moveDice;
    private Vector3 hitPoint;

    public void Start() {
        startRoundButton.SetActive(false);
        youWonRound.SetActive(false);
        nextRoundButton.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetMouseButtonDown(1) && gameController.gamePhase == GamePhase.PICK_DICE_LOCATION) {
            gameController.ChangePhase(GamePhase.PICK_DICE);
            Destroy(curDiceObj, 0);
        }
        if(Input.GetMouseButtonDown(0) && gameController.gamePhase == GamePhase.PICK_DICE_LOCATION) {
            switch (curDiceType) {
                case "StandardDice":
                    gameController.noOfStandardDice -= 1;
                    break;
                case "PrecisionDice":
                    gameController.noOfPrecisionDice -= 1;
                    break;
                case "ChoiceDice":
                    gameController.noOfChoiceDice -= 1;
                    break;
            }
            SetLabels();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                gameController.ChangePhase(GamePhase.DICE_IN_AIR);
                GameObject tubeToInstantiate = new GameObject();
                if (curDiceType == "PrecisionDice") {
                    tubeToInstantiate = preciseTubePrefab;
                } else {
                    tubeToInstantiate = tubePrefab;
                }
                curTubeObj = Instantiate(tubeToInstantiate, hit.point, Quaternion.identity);
                curTubeObj.GetComponent<MeshCollider>().enabled = false;
                hitPoint = hit.point + new Vector3(0, 10, 0);
                moveDice = true;
            }
        }
        if (moveDice) {
            curDiceObj.transform.position = Vector3.Lerp(curDiceObj.transform.position, hitPoint, 3 * Time.deltaTime);
            if (Vector3.Distance(curDiceObj.transform.position, hitPoint) < 0.5) {
                curTubeObj.GetComponent<MeshCollider>().enabled = true;
                moveDice = false;
                Rigidbody diceRb = curDiceObj.GetComponent<Rigidbody>();
                diceRb.useGravity = true;
                diceRb.AddTorque(Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f), ForceMode.Force);
                diceRb.AddForce(new Vector3(Random.Range(-500.0f, 500.0f), 0, Random.Range(-500.0f, 500.0f)), ForceMode.Force);
                gameController.gamePhase = GamePhase.DICE_ROLLED;
            }
        }
        if(gameController.gamePhase == GamePhase.DICE_ROLLED) {
            if (curDiceObj.GetComponent<Rigidbody>().velocity != new Vector3(0, 0, 0)) {
                gameController.gamePhase = GamePhase.DICE_IN_MOTION;
            }
        }
        if (gameController.gamePhase == GamePhase.DICE_IN_MOTION) {
            if (curDiceObj.GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0)) {
                gameController.gamePhase = GamePhase.DICE_LANDED;
                startRoundButton.SetActive(true);
                Destroy(curTubeObj);
                BoxCollider[] diceSides = curDiceObj.GetComponentsInChildren<BoxCollider>();
                float curHighest = 100;
                BoxCollider highest = new BoxCollider();
                foreach (BoxCollider dice in diceSides) {
                    if (dice.name != "Dice(Clone)" && Vector3.Distance(curDiceObj.transform.position + new Vector3(0, 3, 0), dice.transform.position) < curHighest) {
                        curHighest = Vector3.Distance(curDiceObj.transform.position + new Vector3(0, 3, 0), dice.transform.position);
                        highest = dice;
                    }
                }
                SpawnTower(highest.name);
                gameController.gamePhase = GamePhase.PICK_DICE;
            }
        }
    }

    public void StartRound() {
        if (gameController.gamePhase == GamePhase.PICK_DICE) {
            startRoundButton.SetActive(false);
            gameController.gamePhase = GamePhase.ROUND_IN_PROGRESS;
        }
    }

    public void SpawnTower(string tower) {
        GameObject towerPrefab = new GameObject();
        switch(tower) {
            case("Ballistic"):
                towerPrefab = ballisticPrefab;
                break;
            case("Rubber"):
                towerPrefab = rubberPrefab;
                break;
            case("Sniper"):
                towerPrefab = sniperPrefab;
                break;
            case("Fire"):
                towerPrefab = firePrefab;
                break;
            case("Electric"):
                towerPrefab = electricPrefab;
                break;
            case("Laser"):
                towerPrefab = laserPrefab;
                break;
        }
        GameObject towerObj = Instantiate(
            towerPrefab, 
            new Vector3(curDiceObj.transform.position.x, 0, curDiceObj.transform.position.z),
            Quaternion.identity);
        Destroy(curDiceObj);
    }

    public void DiceHover(Outline outline) {
        outline.effectDistance = new Vector2(2, -2);
    }

    public void DiceHoverExit(Outline outline) {
        outline.effectDistance = new Vector2(0, 0);
    }

    public void OnDiceClick(GameObject dice) {
        Debug.Log(dice.name);
        curDiceType = dice.name;
        bool diceRemaining = true;
        switch (curDiceType) {
                case "StandardDice":
                    mouseCircleMat.SetFloat("_Radius", 8);
                    if (gameController.noOfStandardDice == 0) {
                        diceRemaining = false;
                    }
                    break;
                case "PrecisionDice":
                    mouseCircleMat.SetFloat("_Radius", 1);
                    if (gameController.noOfPrecisionDice == 0) {
                        diceRemaining = false;
                    }
                    break;
                case "ChoiceDice":
                    mouseCircleMat.SetFloat("_Radius", 8);
                    if (gameController.noOfChoiceDice == 0) {
                        diceRemaining = false;
                    }
                    break;
        }
        if (gameController.gamePhase == GamePhase.PICK_DICE && diceRemaining) {
            curDiceObj = Instantiate(dicePrefab, new Vector3(0,10,0), Quaternion.identity);
            gameController.ChangePhase(GamePhase.PICK_DICE_LOCATION);
        }
    }

    public void SetLabels() {
        standardDiceNumberLabel = GameObject.FindGameObjectWithTag("StandardDiceLabel");
        precisionDiceNumberLabel = GameObject.FindGameObjectWithTag("PrecisionDiceLabel");
        choiceDiceNumberLabel = GameObject.FindGameObjectWithTag("ChoiceDiceLabel");
        standardDiceNumberLabel.GetComponent<TMP_Text>().text = gameController.noOfStandardDice.ToString();
        precisionDiceNumberLabel.GetComponent<TMP_Text>().text = gameController.noOfPrecisionDice.ToString();
        choiceDiceNumberLabel.GetComponent<TMP_Text>().text = gameController.noOfChoiceDice.ToString();
    }

}
