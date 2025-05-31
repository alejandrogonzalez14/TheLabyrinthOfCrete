using TMPro;

public static class GUIManager
{

    public static TextMeshPro livesText;
    public static TextMeshPro rocksText;
    public static TextMeshPro minotaurlivesText;

    public static void setLivesText(TextMeshPro text)
    {
        livesText = text;
        UpdateLives();
    }

    public static void setRocksText(TextMeshPro text)
    {
        rocksText = text;
        UpdateRocks();
    }
    public static void setMinotaurLivesText(TextMeshPro text)
    {
        minotaurlivesText = text;
        UpdateMinotaurLives();
    }

    public static void UpdateLives()
    {
        int lifes = GameStateManager.getLives();
        livesText.text = "x" + lifes;
    }

    public static void UpdateRocks()
    {
        int rocks = GameStateManager.getRocks();
        rocksText.text = "x" + rocks;
    }

    public static void UpdateMinotaurLives()
    {
        int min_lifes = GameStateManager.getMinotaurLives();
        minotaurlivesText.text = "x" + min_lifes;
    }
}
