using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HackController : MonoBehaviour
{

    public Button choice1;
    public string choice1Txt;
    public Button choice2;
    public string choice2Txt;
    public Button choice3;
    public string choice3Txt;

    private wordSelection[] words;


    // Start is called before the first frame update
    void Start()
    {
        choice1 = GameObject.Find("Choice1").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        SetButtonText();
    }

    void SetButtonText()
    {
        choice1.GetComponentInChildren<Text>().text = choice1Txt;
        choice2.GetComponentInChildren<Text>().text = choice2Txt;
        choice3.GetComponentInChildren<Text>().text = choice3Txt;
    }
}
