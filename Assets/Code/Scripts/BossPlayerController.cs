using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossPlayerController : MonoBehaviour
{
    [SerializeField] GameObject DoorAPos;
    [SerializeField] GameObject DoorCPos;

    [SerializeField] NavMeshAgent agent;

    [SerializeField] float BossCooldownMax;
    [SerializeField] float BossCooldownMin;

    [SerializeField] Transform[] PointBPosition;
    private int PointBIndex;

    private string BossState = "PointA"; //PointA => WalkingToB ==> WalkingToC ==> PointC
    private string BossDirection = "AtoC"; // AtoC => CtoA
    private bool SwitchPointB;

    private bool BossLeave = false;

    private float timeRemaining;
    private bool timerIsRunning;

    void Start()
    {
        ResetBossTimer();

    }

    void Update()
    {
        // BOSS TIMER //

        /*if (Input.GetMouseButtonDown(0))
        {
            timerIsRunning = true;
        }*/

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                Debug.Log(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");

                PointBIndex = Random.Range(0, 3);

                BossState = "WalkingToB";

                Debug.Log(PointBIndex);

                timerIsRunning = false;
            }
        }

        // BOSS SET DESTINATION //

        if (BossState == "WalkingToB")
        {
            agent.SetDestination(PointBPosition[PointBIndex].position);
        }
        else if (BossState == "WalkingToC")
        {
            agent.SetDestination(DoorCPos.transform.position);
        }
        else if (BossState == "WalkingToA")
        {
            agent.SetDestination(DoorAPos.transform.position);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (PointBIndex == 0 && other.tag == "B1")
        {
            if (BossDirection == "AtoC")
            {
                BossState = "WalkingToC"; // Boss is in point B, walking to door C
            }
            else if (BossDirection == "CtoA")
            {
                BossState = "WalkingToA"; // Boss is in point B, walking to door A
            }
        }
        else if (PointBIndex == 1 && other.tag == "B2")
        {
            if (BossDirection == "AtoC")
            {
                BossState = "WalkingToC"; // Boss is in point B, walking to door C
            }
            else if (BossDirection == "CtoA")
            {
                BossState = "WalkingToA"; // Boss is in point B, walking to door A
            }
        }
        else if (PointBIndex == 2 && other.tag == "B3")
        {
            if (BossDirection == "AtoC")
            {
                BossState = "WalkingToC"; // Boss is in point B, walking to door C
            }
            else if (BossDirection == "CtoA")
            {
                BossState = "WalkingToA"; // Boss is in point B, walking to door A
            }
        }



        // BOSS ARRIVE AT DOOR

        if (other.tag == "DoorA")
        {
            ResetBossTimer();
            BossDirection = "AtoC";
        }
        else if (other.tag == "DoorC")
        {
            ResetBossTimer();
            BossDirection = "CtoA";
        }

    }


    private void ResetBossTimer() // reset timmer when boss arrives at point A or C
    {
        timeRemaining = Random.Range(BossCooldownMin, BossCooldownMax);
        timerIsRunning = true;
    }
}
