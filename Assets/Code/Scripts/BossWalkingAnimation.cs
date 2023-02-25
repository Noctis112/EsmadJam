using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalkingAnimation : MonoBehaviour
{
    Rigidbody rB;

    [SerializeField] float jumpForce;

    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        StartCoroutine(Saltar());
    }

    IEnumerator Saltar()
    {
        rB.AddForce(jumpForce * Vector3.up);
        yield return new WaitForSeconds(1);
    }
}
