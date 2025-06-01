using UnityEngine;
using System.Collections;

public class MinotaurAttack : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            GameStateManager.loseLife();

            StartCoroutine(TriggerHurtAnimationAfterDelay(other));
        }
    }

    IEnumerator TriggerHurtAnimationAfterDelay(Collider playerCollider)
    {
        yield return new WaitForSeconds(0.5f);

        Animator playerAnimator = playerCollider.GetComponent<Animator>();
        playerAnimator.SetTrigger("hurt");
    }
}
