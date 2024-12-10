using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class puzzleGate : MonoBehaviour
{
    public TMP_InputField Password;
    private string inputtedText = "";

    

    public void CheckPassword()
    {
        if (inputtedText == "QUEEN")
        {
            Debug.Log("Correct Password!");
            SceneManager.LoadSceneAsync("Ending");
        }
        else
        {
            Debug.Log("Incorrect Password!");
            Password.text = "";
        }
    }
    private void Update()
    {
        if (Password.text.Length > 5)
        {
            Password.text = inputtedText;
        }
        else
        {
            inputtedText = Password.text;
        }

        inputtedText = inputtedText.ToUpper();
    }
}
