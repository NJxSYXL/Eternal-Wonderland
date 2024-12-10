using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotesManager : MonoBehaviour
{
    public int notesCount;
    public TMP_Text notesText;
    public GameObject Paper;
    private static NotesManager _instance;
    private GameObject UICounter;
    public static NotesManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        UICounter = notesText.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        notesText.text = notesCount.ToString();
        bool freezeMovement = GameObject.FindWithTag("Player").GetComponent<PlayerController>().freezeMovement;
        bool isInPuzzle = GameObject.FindWithTag("Player").GetComponent<PlayerController>().isInPuzzle;

        UICounter.SetActive(!(freezeMovement || isInPuzzle));

        if (notesCount == 6)
        {
            if(Paper != null)
            {
                Paper.SetActive(true);
            }
        }
    }

    public static int GetAmount()
    {
        return _instance.notesCount;
    }
}
