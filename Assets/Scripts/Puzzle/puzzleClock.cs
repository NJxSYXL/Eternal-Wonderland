using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleClock : MonoBehaviour
{
    [SerializeField]
    private Transform minuteHand, hourHand;
    private static puzzleClock _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        //winText.SetActive(false);
    }

    public static void MoveHand()
    {
        _instance.minuteHand.Rotate(Vector3.back, 30);
        _instance.hourHand.Rotate(Vector3.back, 2.5f);

        Debug.LogFormat("Hour: {0}, Minute: {1}", Mathf.Round(_instance.minuteHand.rotation.eulerAngles.z * 2) / 2, Mathf.Round(_instance.hourHand.rotation.eulerAngles.z * 2) / 2);

        if ((Mathf.Round(_instance.minuteHand.rotation.eulerAngles.z * 2) / 2) == 330
            && (Mathf.Round(_instance.hourHand.rotation.eulerAngles.z*2)/2) == 177.5f)
        {
            //winText.SetActive(true);
            SceneManager.LoadSceneAsync("Level 2");
        }
    }
}
