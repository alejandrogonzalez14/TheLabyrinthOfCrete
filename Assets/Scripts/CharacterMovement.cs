using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform target;
    public float detectionRange = 5f;
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;

    Animator animator;
    public Transform model;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.freezeRotation = true; // Optional: prevent rotation due to physics

        animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("walking", false);
            return;
        }

        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        float distance = direction.magnitude;


        if (distance <= detectionRange && distance > 0.1f)
        {
            Vector3 moveDir = direction.normalized;
            rb.velocity = moveDir * moveSpeed;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Extract only the Y axis rotation (yaw)
            Quaternion currentRotation = model.rotation;
            Quaternion targetYRotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);

            // Smoothly rotate around Y only
            model.rotation = Quaternion.Slerp(currentRotation, targetYRotation, Time.deltaTime * rotationSpeed);

            animator.SetBool("walking", true);

            if (!SoundManager.Instance.isPlaying())
            {
                SoundManager.Instance.PlaySound("walking");
            }
        }
        else
        {
            rb.velocity = Vector3.zero; // Stop immediately when out of range
            animator.SetBool("walking", false);
        }
    }
}