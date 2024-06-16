using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject objectToSpawn; // The prefab to spawn
    public Vector3 spawnAreaSize = new Vector3(10, 0, 10); // The size of the area where objects will be spawned
    public float spawnInterval = 2f; // Time in seconds between spawns
    public float fixedYValue = 1.5f; // The fixed Y position where objects will be spawned

    private void Start()
    {
        // Start the spawning process
        InvokeRepeating(nameof(SpawnObject), 0f, spawnInterval);
    }

    private void SpawnObject()
    {
        // Generate a random position within the defined area
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            fixedYValue,
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        // Adjust the spawn position to be relative to the spawner's position
        spawnPosition += transform.position;

        // Instantiate the object at the calculated position
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }

    // Optionally, visualize the spawn area in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector3(transform.position.x, fixedYValue, transform.position.z), new Vector3(spawnAreaSize.x, 0.1f, spawnAreaSize.z));
    }
}
