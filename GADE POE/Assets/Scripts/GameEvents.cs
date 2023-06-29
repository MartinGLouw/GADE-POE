using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }
    
    public float timeSinceStart = 0f;
    public int Bossscore = 0;
    public void BossScore()
    {
        timeSinceStart += Time.deltaTime;
        if (timeSinceStart >= 260f || timeSinceStart >= 140f)
        {
            Bossscore++;
            
        }
        if (timeSinceStart >= 280f)
        {
            
            timeSinceStart = 0f;
        }
    }

}