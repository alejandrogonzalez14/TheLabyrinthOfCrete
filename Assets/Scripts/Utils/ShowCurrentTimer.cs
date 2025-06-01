using UnityEngine;
using TMPro;

public class ShowCurrentTimer : MonoBehaviour
{
    public TextMeshPro countdownText;

    void Start()
    {
        if (countdownText != null)
        {
            string time = GameStateManager.GetFormattedCountdownTime();
            countdownText.text = time;
        }
    }
}