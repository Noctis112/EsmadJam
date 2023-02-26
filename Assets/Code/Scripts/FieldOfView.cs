using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    private bool PlayerSeen = false;

    [SerializeField] float cutsceneTimer;
    [SerializeField] GameObject cameraAtual;
    [SerializeField] GameObject cameraCutscene;
    [SerializeField] GameObject fakePlayer;
    [SerializeField] GameObject player;
    [SerializeField] GameObject teleportStart;
    [SerializeField] Animator fakeBoss;
    [SerializeField] GameObject safezone;
    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

    private void Update()
    {
        if (canSeePlayer && !safezone.GetComponent<SafeZone>().playerOn && !PlayerSeen)
        {

            StartCoroutine(BossDamage());


            StartCoroutine(CutscenePlayer(cutsceneTimer));
        }

    }

    IEnumerator CutscenePlayer(float cutsceneTime)
    {
        cameraAtual.SetActive(false);
        fakePlayer.SetActive(true);
        cameraCutscene.SetActive(true);
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = teleportStart.transform.position;
        player.transform.rotation = teleportStart.transform.rotation;
        fakeBoss.SetBool("PlayerOn", true);

        yield return new WaitForSeconds(cutsceneTime);

        player.GetComponent<CharacterController>().enabled = true;
        cameraAtual.SetActive(true);
        cameraCutscene.SetActive(false);
        fakeBoss.SetBool("PlayerOn", false);
        fakePlayer.SetActive(false);
    }


    IEnumerator BossDamage()
    {
        PlayerSeen = true;

        GameManager.playerLifes--;
        GameManager.gameScore -= 100;
        Debug.Log("VEr");


        yield return new WaitForSeconds(10);


        PlayerSeen = false;
    }
}
