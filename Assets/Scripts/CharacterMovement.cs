using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform target;
    public float detectionRange = 5f;
    public float moveSpeed = 5f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.freezeRotation = true; // Optional: prevent rotation due to physics
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;

        if (distance <= detectionRange)
        {
            Vector3 moveDir = direction.normalized;
            rb.velocity = moveDir * moveSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero; // Stop immediately when out of range
        }
    }
}