using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMemo : MonoBehaviour
{
    [SerializeField] Animator FishAnim;
    [SerializeField] Animator FishAnimPivot;

    private void Start()
    {
        FishAnim.SetBool("PeixeMorto", false);
        FishAnimPivot.SetBool("PeixeMorto", false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Aquario")
        {
            FishAnim.SetBool("PeixeMorto", true);
            FishAnimPivot.SetBool("PeixeMorto", true);
            GameManager.missions[2].currentCount++;
            Destroy(gameObject);
        }
    }

}
