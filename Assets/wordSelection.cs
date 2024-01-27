using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class wordSelection : MonoBehaviour
{
    public (string, string) currWord = ("scrambled", "word");


    //create a script that takes things from a .txt file and puts it into an array 

    private void Start()
    {
        // Make the GameObject this script is attached to persistent across scenes
        DontDestroyOnLoad(gameObject);
        getWords();
        
    }


    private void getWords()
    {
        string fileName = "wordbank.txt";

        // Read all lines from the file
        string filePath = Path.Combine(Application.dataPath, fileName);
        string[] lines = File.ReadAllLines(filePath);
        // Create a list to store tuples
        List<Tuple<string, string>> tupleList = new List<Tuple<string, string>>();

        // Process each line and create tuples
        foreach (string line in lines)
        {
            // Split each line into phrases using the comma
            string[] phrases = line.Split(',');

            // Ensure there are at least two phrases on a line
            if (phrases.Length >= 2)
            {
                // Create a tuple and add it to the list
                Tuple<string, string> tuple = Tuple.Create(phrases[0].Trim(), phrases[1].Trim());
                tupleList.Add(tuple);
            }
            else
            {
                Console.WriteLine("Invalid format on line: " + line);
            }
        }

        // Convert the list to an array
        Tuple<string, string>[] tupleArray = tupleList.ToArray();

    }




}
