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

        if (Input.GetMouseButtonDown(0))
        {
            timerIsRunning = true;
        }

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
                timeRemaining = 10f;
                timerIsRunning = false;
                BossState = "WalkingToB";

                PointBIndex = Random.Range(0, PointBPosition.Length);

                Debug.Log(PointBPosition);
            }
        }

        // BOSS SET DESTINATION //

        if (BossState == "WalkingToB")
        {
            agent.SetDestination(PointBPosition[PointBIndex].position);
        }
    }


    private void ResetBossTimer() // reset timmer when boss arrives at point A or B
    {
        timeRemaining = Random.Range(BossCooldownMin, BossCooldownMax);
        timerIsRunning = true;
    }
}
