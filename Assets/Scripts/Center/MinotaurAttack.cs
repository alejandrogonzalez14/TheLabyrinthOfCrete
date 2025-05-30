using UnityEngine;

public class MinotaurAttack : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Minotaur attack triggered collision with: {other.name}");

        if (other.tag.Contains("Player"))
        {
            GameStateManager.loseLife();
        }
    }
}
