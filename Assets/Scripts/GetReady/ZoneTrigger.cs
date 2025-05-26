using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    public enum PlayerType { Player1, Player2 }
    public PlayerType playerType;
    public LoadMaze mazeLoader;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered with tag:" + other.tag);


        if (playerType == PlayerType.Player1 && other.CompareTag("Player1"))
        {
            mazeLoader.SetPlayerInZone(1, true);
        }
        else if (playerType == PlayerType.Player2 && other.CompareTag("Player2"))
        {
            mazeLoader.SetPlayerInZone(2, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited with tag:" + other.tag);

        if (playerType == PlayerType.Player1 && other.CompareTag("Player1"))
        {
            mazeLoader.SetPlayerInZone(1, false);
        }
        else if (playerType == PlayerType.Player2 && other.CompareTag("Player2"))
        {
            mazeLoader.SetPlayerInZone(2, false);
        }
    }
}
