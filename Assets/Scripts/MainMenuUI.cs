using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    public void QuitGame() {
        Application.Quit(1);
    }

    public void PlayGame() {
        SceneManager.LoadScene("level1");
    }
}
