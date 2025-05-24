using UnityEngine;

public class RockBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            // Play picked up rock sound
            SoundManager.Instance.PlaySound("rock");

            // Increment global rock counter
            GameStateManager.collectRock();
            
            // Destroy itself
            Destroy(gameObject);
        }
    }
}
