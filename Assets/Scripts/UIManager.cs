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

    //Game elements
    public GamePhase gamePhase;
    public Dice currentlySelectedDice;

    // Start is called before the first frame update
    public void Start()
    {
        StartLevel(1);
    }

    // Update is called once per frame
    public void Update()
    {
        
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

    public void StartLevel(int levelNo) {
        standardDiceNumberLabel.GetComponent<TMP_Text>().text = GetComponent<GameController>().noOfStandardDice.ToString();
        precisionDiceNumberLabel.GetComponent<TMP_Text>().text = GetComponent<GameController>().noOfPrecisionDice.ToString();
        choiceDiceNumberLabel.GetComponent<TMP_Text>().text = GetComponent<GameController>().noOfChoiceDice.ToString();
    }

}
