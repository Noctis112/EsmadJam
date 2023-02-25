using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenAnimation : MonoBehaviour
{
    Animator DoorOpenAnim;

    private void Start()
    {
        DoorOpenAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boss")
        {
            DoorOpenAnim.SetBool("Active", true);
            Debug.Log("OpenDoor");

        }
    }

    private void SetToFalse()
    {
        DoorOpenAnim.SetBool("Active", false);
    }
}
