using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Pickupable,
    Interactable
}

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private string interactableName;
    [SerializeField] private ObjectType objectType;
    [SerializeField] private bool autoTrigger;
    private CanvasGroup cg;

    private bool playerEntered = false;

    private void Awake()
    {
        if (transform.Find("Canvas") != null)
            cg = transform.Find("Canvas").GetComponent<CanvasGroup>();

        if (cg != null)
            cg.alpha = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        if (autoTrigger)
        {
            InteractableManager.SetInteractableAreaName(interactableName);
            InteractableManager.Instance.TriggerInteractable();
            return;
        }

        cg.alpha = 1f;

        InteractableManager.SetInteractableAreaName(interactableName);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        if (!autoTrigger)
            cg.alpha = 0f;

        InteractableManager.ClearInteractableAreaName();
    }
}