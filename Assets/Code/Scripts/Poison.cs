using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Aquario")
        {
            GameManager.mission[2].currentcount++;
            Destroy(gameObject);
        }
    }
}
