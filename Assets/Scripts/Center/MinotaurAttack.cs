using UnityEngine;

public class MinotaurAttack : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            GameStateManager.loseLife();
        }
    }
}
