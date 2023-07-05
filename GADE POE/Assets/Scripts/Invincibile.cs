using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Invincibile : MonoBehaviour
{
    public RawImage image; // Assign the RawImage in the Inspector
    public TextMeshProUGUI timerText; // Assign the TextMeshProUGUI in the Inspector

    private bool isInvincible = false;
    private Coroutine invincibilityCoroutine;

    void Start()
    {
        gameObject.tag = "Player";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isInvincible)
            {
                DeactivateInvincibility();
            }
            else
            {
                ActivateInvincibility();
            }
        }
    }

    private void ActivateInvincibility()
    {
        isInvincible = true;
        gameObject.tag = "Strong";
        image.enabled = true; // Show the RawImage
    }


    private void DeactivateInvincibility()
    {
        isInvincible = false;
        gameObject.tag = "Player";
        image.enabled = false; // Hide the RawImage
        timerText.text = "";
        if (invincibilityCoroutine != null)
        {
            StopCoroutine(invincibilityCoroutine);
        }
    }

    private IEnumerator InvincibilityTimer()
    {
        float timeRemaining = 10f;
        while (timeRemaining > 0)
        {
            timerText.text = "Time Remaining: " + timeRemaining.ToString("F1");
            yield return new WaitForSeconds(0.1f);
            timeRemaining -= 0.1f;
        }
        DeactivateInvincibility();
    }
}
