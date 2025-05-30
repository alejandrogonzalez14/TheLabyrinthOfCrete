using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class MenuButtons : MonoBehaviour
{
    public static int button_pressed = 0;

    public void Easy()
    {
        MenuButtons.button_pressed = 1;

        // Set game features
        GameStateManager.setCountdown(1200f);
        GameStateManager.setLives(7);
        GameStateManager.setMinotaurLives(3);

        StartCoroutine(PlayWithDelay());
    }

    public void Medium()
    {
        MenuButtons.button_pressed = 2;

        // Set game features
        GameStateManager.setCountdown(900f);
        GameStateManager.setLives(5);
        GameStateManager.setMinotaurLives(5);

        StartCoroutine(PlayWithDelay());
    }

    public void Hard()
    {
        MenuButtons.button_pressed = 3;

        // Set game features
        GameStateManager.setCountdown(600f);
        GameStateManager.setLives(3);
        GameStateManager.setMinotaurLives(7);

        StartCoroutine(PlayWithDelay());
    }

    private IEnumerator PlayWithDelay()
    {
        yield return new WaitForSeconds(0.5f);  // Wait for 0.5 seconds
        SceneManager.LoadScene("GetReady");     // Load the scene
    }
}
