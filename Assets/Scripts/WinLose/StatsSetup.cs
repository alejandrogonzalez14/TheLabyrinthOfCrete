using UnityEngine;
using TMPro;

public class StatsSetup : MonoBehaviour
{
    public TextMeshProUGUI winLoseText;

    public TextMeshProUGUI difficulty;
    public TextMeshProUGUI time;
    public TextMeshProUGUI collectedRocks;
    public TextMeshProUGUI thrownRocks;
    public TextMeshProUGUI minotaurHits;


    // Start is called before the first frame update
    void Start()
    {
        // Set win/lose text and color
        switch (GameStateManager.state)
        {
            case -2:
                winLoseText.text = "TIME'S UP";
                winLoseText.color = Color.gray;
                break;
            case -1:
                winLoseText.text = "GAME OVER";
                winLoseText.color = Color.red;
                break;
            case 1:
                winLoseText.text = "YOU DEFEATED THE MINOTAUR";
                winLoseText.color = Color.green;
                MusicManager.Instance.PlayMusic("victory");
                break;
            default:
                winLoseText.text = "RESULT UNKNOWN";
                winLoseText.color = Color.white;
                break;
        }


        // Set difficulty text and color
        switch (MenuButtons.button_pressed)
        {
            case 1:
                difficulty.text = "EASY";
                difficulty.color = Color.green;
                break;
            case 2:
                difficulty.text = "MEDIUM";
                difficulty.color = new Color(1f, 0.64f, 0f); // Orange
                break;
            case 3:
                difficulty.text = "HARD";
                difficulty.color = Color.red;
                break;
            default:
                difficulty.text = "UNKNOWN";
                difficulty.color = Color.gray;
                break;
        }


        time.text = GameStateManager.GetFormattedCountdownTime();
        collectedRocks.text = GameStateManager.getTotalRocks().ToString();
        thrownRocks.text = GameStateManager.getThrownRocks().ToString();
        minotaurHits.text = GameStateManager.getMinotaurHits().ToString();

    }
}
