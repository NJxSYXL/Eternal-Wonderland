using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRotate : MonoBehaviour
{
    public void TriggerRotate()
    {
        if (!puzzleArt.youWin)
        {
            transform.Rotate(0f, 0f, 90f);
        }
    }
}
