using UnityEngine;
using UnityEngine.InputSystem;

public class PickItemUp : MonoBehaviour
{
    public InputActionReference pickupAction;
    public float pickupDistance = 2.0f;

    private GameObject heldItem = null;

    private void OnEnable()
    {
        // Enable the input action when the script is enabled
        pickupAction.action.Enable();

        // Attach a callback function to the input action's "performed" event
        pickupAction.action.performed += OnPickupAction;
    }

    private void OnDisable()
    {
        // Disable the input action when the script is disabled
        pickupAction.action.Disable();

        // Detach the callback function from the input action's "performed" event
        pickupAction.action.performed -= OnPickupAction;
    }

    private void OnPickupAction(InputAction.CallbackContext context)
    {
        if (heldItem == null)
        {
            // Try to pick up an item
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance))
            {
                if (hit.collider.CompareTag("Pickup"))
                {
                    // Pick up the item
                    heldItem = hit.collider.gameObject;
                    heldItem.transform.parent = transform;
                    heldItem.transform.localPosition = new Vector3(0.0f, 0.5f, pickupDistance);
                    heldItem.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
        else
        {
            // Drop the held item
            heldItem.transform.parent = null;
            heldItem.GetComponent<Rigidbody>().isKinematic = false;
            heldItem = null;
        }
    }
}