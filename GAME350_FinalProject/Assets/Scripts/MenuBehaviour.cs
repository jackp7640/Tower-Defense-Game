using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{

    public void GoToMenu()
    {
        // Scene "0" is the MenuScene
        SceneManager.LoadScene(0);
    }

    // Start game
    public void StartGame()
    {
        // Scene "1" is the GameScene
        SceneManager.LoadScene(1);
    }

    public void HowToPlay()
    {
        // Scene "2" is the HowToPlayScene
        SceneManager.LoadScene(2);
    }

    // Quit game 
    public void QuitGame()
    {
        Application.Quit();
    }
}
