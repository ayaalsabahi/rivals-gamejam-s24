using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class wordChecker : MonoBehaviour
{
    //viewing aspects 
    public TMP_InputField textBox;
    public TMP_Text timerText;
    public TMP_Text garbledWord;
    public Button goToSabotagerButton;
    

    //logic aspects 
    private float timer = 10f;
    private float epsilon = 0.0001f;
    wordSelection test = new wordSelection();
    bool isFound = false;

    // Start is called before the first frame update
    void Start()
    {
        textBox.onEndEdit.AddListener(HandleInput);
        garbledWord.text = test.currWord.Item1;
        goToSabotagerButton.interactable = false;
        goToSabotagerButton.onClick.AddListener(GoToSabotagerOnClick);
    }

    private void Update()
    {
        if(timer > epsilon && !isFound)
        {
            timer -= Time.deltaTime;
            timerText.text = timerText.text = $"Time left: {timer:F1}";
        }
        else
        {
            Debug.Log("switch over to screen!");
            goToSabotagerButton.interactable = true;
        }

        if (isFound)
        {
            goToSabotagerButton.interactable = true;
        }
    }

    //handles the user input 
    private void HandleInput(string inputText)
    {
        Debug.Log("User input: " + inputText);
        

        string inputTextLower = inputText.ToLower();
        

        //when enter is pressed, text goes bye bye
        if (textBox != null && timer > epsilon) textBox.text = "";

        if (inputTextLower == test.currWord.Item2.ToLower())
        {
            isFound = true;
            Debug.Log("Good");
            //change button color to green
            //if score > max, then switch to win scene
            ColorBlock colors = goToSabotagerButton.colors;
            colors.normalColor = Color.green;
            goToSabotagerButton.colors = colors;
        }
        else
        {
            Debug.Log("BAD!");
            ColorBlock colors = goToSabotagerButton.colors;
            colors.normalColor = Color.red;
            goToSabotagerButton.colors = colors;
        }
    }

    private void GoToSabotagerOnClick()
    {
        //add some sort of transition
        SceneManager.LoadScene("SampleScene");

    }

}
