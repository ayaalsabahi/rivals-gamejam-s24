using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class wordSelection : MonoBehaviour
{
    public static wordSelection WordSelection;

    public (string, string) currWord = ("scrambled", "word");
    // public (string, string) currWord = ("scrambled", "word");

    
    //create a script that takes things from a .txt file and puts it into an array 
    public Tuple<string, string>[] wordArray { get; private set; }

    private void Awake()
    {
        // Make the GameObject this script is attached to persistent across scenes
        //DontDestroyOnLoad(gameObject);
        wordArray = getWords();
    }


    private Tuple<string, string>[] getWords()
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
        return tupleArray;
        
    }


    public Tuple<string, string>[] getRandomWords()
    {
        int firstChoice = 0;
        int secondChoice = 0;
        int thirdChoice = 0;
        var rng = new System.Random();
        int arrayLength = wordArray.Length;

        while (firstChoice == secondChoice || firstChoice == thirdChoice)
        {
            firstChoice = rng.Next(0, arrayLength);
            secondChoice = rng.Next(0, arrayLength);
            thirdChoice = rng.Next(0, arrayLength);
        }

        Tuple<string, string>[] selectedWords = new Tuple<string, string>[3];

        // Get the selected tuples and add them to the array
        selectedWords[0] = wordArray[firstChoice];
        selectedWords[1] = wordArray[secondChoice];
        selectedWords[2] = wordArray[thirdChoice];
        // Return the array with the selected tuples
        return selectedWords;

    }


}
