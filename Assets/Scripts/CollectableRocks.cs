using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableRocks : MonoBehaviour
{
    // Start is called before the first frame update
    public int collectedRocks = 0;
    private void OnTriggerEnter(Collider other)
    {
        collectedRocks++;
        Destroy(other.gameObject);
        Debug.Log(gameObject.name + "collected a rock. Total: " +  collectedRocks);
    }
}
