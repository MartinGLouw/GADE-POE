using System;
using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour 
{
    [SerializeField]
    public static float score; //score variable
    public TextMeshProUGUI scoreText; //score ui object
    public TextMeshProUGUI BossText; 
    private bool doublePointsActive = false; //flag to check if double points are active
    private float doublePointsDuration = 15f; //duration of double points in seconds
    public RawImage image; // Assign the RawImage in the Inspector
    public TextMeshProUGUI timerText; // Assign the TextMeshProUGUI in the Inspector
    private Coroutine doublePointsCoroutine; // Reference to the current DoublePoints coroutine
    public static int ScoreStore;

    public void Start()
    {
        
    }
    public float timeSinceStart = 0f;
    public int Bossscore = 0;
    private bool bossScoreIncremented1 = false;
    private bool bossScoreIncremented2 = false;

    public void Update()
    {
        ScoreStore = Convert.ToInt32(score);

        timeSinceStart += Time.deltaTime;
        if (timeSinceStart >= 260f && !bossScoreIncremented1)
        {
            Bossscore++;
            bossScoreIncremented1 = true;
        }
        if (timeSinceStart >= 140f && !bossScoreIncremented2)
        {
            Bossscore++;
            bossScoreIncremented2 = true;
        }
        if (timeSinceStart >= 280f)
        {
            timeSinceStart = 0f;
            bossScoreIncremented1 = false;
            bossScoreIncremented2 = false;
        }

        BossText.text = ("Boss Score: " + Bossscore);
    }


    private void OnEnable()
    {
        GameEvents2.current.onScoreTriggerEnter += OnScoreTriggerEnter;
        GameEvents2.current.onDoubleTriggerEnter += OnDoubleTriggerEnter;
        GameEvents2.current.onDPPointsTriggerEnter += OnDPPointsTriggerEnter;
    }

    private void OnDisable()
    {
        GameEvents2.current.onScoreTriggerEnter -= OnScoreTriggerEnter;
        GameEvents2.current.onDoubleTriggerEnter -= OnDoubleTriggerEnter;
        GameEvents2.current.onDPPointsTriggerEnter -= OnDPPointsTriggerEnter;
    }

    private void OnScoreTriggerEnter()
    {
        if (doublePointsActive)
        {
            
            score += 2f;
        }
        else
        {
            
            score += 1f;
        }
      
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void OnDoubleTriggerEnter()
    {
        if (doublePointsActive)
        {
            score += 4f;
        }
        else
        {
           
            score += 2f;
        }
        
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void OnDPPointsTriggerEnter()
    {
        if (doublePointsCoroutine != null)
        {
            StopCoroutine(doublePointsCoroutine);
            doublePointsCoroutine = null;
        }
       doublePointsCoroutine = StartCoroutine(DoublePoints(doublePointsDuration));
   }

   IEnumerator DoublePoints(float duration)
   {
       doublePointsActive = true;
       image.enabled = true; // Show the RawImage

       float timeRemaining = duration;
       while (timeRemaining > 0)
       {
           timerText.text = "Time Remaining: " + timeRemaining.ToString("F1");
           yield return new WaitForSeconds(0.1f);
           timeRemaining -= 0.1f;
       }

       doublePointsActive = false;
       image.enabled = false; // Hide the RawImage
       timerText.text = "";
   }

   public void ResetScore() // when restart is clicked the score is set to zero
   {
       score = 0;
   }
}
