using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuUI : MonoBehaviour
{
    public GameController gameController;
    public GameObject diceUi;

    void Start() {
        diceUi.SetActive(false);
        gameController.ChangePhase(GamePhase.MENU);
    }
    // Start is called before the first frame update
    public void QuitGame() {
        Application.Quit(1);
    }

    public void PlayGame() {
        gameController.ChangePhase(GamePhase.PICK_DICE);
        diceUi.SetActive(true);
        SceneManager.LoadScene("level1");
    }
}
