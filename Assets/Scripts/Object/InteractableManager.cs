using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;


[System.Serializable]
public class Interactable
{
    public string InteractableName;
    public UnityEvent InteractableEvent;
    public bool onlyInteractOnce;
    [HideInInspector] public bool isAlreadyInteracted;
}

public class InteractableManager : MonoBehaviour
{
    public List<Interactable> interactables;
    private static string interactableAreaName;

    private static InteractableManager _instance;
    public static InteractableManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Interactable Manager is null");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        print(_instance);
    }

    public static void SetInteractableAreaName(string name)
    {
        print(name);    
        interactableAreaName = name;
    }

    public static void ClearInteractableAreaName()
    {
        print("clear");
        interactableAreaName = null;
    }

    public bool CheckInteractStatus(string name)
    {
        Interactable ie = interactables.FirstOrDefault(i => i.InteractableName == name);
        if (ie == null)
            Debug.LogError("Interaction is not valid");

        if (ie.onlyInteractOnce)
            return ie.isAlreadyInteracted;

        return false;
    }

    public bool TriggerInteractable()
    {
        if (interactableAreaName == null) return false;

        Interactable ie = interactables.FirstOrDefault(i => i.InteractableName == interactableAreaName);
        if (ie == null)
            Debug.LogError("Interaction is not valid");

        if (ie.isAlreadyInteracted) return false;

        if (ie.onlyInteractOnce)
            ie.isAlreadyInteracted = true;

        ie.InteractableEvent.Invoke();
        return true;
    }
}
