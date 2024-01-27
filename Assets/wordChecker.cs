using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class wordChecker : MonoBehaviour
{
    public TMP_InputField textBox;
    public TMP_Text timerText;
    private float timer = 10f;
    private float epsilon = 0.0001f;

    // Start is called before the first frame update
    void Start()
    {
        textBox.onEndEdit.AddListener(HandleInput);

    }

    
    private void Update()
    {
        if(timer > epsilon)
        {
            timer -= Time.deltaTime;
            timerText.text = timerText.text = $"Time left: {timer:F1}";
        }
        else
        {
            //timer over, switch screen!
            Debug.Log("switch over to screen!");
        }
    }

    //handles the user input 
    void HandleInput(string inputText)
    {
        Debug.Log("User input: " + inputText);
        

        string inputTextLower = inputText.ToLower();
        wordSelection test = new wordSelection();

        //when enter is pressed, text goes bye bye
        if (textBox != null) textBox.text = "";

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

    //when scene switches, a countdown timer will start

}
