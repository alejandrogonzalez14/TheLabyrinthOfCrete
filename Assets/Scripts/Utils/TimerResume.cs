using UnityEngine;
using TMPro;

public class TimerResume : MonoBehaviour
{
    public TextMeshPro countdownText;

    void Start()
    {
        if (countdownText != null)
        {
            GameStateManager.ChangeCountdownUIText(countdownText);
            GameStateManager.ResumeCountdown();
        }
        else
        {
            Debug.LogWarning("TimerResume: No TextMeshPro reference assigned.");
        }
    }
}