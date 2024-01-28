using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class HoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text blankSpot;
    public Button hoveredButton;
    public string original;

    void Start()
    {
        hoveredButton.onClick.AddListener(NameChange);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        original = blankSpot.text;
        blankSpot.text = hoveredButton.GetComponentInChildren<TMP_Text>().text;
        Debug.Log("on me" + hoveredButton.GetComponentInChildren<TMP_Text>().text);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        blankSpot.text = original;
    }

    public void NameChange()
    {
        original = hoveredButton.GetComponentInChildren<TMP_Text>().text;
    }
}

