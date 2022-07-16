using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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

    //Game elements
    public Dice currentlySelectedDice;
    public GameController gameController;

    //Control variables
    private bool moveDice;
    private Vector3 hitPoint;

    // Start is called before the first frame update
    public void Start()
    {
        StartLevel(1);
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetMouseButtonDown(1) && gameController.gamePhase == GamePhase.PICK_DICE_LOCATION) {
            gameController.ChangePhase(GamePhase.PICK_DICE);
            Destroy(curDiceObj, 0);
        }
        if(Input.GetMouseButtonDown(0) && gameController.gamePhase == GamePhase.PICK_DICE_LOCATION) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                gameController.ChangePhase(GamePhase.DICE_IN_AIR);
                curTubeObj = Instantiate(tubePrefab, hit.point, Quaternion.identity);
                curTubeObj.GetComponent<MeshCollider>().enabled = false;
                hitPoint = hit.point + new Vector3(0, 10, 0);
                moveDice = true;
            }
        }
        if (moveDice) {
            curDiceObj.transform.position = Vector3.Lerp(curDiceObj.transform.position, hitPoint, 3 * Time.deltaTime);
            if (Vector3.Distance(curDiceObj.transform.position, hitPoint) < 0.5) {
                curTubeObj.GetComponent<MeshCollider>().enabled = true;
                Debug.Log(curTubeObj.GetComponent<MeshCollider>().enabled);
                moveDice = false;
                Rigidbody diceRb = curDiceObj.GetComponent<Rigidbody>();
                diceRb.useGravity = true;
                diceRb.AddTorque(Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f), ForceMode.Force);
                diceRb.AddForce(new Vector3(Random.Range(-500.0f, 500.0f), 0, Random.Range(-500.0f, 500.0f)), ForceMode.Force);
            }
        }
        if(gameController.gamePhase == GamePhase.DICE_IN_AIR) {
            if(curDiceObj.GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0)) {
                gameController.gamePhase = GamePhase.DICE_LANDED;
            }
        }
    }

    public void NextPhase() {

    }

    public void SelectBonus() {

    }

    public void SelectDice() {

    }

    public void Throw() {

    }

    public void DiceHover(Outline outline) {
        outline.effectDistance = new Vector2(2, -2);
    }

    public void DiceHoverExit(Outline outline) {
        outline.effectDistance = new Vector2(0, 0);
    }

    public void OnDiceClick(GameObject dice) {
        if (gameController.gamePhase == GamePhase.PICK_DICE) {
            curDiceObj = Instantiate(dicePrefab, new Vector3(0,10,0), Quaternion.identity);
            gameController.ChangePhase(GamePhase.PICK_DICE_LOCATION);
        }
    }

    public void StartLevel(int levelNo) {
        standardDiceNumberLabel.GetComponent<TMP_Text>().text = GetComponent<GameController>().noOfStandardDice.ToString();
        precisionDiceNumberLabel.GetComponent<TMP_Text>().text = GetComponent<GameController>().noOfPrecisionDice.ToString();
        choiceDiceNumberLabel.GetComponent<TMP_Text>().text = GetComponent<GameController>().noOfChoiceDice.ToString();
    }

}
