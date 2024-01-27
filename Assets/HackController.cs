using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class HackController : MonoBehaviour
{

    public Button choice1;
    public string choice1Txt;
    public Button choice2;
    public string choice2Txt;
    public Button choice3;
    public string choice3Txt;

    public TMP_Text blankSpot;

    private wordSelection[] words;
    


    // Start is called before the first frame update
    void Start()
    {
        choice1.onClick.AddListener(ChangeBlankTo1);
        choice2.onClick.AddListener(ChangeBlankTo2);
        choice3.onClick.AddListener(ChangeBlankTo3);
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


    void MouseExit()
    {
        blankSpot.text = "";
        Debug.Log("Mouse left.");
    }

}
