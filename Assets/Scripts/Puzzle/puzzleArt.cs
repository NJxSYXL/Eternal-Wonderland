using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class puzzleArt : MonoBehaviour
{
    [SerializeField] private Transform[] pieces;

    public UnityEvent EventToTrigger;
    public static bool youWin;

    private void Start()
    {
        youWin = false;
    }

    private void Update()
    {
        if (youWin) return;

        if(pieces[0].rotation.z == 0 &&
            pieces[1].rotation.z == 0 &&
            pieces[2].rotation.z == 0 &&
            pieces[3].rotation.z == 0 &&
            pieces[4].rotation.z == 0 &&
            pieces[5].rotation.z == 0)
        {
            EventToTrigger.Invoke();
            gameObject.SetActive(false);
        }
    }
}
