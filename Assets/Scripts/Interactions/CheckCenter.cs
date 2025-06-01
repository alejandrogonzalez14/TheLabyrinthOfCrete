using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCenter : MonoBehaviour
{
    private bool player1InZone = false;
    private bool player2InZone = false;


    // function to avoid the maze and move to minotaur boss fight (used for debug and for the demo)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("ReadyCenter");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // Versión más robusta que compara por objeto o por tag
        if (other.CompareTag("Player1"))
        {
            player1InZone = true;
        }
        
        if (other.CompareTag("Player2"))
        {
            player2InZone = true;
        }

        VerifyTransport();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            player1InZone = false;
        }
        
        if (other.CompareTag("Player2"))
        {
            player2InZone = false;
        }
    }

    private void VerifyTransport()
    {
        if (player1InZone && player2InZone)
        {
            SceneManager.LoadScene("ReadyCenter");
        }
    }
}