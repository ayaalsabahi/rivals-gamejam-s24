using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordSelection : MonoBehaviour
{
    public (string, string) currWord = ("scrambled", "word");

    private void Start()
    {
        // Make the GameObject this script is attached to persistent across scenes
        DontDestroyOnLoad(gameObject);
    }


}
