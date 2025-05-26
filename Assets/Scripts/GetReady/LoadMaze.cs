using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro; // 👈 Needed for TextMeshPro support


public class LoadMaze : MonoBehaviour
{
    private bool isPlayer1InZone = false;
    private bool isPlayer2InZone = false;

    private Coroutine countdownCoroutine;
    public string nextSceneName = "Maze";

    public TextMeshPro[] countdownTexts;

    public void SetPlayerInZone(int playerNumber, bool inZone)
    {
        if (playerNumber == 1)
            isPlayer1InZone = inZone;
        else if (playerNumber == 2)
            isPlayer2InZone = inZone;

        if (isPlayer1InZone && isPlayer2InZone)
        {
            if (countdownCoroutine == null)
            {
                countdownCoroutine = StartCoroutine(CountdownAndLoadScene());
            }
        }
        else
        {
            if (countdownCoroutine != null)
            {
                StopCoroutine(countdownCoroutine);
                countdownCoroutine = null;
                Debug.Log("Countdown reset. A player left the zone.");
                ResetCountdownText();
            }
        }
    }

    private IEnumerator CountdownAndLoadScene()
    {
        int counter = 3;

        while (counter > 0)
        {
            Debug.Log($"Loading in {counter}...");
            UpdateCountdownText(counter);
            yield return new WaitForSeconds(1f);

            if (!isPlayer1InZone || !isPlayer2InZone)
            {
                Debug.Log("Countdown cancelled.");
                ResetCountdownText();
                yield break;
            }

            counter--;
        }

        UpdateCountdownText(0);
        Debug.Log("Loading next scene...");
        SceneManager.LoadScene(nextSceneName);
    }

    private void UpdateCountdownText(int number)
    {
        foreach (var text in countdownTexts)
        {
            if (text != null)
                text.text = number.ToString();
        }
    }

    private void ResetCountdownText()
    {
        foreach (var text in countdownTexts)
        {
            if (text != null)
                text.text = "3";
        }
    }
}
