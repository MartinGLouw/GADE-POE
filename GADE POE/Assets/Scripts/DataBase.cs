using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public ScoreScript scoreScript;
    public TextMeshProUGUI playerDataText;
    private static string filePath;
    
    
        public static DataBase Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        
    

    private void Start()
    {
        var fileName = "playerdata.txt";
    #if UNITY_EDITOR
        filePath = Application.dataPath + "/" + fileName;
    #else
        filePath = Application.dataPath + "/../" + fileName;
    #endif
    }

    private void Update()
    {
        var fileName = "playerdata.txt";
#if UNITY_EDITOR
        filePath = Application.dataPath + "/" + fileName;
    #else
        filePath = Application.dataPath + "/../" + fileName;
    #endif
    }

    public static void SavePlayerData()
    {
        string name = InputName.Name;
        int score = ScoreScript.ScoreStore;

        // Read data from file
        string[] lines = File.ReadAllLines(filePath);

        // Find player record with matching name
        bool playerFound = false;
        for (int i = 0; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');
            if (values[0] == name)
            {
                // Update score if new score is higher
                int existingScore = int.Parse(values[1]);
                if (score > existingScore)
                {
                    values[1] = score.ToString();
                    lines[i] = string.Join(",", values);
                }
                playerFound = true;
                break;
            }
        }

        // If player not found, add new record
        if (!playerFound)
        {
            string data = name + "," + score;
            Array.Resize(ref lines, lines.Length + 1);
            lines[lines.Length - 1] = data;
        }

        // Write updated data to file
        File.WriteAllLines(filePath, lines);
    }

    public void LoadAllPlayerData()
    {
        // Read data from file
        string[] lines = File.ReadAllLines(filePath);

        // Parse player data
        List<Tuple<string, int>> playerData = new List<Tuple<string, int>>();
        for (int i = 0; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');
            playerData.Add(new Tuple<string, int>(values[0], int.Parse(values[1])));
        }

        // Sort player data by score in descending order
        playerData.Sort((x, y) => y.Item2.CompareTo(x.Item2));

        // Update TextMeshPro text
        string text = "";
        foreach (var data in playerData)
        {
            text += "Name: " + data.Item1 + "\nScore: " + data.Item2 + "\n\n";
        }
        playerDataText.text = text;
    }

}
