using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.S)
        {
            Destroy(GameManager.S.gameObject);
        }

        //SoundManager.S.StartTheMusic();
    }

    public void btn_StartTheGame()
    {
        Debug.Log("Start Button Clicked");
        //SoundManager.S.StopTheMusic();
        // Stop all game sounds and coroutines
        SceneManager.LoadScene("SampleScene");
    }

    public void btn_GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void btn_GoToScene(string thisScene)
    {
        SceneManager.LoadScene(thisScene);
    }

    public void btn_QuitTheGame()
    {
        Application.Quit();
    }
}
