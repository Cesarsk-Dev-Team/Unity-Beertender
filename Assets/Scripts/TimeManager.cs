using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float targetCountdownTime = 10f;
    [SerializeField] private bool isCountDownTimer = false;
    private bool hasTimerStarted = false;
    private float interval = 1f;
    private float nextTime = 0f;

    public int counter = 0;

    private void Update() 
    {
        if (isCountDownTimer) UpdateCountdownTimer();
        else UpdateTimer();
    }
    private void Start() 
    {
        hasTimerStarted = true;
    }

    private void UpdateTimer() 
    {
        if (hasTimerStarted)
        {
            if (Time.time >= nextTime)
            {
                //do something here every interval seconds
                nextTime += interval;
                if (!isCountDownTimer)
                {
                    counter = counter + GameManager.GetInstance().streak;
                }
            }
        }
    }
    private void UpdateCountdownTimer() 
    {
        if (hasTimerStarted)
        {
            targetCountdownTime -= Time.deltaTime;
            counter++;
            if (targetCountdownTime <= 0.0f)
            {
                Debug.Log("Timer Ended, do something (Game Over?)");
            }
        }
    }

    //Mode = 1 Countdown timer, Mode = 0 Normal Timer
    public void ChangeTimerMode(bool mode) 
    {
        isCountDownTimer = mode;
    }

    //Timer functionalities
    public void ResetTimer() 
    {
        targetCountdownTime = 0f;
    }
    public void StartTimer() 
    {
        hasTimerStarted = true;
    }
    public void StopTimer() 
    {
        hasTimerStarted = false;
    }
}