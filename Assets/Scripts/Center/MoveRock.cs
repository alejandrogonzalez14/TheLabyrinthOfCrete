using UnityEngine;

public class MoveRock : MonoBehaviour
{
    public Vector3 moveDirection;
    public float speed = 5f;

    // Reference to the specific GameObject with a CapsuleCollider
    public GameObject origin;

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * moveDirection;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Minotaur")) GameStateManager.hurtMinotaur();

        // Only destroy this GameObject if the other is NOT the capsuleObject
        if (other.gameObject != origin)
        {
            Destroy(gameObject);
        }
    }
}
