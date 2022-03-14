using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
// used this link for this class

public class Timer : MonoBehaviour
{
    public static float timeRemaining = 120;
    public static float fruitTimer = 0;
    public static bool timerIsRunning = false;
    public Text timeText;

    private void Start()
    {
        timeText = GetComponent<Text>();
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if ((timeRemaining > 0) && (Bomb.sliceNum < 3))
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                fruitTimer = Mathf.FloorToInt(timeRemaining % 60);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}