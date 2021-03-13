using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class CombinationLoader
{ 
    public static List<int> Load(List<int> defaultCombination)
    {
        EnsureFileExists(defaultCombination);
        return ReadCombinationFromFile();
    }

    private static void EnsureFileExists(List<int> defaultCombination)
    {
        if (!File.Exists("Assets/Text/combination.txt"))
            CreateFile(defaultCombination);
    }

    private static void CreateFile(List<int> defaultCombination)
    {
        EnsureDirectoryExists();

        StreamWriter writer = new StreamWriter("Assets/Text/combination.txt");
        foreach (int combinationEntry in defaultCombination)
        {
            writer.WriteLine(combinationEntry);
        }
        writer.Close();
            
    }
    private static void EnsureDirectoryExists()
    {
        if (!Directory.Exists("Assets/Text"))
            Directory.CreateDirectory("Assets/Text");
    }
    private static List<int> ReadCombinationFromFile()
    {
        List<int> combination = new List<int>();

        StreamReader reader = new StreamReader("Assets/Text/combination.txt");
        string combinationNumber = string.Empty;
        while((combinationNumber = reader.ReadLine()) != null)
        {
            int combinationInteger = int.Parse(combinationNumber);
            combination.Add(combinationInteger);
        }
        reader.Close();
        return combination;
    }
}
