using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    public enum PlayerType { Player1, Player2 }
    public PlayerType playerType;
    public LoadNextScene sceneLoader;

    void OnTriggerEnter(Collider other)
    {
        if (playerType == PlayerType.Player1 && other.CompareTag("Player1"))
        {
            sceneLoader.SetPlayerInZone(1, true);
        }
        else if (playerType == PlayerType.Player2 && other.CompareTag("Player2"))
        {
            sceneLoader.SetPlayerInZone(2, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (playerType == PlayerType.Player1 && other.CompareTag("Player1"))
        {
            sceneLoader.SetPlayerInZone(1, false);
        }
        else if (playerType == PlayerType.Player2 && other.CompareTag("Player2"))
        {
            sceneLoader.SetPlayerInZone(2, false);
        }
    }
}
