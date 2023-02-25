using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacked : MonoBehaviour
{
    [SerializeField] Texture hacked;
    public void GetHacked()
    {
        GetComponent<Renderer>().material.SetTexture("_BaseMap", hacked);
    }
}
