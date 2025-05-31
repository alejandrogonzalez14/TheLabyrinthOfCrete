using UnityEngine;

public class ZoneTriggerCenter : MonoBehaviour
{
    public enum PlayerType { Player1, Player2 }
    public PlayerType playerType;
    public LoadCenter centerLoader;

    void OnTriggerEnter(Collider other)
    {
        if (playerType == PlayerType.Player1 && other.CompareTag("Player1"))
        {
            centerLoader.SetPlayerInZone(1, true);
        }
        else if (playerType == PlayerType.Player2 && other.CompareTag("Player2"))
        {
            centerLoader.SetPlayerInZone(2, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (playerType == PlayerType.Player1 && other.CompareTag("Player1"))
        {
            centerLoader.SetPlayerInZone(1, false);
        }
        else if (playerType == PlayerType.Player2 && other.CompareTag("Player2"))
        {
            centerLoader.SetPlayerInZone(2, false);
        }
    }
}
