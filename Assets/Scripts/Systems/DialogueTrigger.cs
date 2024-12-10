using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public List<Dialogue> dialogue = new List<Dialogue>();
    private bool alreadyTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (alreadyTriggered == true) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            alreadyTriggered = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
