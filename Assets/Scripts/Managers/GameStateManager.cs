using UnityEngine;
using TMPro;

public static class GameStateManager
{
    private static int rocks_collected = 0;
    private static int totalRocks = 0;
    private static int thrownRocks = 0;
    private static int lives = 3;
    private static int minotaur_lives = 5;
    private static int minotaur_hits = 0;
    private static float countdown = 600f;
    private static CountdownTimer timerInstance;
    public static int state = 0;                  // 0 is for unfinished, -2 for time up, -1 for lost, 1 for won, 

    public static void collectRock()
    {
        rocks_collected += 1;
        totalRocks += 1;
        if (GUIManager.rocksText != null) GUIManager.UpdateRocks();
    }

    public static void throwRock()
    {
        rocks_collected -= 1;
        thrownRocks += 1;
        if (GUIManager.rocksText != null) GUIManager.UpdateRocks();
    }

    public static void loseLife()
    {
        lives -= 1;
        if (GUIManager.livesText != null) GUIManager.UpdateLives();

        // check if game over
        if (lives == 0)
        {
            state = -1;
        }
    }

    public static void hurtMinotaur()
    {
        minotaur_lives -= 1;
        minotaur_hits += 1;
        if (GUIManager.minotaurlivesText != null) GUIManager.UpdateMinotaurLives();

        // check if game over
        if (minotaur_lives == 0)
        {
            state = 1;
        }
    }

    public static void setCountdown(float seconds)
    {
        countdown = seconds;
    }

    public static void setLives(int _lives)
    {
        lives = _lives;
    }

    public static void setMinotaurLives(int _lives)
    {
        minotaur_lives = _lives;
    }

    public static float getCountdown()
    {
        return countdown;
    }

    public static int getLives()
    {
        return lives;
    }

    public static int getRocks()
    {
        return rocks_collected;
    }

    public static int getTotalRocks()
    {
        return totalRocks;
    }
    public static int getThrownRocks()
    {
        return thrownRocks;
    }

    public static int getMinotaurLives()
    {
        return minotaur_lives;
    }

    public static int getMinotaurHits()
    {
        return minotaur_hits;
    }

    public static void StartCountdown(TextMeshPro countdownText)
    {
        EnsureTimerInstanceExists();
        timerInstance.StartTimer(countdown, countdownText, () =>
        {
            state = -2;
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

    public static void Reset()
    {
        // Reset gameplay state
        rocks_collected = 0;
        totalRocks = 0;
        thrownRocks = 0;
        lives = 3;
        minotaur_lives = 5;
        minotaur_hits = 0;
        countdown = 600f; // Reset to initial 10 minutes or default value
        state = 0;

        // Reset or stop the countdown timer
        if (timerInstance != null)
        {
            timerInstance.StopTimer();
            GameObject.Destroy(timerInstance.gameObject);
            timerInstance = null;
        }
    }
}