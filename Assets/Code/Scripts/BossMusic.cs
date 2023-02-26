using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : MonoBehaviour
{
    [SerializeField] AudioSource bossSound;
    [SerializeField] AudioSource ElevatorSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boss")
        {
            bossSound.Play();
            //ElevatorSound.Stop();
            Debug.Log("BossMusicOn");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boss")
        {
            bossSound.Stop();
            //ElevatorSound.Play();
            Debug.Log("BossMusicOff");
        }
    }
}
