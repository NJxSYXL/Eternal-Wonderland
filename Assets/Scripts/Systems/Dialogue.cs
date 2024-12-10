using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Dialogue
{
    public string characterName;
    public Sprite characterIcon;
    [TextArea(3,10)]
    public string sentences;
    public UnityEvent afterDialogueEvent;
}