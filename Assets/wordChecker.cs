using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class wordChecker : MonoBehaviour
{
    public TMP_InputField textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox.onEndEdit.AddListener(HandleInput);
    }

    void HandleInput(string inputText)
    {
        Debug.Log("User input: " + inputText);

        string inputTextLower = inputText.ToLower();
        wordSelection test = new wordSelection();

        if (inputTextLower == test.currWord.Item2.ToLower())
        {
            Debug.Log("Good");
            //change state
        }
        else
        {
            Debug.Log("BAD!");
            //change to the second player 
        }
    }

    
}
