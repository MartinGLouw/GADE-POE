using System;
using System.IO;
using TMPro;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public ScoreScript scoreScript;
    public TextMeshProUGUI playerDataText;
    private static string filePath;

    private void Start()
    {
        filePath = "C:/Users/marti/Documents/Year2 vega/GameDev/GADE-POE/GADE POE/playerdata.txt";
    }

    public static void SavePlayerData()
    {
        string name = InputName.Name;
        int score = ScoreScript.scoreStore;

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
        string text = "";
        for (int i = 0; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');
            text += "Name: " + values[0] + "\nScore: " + values[1] + "\n\n";
        }

        // Update TextMeshPro text
        playerDataText.text = text;
    }
}
