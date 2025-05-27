using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab1;
    public GameObject rockPrefab2;

    public Vector3 scalePrefab1 = Vector3.one;
    public Vector3 scalePrefab2 = Vector3.one;

    public float spawnInterval = 2f;

    public BoxCollider spawnArea;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRock();
            timer = 0f;
        }
    }

    void SpawnRock()
    {
        if (rockPrefab1 == null || rockPrefab2 == null || spawnArea == null)
        {
            Debug.LogWarning("Missing references in RockSpawner.");
            return;
        }

        Vector3 spawnPos = GetRandomPositionInBox(spawnArea);
        GameObject selectedPrefab = Random.value < 0.5f ? rockPrefab1 : rockPrefab2;
        Vector3 selectedScale = selectedPrefab == rockPrefab1 ? scalePrefab1 : scalePrefab2;

        GameObject rock = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        rock.transform.localScale = selectedScale;
    }

    Vector3 GetRandomPositionInBox(BoxCollider box)
    {
        Vector3 center = box.center + box.transform.position;
        Vector3 size = box.size * 0.5f;

        float x = Random.Range(center.x - size.x, center.x + size.x);
        float y = Random.Range(center.y - size.y, center.y + size.y);
        float z = Random.Range(center.z - size.z, center.z + size.z);

        return new Vector3(x, y, z);
    }
}
