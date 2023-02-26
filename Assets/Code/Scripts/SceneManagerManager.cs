using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerManager : MonoBehaviour
{
    public void GoToGameScene()
    {
        SceneManager.LoadScene("Game"); // load the "Game" scene
    }

    public void GoToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu"); // load the "MainMenu" scene
    }

    public void GoToLoadingScreen()
    {
        SceneManager.LoadScene("LoadingScreen"); // load the "MainMenu" scene
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}

