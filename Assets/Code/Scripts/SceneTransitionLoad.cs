using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionLoad : MonoBehaviour
{
    [SerializeField] int secondsTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForLoad(secondsTime));
    }

    IEnumerator WaitForLoad(int seconds)
    {     
        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene("Game");
    }

}
