using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    private Queue<Dialogue> sentences;
    public Animator animator;
    public Animator spriteIcon;
    public Image characterIcon;
    public bool isInDialogue = false;
    private UnityEvent eventToRun;

    private static DialogueManager _instance;
    public static DialogueManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Dialogue manager is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        sentences = new Queue<Dialogue>();
    }

    public void StartDialogue(List<Dialogue> dialogue)
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().SetFreezeMovement(true);

        animator.SetBool("isOpen", true);
        spriteIcon.SetBool("isOpen", true);
        isInDialogue = true;
        
        sentences.Clear();

        foreach(var d in dialogue)
        {
            sentences.Enqueue(d);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (eventToRun != null)
        {
            if (eventToRun.GetPersistentEventCount() > 0)
            {
                eventToRun.Invoke();
            }
        }

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        Dialogue sentence = sentences.Dequeue();
        eventToRun = sentence.afterDialogueEvent;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(Dialogue sentence)
    {
        nameText.text = sentence.characterName;
        dialogueText.text = "";
        characterIcon.sprite = sentence.characterIcon;
        foreach (char letter in sentence.sentences.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        StopAllCoroutines();
        dialogueText.text = "";
        nameText.text = "";
        animator.SetBool("isOpen", false);
        spriteIcon.SetBool("isOpen", false);
        //Debug.Log("End of conversation.");
        isInDialogue = false;
        eventToRun = null;
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().SetFreezeMovement(false);
    }
}
