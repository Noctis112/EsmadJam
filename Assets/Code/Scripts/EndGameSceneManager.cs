using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameSceneManager : MonoBehaviour
{
    public void LeaveGame()
    {
        Application.Quit();
    }

    public void Retry()
    {
        GameManager.gameScore = 0;
        GameManager.playerLifes = 3;

        SceneManager.LoadScene("Game");
    }
}
