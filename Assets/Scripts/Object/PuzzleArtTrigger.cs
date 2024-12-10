using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PuzzleArtTrigger : MonoBehaviour
{
    public UnityEvent openPuzzle;
    public void TriggerPuzzle()
    {
        if(NotesManager.GetAmount() >= 6)
        {
            openPuzzle.Invoke();
        }
        else
        {
            GetComponent<DialogueContent>().TriggerDialogue();
        }
    }
}
