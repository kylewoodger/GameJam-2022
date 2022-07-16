using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuUI : MonoBehaviour
{
    public GameController gameController;

    void Start() {
        gameController.ChangePhase(GamePhase.MENU);
    }
    // Start is called before the first frame update
    public void QuitGame() {
        Application.Quit(1);
    }

    public void PlayGame() {
        SceneManager.LoadScene("level1");
        gameController.ChangePhase(GamePhase.PICK_DICE);
    }
}
