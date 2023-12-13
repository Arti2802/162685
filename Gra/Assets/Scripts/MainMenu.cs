using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool computerMode = false;
    public PlayerMovement player;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void SetMode()
    {
        SceneManager.LoadScene(2);
        player.computerMode = computerMode;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
