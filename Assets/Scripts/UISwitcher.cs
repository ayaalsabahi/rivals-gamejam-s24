using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;

public class UISwitcher : MonoBehaviour
{

    public GameManager GM;
    public GameObject P1UI;
    public GameObject P2UI;

    public string name1;
    public string name2;

    public TMP_Text channelName;
    
    // Start is called before the first frame update
    void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        P1UI = GameObject.Find("SabotageUIP1");
        P2UI = GameObject.Find("SabotageUIP2");
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            //if (GM.isPlayerOne)
            //{
            //    channelName.text = name1;
            //}
            //else
            //{
            //    channelName.text = name2;
            //}
        }

        if(SceneManager.GetActiveScene().name != "SampleScene")
        {
            if (GM.isPlayerOne)
            {
                SetP1UI();
            }
            else
            {
                SetP2UI();
            }
        }
    }

    void SetP1UI()
    {
        P1UI.SetActive(true);
        P2UI.SetActive(false);
    }

    void SetP2UI()
    {
        P2UI.SetActive(true);
        P1UI.SetActive(false);
    }

    public void RemoveOverlay()
    {
        P1UI.SetActive(false);
        P2UI.SetActive(false);
    }
}
