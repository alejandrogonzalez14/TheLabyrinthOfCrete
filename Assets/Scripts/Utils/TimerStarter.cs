using UnityEngine;
using TMPro;

public class TimerStarter : MonoBehaviour
{
    public TextMeshPro timerText;

    void Start()
    {
        GameStateManager.StartCountdown(timerText);
    }

    void Update()
    {
        // Example: Stop timer when pressing the "S" key
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameStateManager.StopCountdown();
        }
    }
}
