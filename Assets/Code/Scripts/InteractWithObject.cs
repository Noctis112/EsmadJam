using UnityEngine;
using UnityEngine.InputSystem;

public class InteractWithObject : MonoBehaviour
{
    [SerializeField] private GameObject interactObject;
    [SerializeField] private Collider interactZone;
    [SerializeField] private float interactionTime = 2f;

    private bool canInteract = false;
    private bool isInteracting = false;
    private float interactionTimer = 0f;

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
        if (StarterAssets.Player.PickupItem.triggered)
        {
            isInteracting = true;
            interactionTimer = 0f;
        }

        // If the interaction button is released, reset the interaction
        if (StarterAssets.Player.PickupItem.phase == InputActionPhase.Canceled)
        {
            isInteracting = false;
            interactionTimer = 0f;
        }

        // Perform the interaction while the button is held down and the player is inside the interact zone
        if (isInteracting && canInteract)
        {
            interactionTimer += Time.deltaTime;

            if (interactionTimer >= interactionTime)
            {
                interactObject.SendMessage("Interact");
                isInteracting = false;
                interactionTimer = 0f;
            }
        }
    }
}