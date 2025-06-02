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
    private float timer;
    private bool canAttack = true;

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
        if (timer <= 0f)
        {
            timer = attackCooldown;
            canAttack = true;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if (targets.Count == 0) return;

        FindClosestTarget();
    }

    void FixedUpdate()
    {

        if (GameStateManager.state != 0) return;

        if (currentTarget == null)
        {
            animator.SetBool("isWalking", false);
            rb.velocity = Vector3.zero;
            return;
        }

        Vector3 direction = currentTarget.position - transform.position;
        direction.y = 0;
        float distance = direction.magnitude;

        if (distance <= attackRange && canAttack)
        {
            Attack();
            canAttack = false;
            timer = attackCooldown;
        }
        else 
        {
            bool shouldWalk = distance > attackRange && canAttack;
            animator.SetBool("isWalking", shouldWalk);

            if (shouldWalk)
            {
                Vector3 moveDirection = direction.normalized;

                // Rotate towards the move direction smoothly
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

                // Move forward
                rb.velocity = moveDirection * moveSpeed;
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
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
        animator.SetTrigger("attackTrigger");
        animator.SetBool("isWalking", false);

        if (attackTriggerCollider != null)
        {
            StartCoroutine(ActivateAttackZoneTemporarily());
        }
    }

    IEnumerator ActivateAttackZoneTemporarily()
    {
        yield return new WaitForSeconds(0.75f); // Delay before activating the attack zone
        attackTriggerCollider.enabled = true;
        SoundManager.Instance.PlaySound("swordAttack");
        yield return new WaitForSeconds(attackZoneActiveDuration);
        attackTriggerCollider.enabled = false;
    }
}
