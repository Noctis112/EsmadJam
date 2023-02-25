using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBossMainMenu : MonoBehaviour
{
    [SerializeField] float rotationsPerMinute = 10f; // the rotations per minute (rpm)

    void Update()
    {
        float rpmToDegreesPerSecond = rotationsPerMinute * 360f / 60f; // convert rpm to degrees per second
        transform.Rotate(0f, rpmToDegreesPerSecond * Time.deltaTime, 0f); // rotate the object by the specified amount
    }
}
