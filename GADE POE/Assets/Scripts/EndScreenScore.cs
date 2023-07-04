using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreenScore : ScoreScript
{
    public TextMeshProUGUI ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = ("Score: " + ScoreScript.score);
    }

    // Update is called once per frame
   
}
