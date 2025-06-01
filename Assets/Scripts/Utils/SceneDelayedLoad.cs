using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneDelayedLoad : MonoBehaviour
{

    public float delay = 5f;

    void Update()
    {
        if (GameStateManager.state != 0)
        {
            StartCoroutine(WaitBeforeSceneLoad(delay));
        }
    }

    private IEnumerator WaitBeforeSceneLoad(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("WinLose");
    }
}
