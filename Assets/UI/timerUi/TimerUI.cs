using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class SpriteCarousel : MonoBehaviour
{
    public TextMeshProUGUI timerText; // TextMeshPro for displaying the timer
    public Image displayImage; // The UI Image to display the current sprite
    public List<Sprite> spriteList; // List of sprites for the carousel
    public float switchDelay = 5f; // Time delay before switching each sprite
    private float timeRemaining; // Current time left for switching
    public float initialTime = 5f; // The initial time for each countdown
    private bool timerIsRunning = true; // To track if the timer is running
    private int currentSpriteIndex = 0; // Tracks which sprite is currently active

    private void Start()
    {
        // Initialize timeRemaining with the initial time value
        timeRemaining = initialTime;

        // Set the first sprite to be displayed
        if (spriteList.Count > 0)
        {
            displayImage.sprite = spriteList[currentSpriteIndex];
        }
        else
        {
            Debug.LogWarning("No sprites found in the sprite list.");
        }
    }

    private void Update()
    {
        // If the timer is running, decrement time and update the timer text
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerUI(timeRemaining);
            }
            else
            {
                // Time is up, switch to the next sprite
                SwitchToNextSprite();
                timeRemaining = initialTime; // Reset timer after switching sprites
            }
        }
    }

    // Update the timer text in the UI using TextMeshPro
    private void UpdateTimerUI(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Switch to the next sprite in the carousel
    private void SwitchToNextSprite()
    {
        // Move to the next sprite in the list
        currentSpriteIndex = (currentSpriteIndex + 1) % spriteList.Count;

        // Set the next sprite on the Image component
        displayImage.sprite = spriteList[currentSpriteIndex];
    }
}