using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueContent : MonoBehaviour
{
    public List<Dialogue> dialogue = new List<Dialogue>();
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
