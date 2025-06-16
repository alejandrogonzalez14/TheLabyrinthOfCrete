using UnityEngine;
using System.Collections;

public class MinotaurAttack : MonoBehaviour
{
    public Light redLight;
    
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
        SoundManager.Instance.PlaySound("characterHurt");
        redLight.enabled = true;
        yield return new WaitForSeconds(0.3f);;
        redLight.enabled = false;
    }
}
