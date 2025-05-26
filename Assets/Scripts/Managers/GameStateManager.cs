using UnityEngine;
using TMPro;

public static class GameStateManager
{
    private static int rocks_collected = 0;
    private static float countdown = 600f;
    private static CountdownTimer timerInstance;

    public static void collectRock()
    {
        rocks_collected += 1;
        Debug.Log(rocks_collected);
    }

    public static void setCountdown(float seconds)
    {
        countdown = seconds;
    }

    public static void StartCountdown(TextMeshPro countdownText)
    {
        EnsureTimerInstanceExists();
        timerInstance.StartTimer(countdown, countdownText, () =>
        {
            Debug.Log("Countdown finished!");
        });
    }

    public static void StopCountdown()
    {
        timerInstance?.StopTimer();
    }

    private static void EnsureTimerInstanceExists()
    {
        if (timerInstance == null)
        {
            GameObject timerObject = new GameObject("CountdownTimer");
            Object.DontDestroyOnLoad(timerObject);
            timerInstance = timerObject.AddComponent<CountdownTimer>();
        }
    }

    public static float GetCountdownTime()
    {
        return timerInstance != null ? timerInstance.GetTimeRemaining() : 0f;
    }

    public static string GetFormattedCountdownTime()
    {
        return timerInstance != null ? timerInstance.GetFormattedTime() : "00:00";
    }

    public static void ChangeCountdownUIText(TextMeshPro newText)
    {
        if (timerInstance != null)
        {
            timerInstance.SetUIText(newText);
        }
    }

    public static void ResumeCountdown()
    {
        if (timerInstance != null)
        {
            timerInstance.Resume();
        }
    }

    public static void PauseCountdown()
    {
        if (timerInstance != null)
        {
            timerInstance.Pause();
        }
    }
}
