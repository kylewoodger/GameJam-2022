using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{

    //UI Elements
    public Text standardDiceNumberLabel;
    public Text precisionDiceNumberLabel;
    public Text choiceDiceNumberLabel;

    //Game elements
    public GamePhase gamePhase;
    public Dice currentlySelectedDice;

    private Inventory inventory;

    // Start is called before the first frame update
    public void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void NextPhase() {

    }

    public void StartGame() {
        //change scene
        SceneManager.LoadScene("level1");
        StartLevel(1);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void SelectBonus() {

    }

    public void SelectDice() {

    }

    public void Throw() {

    }

    public void StartLevel() {
        standardDiceNumberLabel.GetComponent<TextMeshPro>().SetText("3");
    }

}
