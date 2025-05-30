using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinotaurMovement : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>();
    public float attackRange = 2f;
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    public float attackCooldown = 2f;

    public BoxCollider attackTriggerCollider; // Assign in Inspector
    public float attackZoneActiveDuration = 0.5f; // Duration for collider to stay active

    private Rigidbody rb;
    private Animator animator;
    private Transform currentTarget;
    private float lastAttackTime;
    private bool isAttacking = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.freezeRotation = true;
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Start()
    {
        if (targets.Count == 0)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                targets.Add(player.transform);
            }
        }
    }

    void Update()
    {
        if (targets.Count == 0) return;

        FindClosestTarget();

        if (isAttacking && !animator.GetCurrentAnimatorStateInfo(0).IsName("Walk&Attack"))
        {
            isAttacking = false;
        }
    }

    void FixedUpdate()
    {
        if (currentTarget == null)
        {
            animator.SetBool("isWalking", false);
            rb.velocity = Vector3.zero;
            return;
        }

        Vector3 direction = currentTarget.position - transform.position;
        direction.y = 0;
        float distance = direction.magnitude;

        if (distance <= attackRange && Time.time >= lastAttackTime + attackCooldown && !isAttacking)
        {
            Attack();
            return;
        }

        if (!isAttacking)
        {
            bool shouldWalk = distance > attackRange;
            animator.SetBool("isWalking", shouldWalk);

            rb.velocity = shouldWalk ? direction.normalized * moveSpeed : Vector3.zero;
        }
    }

    void FindClosestTarget()
    {
        Transform closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform target in targets)
        {
            if (target == null) continue;

            float distance = Vector3.Distance(transform.position, target.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = target;
            }
        }

        currentTarget = closestTarget;
    }

    void Attack()
    {
        isAttacking = true;
        lastAttackTime = Time.time;

        animator.SetTrigger("attackTrigger");
        animator.SetBool("isWalking", false);

        rb.velocity = Vector3.zero;

        if (attackTriggerCollider != null)
        {
            StartCoroutine(ActivateAttackZoneTemporarily());
        }
    }

    IEnumerator ActivateAttackZoneTemporarily()
    {
        yield return new WaitForSeconds(0.5f); // Delay before activating the attack zone
        attackTriggerCollider.enabled = true;
        yield return new WaitForSeconds(attackZoneActiveDuration);
        attackTriggerCollider.enabled = false;
    }
}
