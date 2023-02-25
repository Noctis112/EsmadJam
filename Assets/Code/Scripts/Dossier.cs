using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dossier : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Impressora")
        {
            GameManager.missions[0].currentCount++;
            Destroy(gameObject);
        }
    }
}
