using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMaze : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadMazeAfterDelay());
    }

    System.Collections.IEnumerator LoadMazeAfterDelay()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("Maze");
    }
}