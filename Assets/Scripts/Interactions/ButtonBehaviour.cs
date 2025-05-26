using UnityEngine;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject targetObject;
    public float moveDistance = 2f;
    public float moveDuration = 1f;

    private Collider targetCollider;
    private Vector3 originalPosition;
    private Vector3 loweredPosition;
    private Coroutine moveCoroutine;

    private void Start()
    {
        if (targetObject != null)
        {
            targetCollider = targetObject.GetComponent<Collider>();
            originalPosition = targetObject.transform.position;
            loweredPosition = originalPosition - Vector3.up * moveDistance;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player") && targetObject != null)
        {
            if (moveCoroutine != null) StopCoroutine(moveCoroutine);
            moveCoroutine = StartCoroutine(MoveAndDeactivate());

            SoundManager.Instance.PlaySound("button");
            SoundManager.Instance.PlaySound("door");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Contains("Player") && targetObject != null && !targetObject.activeSelf)
        {
            targetObject.SetActive(true);

            if (targetCollider != null)
                targetCollider.enabled = false;

            if (moveCoroutine != null) StopCoroutine(moveCoroutine);
            moveCoroutine = StartCoroutine(ActivateAndMove());

            SoundManager.Instance.PlaySound("door");
        }
    }

    private IEnumerator MoveAndDeactivate()
    {
        float elapsed = 0f;
        Vector3 start = originalPosition;
        Vector3 end = loweredPosition;

        while (elapsed < moveDuration)
        {
            targetObject.transform.position = Vector3.Lerp(start, end, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        targetObject.transform.position = end;

        if (targetCollider != null)
            targetCollider.enabled = false;

        targetObject.SetActive(false);
    }

    private IEnumerator ActivateAndMove()
    {
        targetObject.SetActive(true);
        float elapsed = 0f;
        Vector3 start = loweredPosition;
        Vector3 end = originalPosition;

        while (elapsed < moveDuration)
        {
            targetObject.transform.position = Vector3.Lerp(start, end, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        targetObject.transform.position = end;

        if (targetCollider != null)
            targetCollider.enabled = true;
    }
}
