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

        if (inputTextLower == test.currWord.Item2.ToLower()) HandleWinning();
        else HandleLosing();
    }

    private void GoToSabotagerOnClick()
    {
        //add some sort of transition
        SceneManager.LoadScene("SampleScene");
    }


    private void HandleWinning()
    {
        isFound = true;
        Debug.Log("Line 2");

        if(GameManager.S == null)
        {
            Debug.Log("oh no :(");
        }

        Debug.Log("Player two");
        if (GameManager.S.playerOne) GameManager.S.CorrectAnswer(GameManager.S.playerOne);

        else GameManager.S.CorrectAnswer(GameManager.S.playerTwo);
        Debug.Log("Line 1");
        if (GameManager.S.winnerIs == winnerState.playerOneWin || GameManager.S.winnerIs == winnerState.playerTwoWin) { 
            Debug.Log("SWITCHHH");
            SceneManager.LoadScene("winning");
        }
        else
        {
            //add to the progress bar
            ColorBlock colors = goToSabotagerButton.colors;
            colors.normalColor = Color.green;
            goToSabotagerButton.colors = colors;
        }

    }

    private void HandleLosing()
    {
            if (GameManager.S.strikeCountPlayerOne >= GameManager.S.STRIKE_COUNT || GameManager.S.strikeCountPlayerTwo >= GameManager.S.STRIKE_COUNT) SceneManager.LoadScene("losing");

            if (GameManager.S.playerOne) GameManager.S.strikeCountPlayerOne++;
            else GameManager.S.strikeCountPlayerTwo++;


            //add the strike check count
            ColorBlock colors = goToSabotagerButton.colors;
            colors.normalColor = Color.red;
            goToSabotagerButton.colors = colors;
    }
    //progress bar function


    //strike function
}
