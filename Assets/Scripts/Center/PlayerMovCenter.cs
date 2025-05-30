using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovCenter : MonoBehaviour
{
    private Vector3 lastPosition;

    public float threshold = 3f;
    public ThrowRock throwRockScript;


    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        //throwRockScript = GetComponent<ThrowRock>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectThrow();
        lastPosition = transform.position;
    }

    private void DetectThrow()
    {
        Vector3 velocity = (transform.position - lastPosition) / Time.deltaTime;

        if (velocity.magnitude >= threshold)
        {
            Debug.Log("TIRO PIEDRA");

            if (throwRockScript != null)
            {
                throwRockScript.throwRocks(); 
            }
        }
    }
}
