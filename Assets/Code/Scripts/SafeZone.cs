using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{

    bool playerOn = false;
    bool bossOn = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOn = true;
        }
        if (other.tag == "Boss")
        {
            bossOn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOn = false;
        }
        if (other.tag == "Boss")
        {
            bossOn = false;
        }
    }

    private void Update()
    {
        if (playerOn && bossOn)
        {
            return;
        }
        if (!playerOn && bossOn)
        {
            GameManager.playerLifes--;
            //Cutscene code
        }
    }

}
