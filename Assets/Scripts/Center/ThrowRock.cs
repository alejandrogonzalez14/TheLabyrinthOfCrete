using UnityEngine;
using System.Collections; // <-- Required for IEnumerator

public class ThrowRock : MonoBehaviour
{
    public GameObject rockPrefab;
    public Transform rockSpawnpoint;
    public float rockSpeed = 10f;
    public GameObject model;

    public float shootInterval;
    private float shootTimer;

    bool canThrow;

    Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        shootTimer = shootInterval;
        canThrow = true;
    }

    void Update()
    {
        if (!canThrow)
        {
            shootTimer -= Time.deltaTime;

            if (shootTimer <= 0)
            {
                shootTimer = shootInterval;
                canThrow = true;
            }
        }
    }

    public bool throwRock()
    {
        if (!canThrow || GameStateManager.getRocks() <= 0)
            return false;

        StartCoroutine(ThrowRockCoroutine());
        return true;
    }

    private IEnumerator ThrowRockCoroutine()
    {
        animator.SetTrigger("attack");
        GameStateManager.throwRock();
        canThrow = false;

        yield return new WaitForSeconds(2f); // Wait for animation or timing
        SoundManager.Instance.PlaySound("throwRock");

        GameObject rock = Instantiate(rockPrefab, rockSpawnpoint.position, Quaternion.identity);
        MoveRock mover = rock.GetComponent<MoveRock>();

        if (mover != null)
        {
            Vector3 moveDir = model.transform.forward;
            mover.moveDirection = moveDir;
            mover.speed = rockSpeed;
            mover.origin = model;
        }
    }
}
