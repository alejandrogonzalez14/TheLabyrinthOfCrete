using UnityEngine;

public class ThrowRock : MonoBehaviour
{
    public GameObject rockPrefab;
    public Transform rockSpawnpoint;
    public float rockSpeed = 10f;
    public GameObject model;

    //public GUI rockCounter;
    public float shootInterval;
    private float shootTimer;

    bool canThrow;

    private void Start()
    {
        shootTimer = shootInterval;
        canThrow = true;
    }

    void Update()
    {
        if (!canThrow) shootTimer -= Time.deltaTime;
        
        if (shootTimer <= 0)
        {
            shootTimer = shootInterval;
            canThrow = true;
        }
    }

    public void throwRock()
    {

        if (!canThrow || GameStateManager.getRocks() <= 0) return;

        GameObject rock = Instantiate(rockPrefab, rockSpawnpoint.position, Quaternion.identity);
        MoveRock mover = rock.GetComponent<MoveRock>();

        if (mover != null)
        {
            Vector3 moveDir = model.transform.forward;  // or Vector3.forward depending on your setup
            mover.moveDirection = moveDir;
            mover.speed = rockSpeed;
            mover.origin = model;
        }

        GameStateManager.throwRock();
        canThrow = false;
    }
}
