using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject targetObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && targetObject != null)
        {
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
        }
    }
}
