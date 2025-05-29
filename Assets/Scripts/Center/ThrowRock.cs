using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRock : MonoBehaviour
{
    public GameObject rockPrefab;
    public Transform rockSpawnpoint;
    public float rockSpeed = 5f;
    public Transform model;
    //public GUI rockCounter;
    public float shootInterval;
    private float shootTimer;
    
    void Update()
    {
        UpdateThrowing();
    }

    private void UpdateThrowing()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            throwRocks();
        }
    }

    private void throwRocks()
    {
        //if (rockcounter > 0)
        //{
        GameObject rock = Instantiate(rockPrefab, rockSpawnpoint.position, Quaternion.identity);
        MoveRock mover = rock.GetComponent<MoveRock>();
        if (mover != null)
        {
            Vector3 moveDir = model.forward;  // or Vector3.forward depending on your setup
            mover.moveDirection = moveDir;
            mover.speed = rockSpeed;
        }
        
        //}

    }
}
