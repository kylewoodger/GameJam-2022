using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{

    //UI Elements
    public GameObject mainMenu;
    public GameObject diceMenu;
    public GameObject standardDiceImage;

    //Game elements
    public GamePhase gamePhase;
    public Dice currentlySelectedDice;

    private Inventory inventory;

    // Start is called before the first frame update
    public void Start()
    {
        inventory = GetComponent<Inventory>();
        mainMenu.SetActive(true);
        diceMenu.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void NextPhase() {

    }

    public void OnDiceMenuShow() {
        Debug.Log(inventory.noOfStandardDice);
        Transform standardDice = diceMenu.transform.Find("StandardDiceLabel");
        GameObject standardDiceLabel = standardDice.transform.Find("StandardDiceNumber").gameObject;
        Debug.Log(standardDiceLabel);
        TextMeshPro text = standardDiceLabel.GetComponent<TextMeshPro>();
        text.SetText("Hello");
    }

    public void StartGame() {
        mainMenu.SetActive(false);
        diceMenu.SetActive(true);
        OnDiceMenuShow();
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

    }

}
