using UnityEngine;
using TMPro;
using System;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining;
    private bool isRunning = false;
    private Action onTimerEnd;
    private TextMeshPro uiText;

    public void StartTimer(float seconds, TextMeshPro textToUpdate, Action callback = null)
    {
        timeRemaining = seconds;
        isRunning = true;
        onTimerEnd = callback;
        uiText = textToUpdate;
        UpdateTextDisplay();
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private void Update()
    {
        if (isRunning)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isRunning = false;
                UpdateTextDisplay();
                onTimerEnd?.Invoke();
                Debug.Log("Timer Ended");
            }
            else
            {
                UpdateTextDisplay();
            }
        }
    }

    private void UpdateTextDisplay()
    {
        if (uiText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            uiText.text = $"{minutes:00}:{seconds:00}";
        }
    }

    public float GetTimeRemaining()
    {
        return timeRemaining;
    }

    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        return $"{minutes:00}:{seconds:00}";
    }

    public void SetUIText(TextMeshPro newText)
    {
        uiText = newText;
        UpdateTextDisplay();
    }

    public void Resume()
    {
        isRunning = true;
    }

    public void Pause()
    {
        isRunning = false;
    }

}
