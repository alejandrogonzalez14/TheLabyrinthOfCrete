using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectThrow : MonoBehaviour
{
    private Vector3 lastPosition;

    public float threshold = 3f;
    public ThrowRock throwRockScript;


    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckThrow();
        lastPosition = transform.position;
    }

    private void CheckThrow()
    {
        Vector3 velocity = (transform.position - lastPosition) / Time.deltaTime;

        if (velocity.magnitude >= threshold || Input.GetKeyDown(KeyCode.Space))
        {

            if (throwRockScript != null)
            {
                throwRockScript.throwRock();
            }
        }
    }
}
