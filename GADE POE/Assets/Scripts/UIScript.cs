using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject HighScore;
    public GameObject MainMenu;
    public void Highscores()
    {
        MainMenu.SetActive(false);
        HighScore.SetActive(true);
    }

    public void Back()
    {
        MainMenu.SetActive(true);
        HighScore.SetActive(false);
    }
}
