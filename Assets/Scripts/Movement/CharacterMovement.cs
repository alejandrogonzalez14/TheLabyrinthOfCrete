using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform target;
    public float detectionRange = 5f;
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    public float animSpeed = 1.0f;

    public Transform model;
    private Rigidbody rb;

    Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.freezeRotation = true; // Optional: prevent rotation due to physics

        animator = GetComponentInChildren<Animator>();
        animator.SetFloat("animSpeed", animSpeed);
    }

    void FixedUpdate()
    {
        // Check if player dead
        if (animator.GetBool("isDead"))
        {
            rb.velocity = Vector3.zero;
            return;
        }

        // Check if player should die
        if (GameStateManager.state == -1)
        {
            animator.SetTrigger("dead");
            animator.SetBool("isDead", true);
            rb.velocity = Vector3.zero;
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

            animator.SetFloat("moveSpeed", moveSpeed);

            if (!SoundManager.Instance.isPlaying())
            {
                SoundManager.Instance.PlaySound("walking");
            }
        }
        else
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if ((horizontal * horizontal) < 1.0f && (vertical * vertical) < 1.0f)
            {
                rb.velocity = Vector3.zero; // Stop immediately when out of range
                animator.SetFloat("moveSpeed", 0.0f);
            }
        }
    }
}