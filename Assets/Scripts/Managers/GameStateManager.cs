using UnityEngine;

public static class GameStateManager
{
    private static int rocks_collected = 0;

    public static void collectRock()
    {
        rocks_collected += 1;
        Debug.Log(rocks_collected);
    }
}
