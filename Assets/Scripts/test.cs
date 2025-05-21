using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    public Light l1;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        l1.enabled = false;
    }
}
