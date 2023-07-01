using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject HighScore;
    public GameObject MainMenu;
    public GameObject PauseMenu;
    public GameObject End;
    
    public void Highscores()
    {
        MainMenu.SetActive(false);
        HighScore.SetActive(true);
    }
    public void HighscoresGame()
    {
        PauseMenu.SetActive(false);
        HighScore.SetActive(true);
    }
    public void HighscoresEnd()
    {
        End.SetActive(false);
        HighScore.SetActive(true);
    }

    public void Back()
    {
        MainMenu.SetActive(true);
        HighScore.SetActive(false);
    }
    public void BackGame()
    {
        PauseMenu.SetActive(true);
        HighScore.SetActive(false);
    }
    public void BackEnd()
    {
        End.SetActive(true);
        HighScore.SetActive(false);
    }
}
