using UnityEngine;
using UnityEngine.SceneManagement;

public class GoCenter : MonoBehaviour
{
    [Tooltip("Aseg�rate de asignar los jugadores en el Inspector")]
    public GameObject Player1;
    public GameObject Player2;

    private bool player1InZone = false;
    private bool player2InZone = false;

    private void OnTriggerEnter(Collider other)
    {
        // Versi�n m�s robusta que compara por objeto o por tag
        if (other.gameObject == Player1 || other.CompareTag("Player1"))
        {
            player1InZone = true;
            Debug.Log("Player1 entr� en la zona");
        }
        else if (other.gameObject == Player2 || other.CompareTag("Player2"))
        {
            player2InZone = true;
            Debug.Log("Player2 entr� en la zona");
        }

        VerifyTransport();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player1 || other.CompareTag("Player1"))
        {
            player1InZone = false;
            Debug.Log("Player1 sali� de la zona");
        }
        else if (other.gameObject == Player2 || other.CompareTag("Player2"))
        {
            player2InZone = false;
            Debug.Log("Player2 sali� de la zona");
        }
    }

    private void VerifyTransport()
    {
        if (player1InZone && player2InZone)
        {
            Debug.Log("Ambos jugadores en zona - transportando a Center");
            SceneManager.LoadScene("Center");
        }
    }

    // M�todo para verificar en el Editor que las referencias est�n asignadas
    private void OnValidate()
    {
        if (Player1 == null)
            Debug.LogWarning("Player1 no est� asignado en el Inspector", this);
        if (Player2 == null)
            Debug.LogWarning("Player2 no est� asignado en el Inspector", this);
    }
}