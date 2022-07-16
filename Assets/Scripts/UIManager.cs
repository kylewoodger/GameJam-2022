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
    public GameObject currentDiceObj;
    public GameObject prefab;

    //Game elements
    public Dice currentlySelectedDice;
    public GameController gameController;

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
            Destroy(currentDiceObj, 0);
        }
        if(Input.GetMouseButtonDown(0) && gameController.gamePhase == GamePhase.PICK_DICE_LOCATION) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.point);
                Debug.Log("hit");
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
            currentDiceObj = Instantiate(prefab, new Vector3(0,10,0), Quaternion.identity);
            gameController.ChangePhase(GamePhase.PICK_DICE_LOCATION);
        }
    }

    public void StartLevel(int levelNo) {
        standardDiceNumberLabel.GetComponent<TMP_Text>().text = GetComponent<GameController>().noOfStandardDice.ToString();
        precisionDiceNumberLabel.GetComponent<TMP_Text>().text = GetComponent<GameController>().noOfPrecisionDice.ToString();
        choiceDiceNumberLabel.GetComponent<TMP_Text>().text = GetComponent<GameController>().noOfChoiceDice.ToString();
    }

}
