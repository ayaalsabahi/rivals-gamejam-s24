using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class HackController : MonoBehaviour
{

    public Button choice1;
    public string choice1Txt;
    public Button choice2;
    public string choice2Txt;
    public Button choice3;
    public string choice3Txt;

    public TMP_Text blankSpot;

    public wordSelection wordGenerator;

    public string word;

    public List<Tuple<string, string>> toCheckList;

    public Tuple<string, string> toCheck;



    // Start is called before the first frame update
    void Start()
    {
        wordGenerator = GameObject.Find("wordManager").GetComponent<wordSelection>();
        List<Tuple<string, string>> words = new List<Tuple<string, string>>(wordGenerator.getRandomWords());

        toCheckList = words;

        choice1Txt = "\"" + words[0].Item2 + "\"" + "\n" + "to" + "\n \"" + words[0].Item1 + "\"";
        choice2Txt = "\"" + words[1].Item2 + "\"" + "\n" + "to" + "\n \"" + words[1].Item1 + "\"";
        choice3Txt = "\"" + words[2].Item2 + "\"" + "\n" + "to" + "\n \"" + words[2].Item1 + "\"";
        
        choice1.onClick.AddListener(ChangeBlankTo1);
        choice2.onClick.AddListener(ChangeBlankTo2);
        choice3.onClick.AddListener(ChangeBlankTo3);
        GameObject.Find("HackButton").GetComponent<Button>().onClick.AddListener(Hack);
    }

    // Update is called once per frame
    void Update()
    {
        SetButtonText();
    }

    void SetButtonText()
    {
        choice1.GetComponentInChildren<TMP_Text>().text = choice1Txt;
        choice2.GetComponentInChildren<TMP_Text>().text = choice2Txt;
        choice3.GetComponentInChildren<TMP_Text>().text = choice3Txt;
    }

    void ChangeBlankTo1()
    {
        toCheck = toCheckList[0];
        blankSpot.text = choice1.GetComponentInChildren<TMP_Text>().text;
        GameManager.S.PlayClickSound();
    }

    void ChangeBlankTo2()
    {
        toCheck = toCheckList[1];
        blankSpot.text = choice2.GetComponentInChildren<TMP_Text>().text;
        GameManager.S.PlayClickSound();
    }

    void ChangeBlankTo3()
    {
        toCheck = toCheckList[2];
        blankSpot.text = choice3.GetComponentInChildren<TMP_Text>().text;
        GameManager.S.PlayClickSound();
    }

    public void Hack()
    {

        if(blankSpot.text != "")
        {
            GameManager.S.PlayClickSound();
            Debug.Log("reached end of hacking");
            GameManager.S.SwitchTurn();
            GameManager.S.TimerAnimationStuff();
            wordGenerator.currWord.Item1 = toCheck.Item1;
            wordGenerator.currWord.Item2 = toCheck.Item2;
            word = blankSpot.text;
            SceneManager.LoadScene("sabotageeScene");
            
        }
    }

}
