using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject targetObject;

    private Collider targetCollider;

    private void Start()
    {
        if (targetObject != null)
        {
            targetCollider = targetObject.GetComponent<Collider>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && targetObject != null)
        {
            if (targetCollider != null)
                targetCollider.enabled = false;

            // If you still want to deactivate visuals/logic:
            targetObject.SetActive(false);

            SoundManager.Instance.PlaySound("button");
            SoundManager.Instance.PlaySound("door");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !targetObject.activeSelf)
        {
            targetObject.SetActive(true);

            if (targetCollider != null)
                targetCollider.enabled = true;
        }
    }
}
