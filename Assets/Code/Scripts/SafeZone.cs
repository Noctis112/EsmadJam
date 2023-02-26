using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{

    bool playerOn = false;
    bool bossOn = false;

    [SerializeField] GameObject cameraAtual;
    [SerializeField] GameObject cameraCutscene;
    //[SerializeField] GameObject fakePlayer;
    [SerializeField] GameObject player;
    [SerializeField] GameObject teleportStart;

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
        if (!playerOn && bossOn)
        {
            GameManager.playerLifes--;
            StartCoroutine(CutsceneNoPlayer(5f));
        }
    }


    IEnumerator CutsceneNoPlayer(float cutsceneTime)
    {
        cameraAtual.SetActive(false);
        //fakePlayer.SetActive(false);
        cameraCutscene.SetActive(true);
        player.GetComponent<Rigidbody>().
        player.transform.position = teleportStart.transform.position;
        player.transform.rotation = teleportStart.transform.rotation;
        yield return new WaitForSeconds(cutsceneTime);

        cameraAtual.SetActive(true);
        cameraCutscene.SetActive(false);
        //fakePlayer.SetActive(true);
    }
}
