using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class MenuButtons : MonoBehaviour
{
    public static int button_pressed = 0;

    public void Easy()
    {
        MenuButtons.button_pressed = 1;
        StartCoroutine(PlayWithDelay());
    }

    public void Medium()
    {
        MenuButtons.button_pressed = 2;
        StartCoroutine(PlayWithDelay());
    }

    public void Hard()
    {
        MenuButtons.button_pressed = 3;
        StartCoroutine(PlayWithDelay());
    }

    private IEnumerator PlayWithDelay()
    {
        yield return new WaitForSeconds(0.5f);  // Wait for 0.5 seconds
        SceneManager.LoadScene("GetReady");     // Load the scene
    }
}
