using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovCenter : MonoBehaviour
{
    public Quaternion q;
    public bool manual;

    private Vector3 lastPosition;

    public float threshold = 3f;
    private ThrowRock throwRockScript;


    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        throwRockScript = GetComponent<ThrowRock>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectThrow();
        lastPosition = transform.position;
    }

    // Setter for position
    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    // Getter for position
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    // Setter for rotation
    public void SetRotation(Quaternion rot)
    {
        transform.rotation = rot;
    }

    // Getter for rotation
    public Quaternion GetRotation()
    {
        return transform.rotation;
    }

    private void DetectThrow()
    {
        Vector3 velocity = (transform.position - lastPosition) / Time.deltaTime;

        if (Mathf.Abs(velocity.x) >= threshold)
        {
            if (throwRockScript != null)
            {
                throwRockScript.throwRocks(); 
            }
        }
    }
}
