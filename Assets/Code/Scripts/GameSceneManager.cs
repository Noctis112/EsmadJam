using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{

    void Update()
    {
        if (GameManager.playerLifes <= 0)
        {
            SceneManager.LoadScene("EndGame");
        }

        if (GameManager.AreAllMissionsComplete())
        {
            SceneManager.LoadScene("EndGame");
        }

        Debug.Log(GameManager.gameScore);
    }

}
