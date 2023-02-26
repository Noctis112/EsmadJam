using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtPrank : MonoBehaviour
{
    [SerializeField] GameObject buttscanPorta;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BossDoor")
        {
            buttscanPorta.SetActive(true);
            Destroy(gameObject);
            GameManager.missions[4].currentCount++;
        }
    }
    void AtivaRigidbody()
    {
        gameObject.AddComponent<Rigidbody>();
        gameObject.AddComponent<BoxCollider>();
    }
}
