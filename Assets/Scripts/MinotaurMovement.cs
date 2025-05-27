using UnityEngine;
using System.Collections.Generic;

public class MinotaurMovement : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>();
    public float attackRange = 2f;
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    public float attackCooldown = 2f;

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
        // Busca automáticamente jugadores si no hay targets asignados
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

        // Control del ataque
        if (isAttacking && !animator.GetCurrentAnimatorStateInfo(0).IsName("Walk&Attack"))
        {
            isAttacking = false;
        }
    }

    void FixedUpdate()
    {
        if (currentTarget == null)
        {
            animator.SetBool("isWalking", false); // Vuelve a Idle
            rb.velocity = Vector3.zero;
            return;
        }

        Vector3 direction = currentTarget.position - transform.position;
        direction.y = 0;
        float distance = direction.magnitude;

        // Lógica de ataque
        if (distance <= attackRange && Time.time >= lastAttackTime + attackCooldown && !isAttacking)
        {
            Attack();
            return;
        }

        // Lógica de movimiento
        if (!isAttacking)
        {
            bool shouldWalk = distance > attackRange;
            animator.SetBool("isWalking", shouldWalk); // Controla Idle/Walk

            if (shouldWalk)
            {
                rb.velocity = direction.normalized * moveSpeed;
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

    void MoveTowardsTarget(Vector3 direction, float distance)
    {
        if (distance > 0.1f)
        {
            Vector3 moveDir = direction.normalized;
            rb.velocity = moveDir * moveSpeed;

            // Rotación
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
                rotationSpeed * Time.fixedDeltaTime);

            // Animación de caminar
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
            rb.velocity = Vector3.zero;
        }
    }

    void Attack()
    {
        isAttacking = true;
        lastAttackTime = Time.time;

        animator.SetTrigger("attackTrigger");
        animator.SetBool("isWalking", false); // Asegura que vuelva a Idle después del ataque

        rb.velocity = Vector3.zero; // Detiene el movimiento durante el ataque
    }
}