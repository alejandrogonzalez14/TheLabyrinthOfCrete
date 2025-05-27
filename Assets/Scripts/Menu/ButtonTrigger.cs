using UnityEngine;
using UnityEngine.UI;

public class ButtonTrigger : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard }
    public Difficulty difficulty;

    private float timer = 0f;
    private bool isInside = false;
    public float selectionTime = 2f;

    private Button button;
    private ColorBlock defaultColors;

    private MenuButtons menuButtons;

    private void Start()
    {
        menuButtons = FindObjectOfType<MenuButtons>();
        
        button = GetComponent<Button>();
        defaultColors = button.colors;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player1"))
        {
            isInside = true;

            var colors = button.colors;
            colors.normalColor = colors.highlightedColor;
            button.colors = colors;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            isInside = false;
            timer = 0f;

            button.colors = defaultColors;
        }
    }

    private void Update()
    {
        if (isInside)
        {
            timer += Time.deltaTime;
            if (timer >= selectionTime)
            {
                switch (difficulty)
                {
                    case Difficulty.Easy:
                        menuButtons.Easy();
                        break;
                    case Difficulty.Medium:
                        menuButtons.Medium();
                        break;
                    case Difficulty.Hard:
                        menuButtons.Hard();
                        break;
                }
                isInside = false; // prevent re-triggering
            }
        }
    }
}