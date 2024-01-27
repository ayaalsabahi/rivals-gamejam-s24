using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

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
    


    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(wordGenerator.GetType());
        Debug.Log(GameObject.Find("Canvas").GetComponent<wordSelection>().GetType());
        wordGenerator = GameObject.Find("Canvas").GetComponent<wordSelection>();
        Debug.Log(wordGenerator.GetType());
        List<Tuple<string, string>> words = new List<Tuple<string, string>>(wordGenerator.getRandomWords());

        choice1Txt = words[0].Item1;
        choice2Txt = words[1].Item1;
        choice3Txt = words[2].Item1;
        
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
        blankSpot.text = choice1.GetComponentInChildren<TMP_Text>().text;
    }

    void ChangeBlankTo2()
    {
        blankSpot.text = choice2.GetComponentInChildren<TMP_Text>().text;
    }

    void ChangeBlankTo3()
    {
        blankSpot.text = choice3.GetComponentInChildren<TMP_Text>().text;
    }


    public void Hack()
    {
        SceneManager.LoadScene("sabotageeScene");
        word = blankSpot.text;
        Debug.Log(word);
    }

}
