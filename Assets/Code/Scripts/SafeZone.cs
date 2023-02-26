using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{

    public bool playerOn = false;
    bool bossOn = false;

    bool PlayerSeen;

    [SerializeField] float cutsceneTimer;
    [SerializeField] GameObject cameraAtual;
    [SerializeField] GameObject cameraCutscene;
    [SerializeField] GameObject fakePlayer;
    [SerializeField] GameObject player;
    [SerializeField] GameObject teleportStart;
    [SerializeField] Animator fakeBoss;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOn = true;
        }
        if (other.tag == "Boss")
        {
            bossOn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOn = false;
        }
        if (other.tag == "Boss")
        {
            bossOn = false;
        }
    }

    private void Update()
    {
        if (playerOn && bossOn)
        {
            return;
        }
        if (!playerOn && bossOn && !PlayerSeen)
        {
            StartCoroutine(BossDamage());
            StartCoroutine(CutsceneNoPlayer(cutsceneTimer));
        }
    }


    IEnumerator CutsceneNoPlayer(float cutsceneTime)
    {
        cameraAtual.SetActive(false);
        fakePlayer.SetActive(false);
        cameraCutscene.SetActive(true);
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = teleportStart.transform.position;
        player.transform.rotation = teleportStart.transform.rotation;
        fakeBoss.SetBool("PlayerOff", true);

        yield return new WaitForSeconds(cutsceneTime);

        player.GetComponent<CharacterController>().enabled = true;
        cameraAtual.SetActive(true);
        cameraCutscene.SetActive(false);
        fakeBoss.SetBool("PlayerOff", false);
        fakePlayer.SetActive(true);
    }

    IEnumerator BossDamage()
    {
        PlayerSeen = true;

        GameManager.playerLifes--;
        GameManager.gameScore -= 100;
        Debug.Log("safeZone");
        yield return new WaitForSeconds(10);


        PlayerSeen = false;
    }
}
