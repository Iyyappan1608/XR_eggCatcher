using System.Collections;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [Tooltip("The Egg Prefab to be spawned.")]
    [SerializeField] private GameObject eggPrefab;

    void Start()
    {
        // Start the coroutine that will handle the delayed spawn.
        StartCoroutine(SpawnOneEggAfterDelay());
    }

    private IEnumerator SpawnOneEggAfterDelay()
    {
        // Wait for 2 seconds before continuing.
        yield return new WaitForSeconds(2f);

        // Determine a random horizontal position between -6 and +6.
        float randomX = Random.Range(-6f, 6f);

        // Set the spawn position. Y=8 is high above the screen so it can fall.
        Vector3 spawnPosition = new Vector3(randomX, 8f, 0f);

        // Create a single instance of the egg prefab.
        Instantiate(eggPrefab, spawnPosition, Quaternion.identity);
        
        // The coroutine ends here and no more eggs will be spawned.
    }
}