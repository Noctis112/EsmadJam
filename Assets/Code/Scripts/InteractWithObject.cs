using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InteractWithObject : MonoBehaviour
{
    public InputActionReference pickupAction;
    [SerializeField] private Collider interactZone;
    [SerializeField] private float interactionTime = 2f;
    [SerializeField] GameObject interactableObject;
    [SerializeField] GameObject buttScanPage;
    [SerializeField] GameObject eletricidadeColider;
    [SerializeField] GameObject lights;

    private bool canInteract = false;
    private bool isInteracting = false;
    private float interactionTimer = 0f;

    [SerializeField] private Slider interactionSlider; // Reference to the UI slider for the interaction progress
    [SerializeField] GameObject slider;
    [SerializeField] Animator portaEsq;
    [SerializeField] Animator portaDir;
    [SerializeField] Animator portaEletricidade;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    void Update()
    {
        // Only allow interaction if the player is inside the interact zone
        if (!canInteract)
        {
            return;
        }

        // Check if the interaction button is pressed
        if (pickupAction.action.triggered)
        {
            isInteracting = true;
            interactionTimer = 0f;
        }
        // If the interaction button is released, reset the interaction
        pickupAction.action.canceled +=
            ctx =>
            {
                Debug.Log("Cancelado");
                isInteracting = false;
                interactionTimer = 0f;
                slider.SetActive(false);
            };

        // Perform the interaction while the button is held down and the player is inside the interact zone
        if (isInteracting && canInteract)
        {
            interactionTimer += Time.deltaTime;
            slider.SetActive(true);
            interactionSlider.value = interactionTimer / interactionTime;

            if (interactionTimer >= interactionTime && gameObject.tag == "PC")
            {
                GameManager.missions[1].currentCount++;
                slider.SetActive(false);
                isInteracting = false;
                interactionTimer = 0f;
                interactableObject.GetComponent<Hacked>().GetHacked();
                Destroy(gameObject);
            }
            if (interactionTimer >= interactionTime && gameObject.tag == "Armario")
            {
                slider.SetActive(false);
                portaDir.SetBool("Open", true);
                portaEsq.SetBool("Open", true);
                interactionTimer = 0f;
                Destroy(gameObject);
            }
            if (interactionTimer >= interactionTime && gameObject.tag == "Eletricidade")
            {
                slider.SetActive(false);
                portaEletricidade.SetBool("Activate", true);
                eletricidadeColider.SetActive(true);
                interactionTimer = 0f;
            }
            if (interactionTimer >= interactionTime && gameObject.tag == "Buttscan")
            {
                slider.SetActive(false);
                buttScanPage.SetActive(true);
                interactionTimer = 0f;
                Destroy(interactZone.gameObject);
            }
            if (interactionTimer >= interactionTime && gameObject.tag == "CortarCabo")
            {
                lights.SetActive(false);
                slider.SetActive(false);
                interactionTimer = 0f;
                Destroy(interactZone.gameObject);
                GameManager.missions[3].currentCount++;
            }
        }
    }
}