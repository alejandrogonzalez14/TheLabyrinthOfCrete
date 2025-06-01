using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ExitButtonTrigger : MonoBehaviour
{
    private float timer = 0f;
    private bool isInside = false;
    public float selectionTime = 2f;

    private Button button;
    private ColorBlock defaultColors;
    private bool hasActivated = false;

    private void Start()
    {
        button = GetComponent<Button>();
        defaultColors = button.colors;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1") && !hasActivated)
        {
            isInside = true;
            var colors = button.colors;
            colors.normalColor = colors.highlightedColor;
            button.colors = colors;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player1") && !hasActivated)
        {
            isInside = false;
            timer = 0f;
            button.colors = defaultColors;
        }
    }

    private void Update()
    {
        if (isInside && !hasActivated)
        {
            timer += Time.deltaTime;
            if (timer >= selectionTime)
            {
                hasActivated = true;
                StartCoroutine(LoadMenuAfterDelay(0.5f));
            }
        }
    }

    private IEnumerator LoadMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Center");
    }
}
