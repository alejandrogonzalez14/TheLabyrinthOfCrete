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
}
