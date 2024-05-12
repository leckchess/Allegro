using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Keys")]
    public KeyCode interactionKey = KeyCode.E;

    [Header("Interaction")]
    public float interactionDistance = 5.0f;
    public LayerMask interactableLayer;


    // private section
    private Interactable currentInteractable;

    void Update()
    {
        #region Interaction
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            Interactable interactableObject = hit.collider.GetComponent<Interactable>();

            if (interactableObject != null)
            {
                if (currentInteractable != interactableObject)
                {
                    if (currentInteractable != null)
                    {
                        currentInteractable.OnUnHover();
                    }

                    currentInteractable = interactableObject;

                    currentInteractable.OnHover();
                }

                if (Input.GetKeyDown(interactionKey))
                {
                    interactableObject.Interact();
                }
            }
        }
        else
        {
            if (currentInteractable != null)
            {
                currentInteractable.OnUnHover();
                currentInteractable = null;
            }
        }

        #endregion
    }
}
