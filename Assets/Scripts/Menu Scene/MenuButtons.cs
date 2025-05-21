using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public static int button_pressed = 0;

    public void Easy()
    {
        MenuButtons.button_pressed = 1;
        SceneManager.LoadScene("Maze");
    }

    public void Medium()
    {
        MenuButtons.button_pressed = 2;
        SceneManager.LoadScene("Maze");
    }

    public void Hard()
    {
        MenuButtons.button_pressed = 3;
        SceneManager.LoadScene("Maze");
    }
}
