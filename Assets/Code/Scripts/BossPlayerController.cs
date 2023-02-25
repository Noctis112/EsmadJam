using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossPlayerController : MonoBehaviour
{
    [SerializeField] GameObject DoorAPos;
    [SerializeField] GameObject DoorCPos;

    [SerializeField] NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            agent.SetDestination(DoorCPos.transform.position);
        }
    }
}
