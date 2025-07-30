using UnityEngine;

public class Egg : MonoBehaviour
{
    [Tooltip("The Egg Prefab to spawn when this one is caught.")]
    [SerializeField] private GameObject eggPrefab;

    // This function is called automatically when this object's collider enters a 'Trigger'.
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object we hit is the "Player" (the basket).
        if (other.CompareTag("Player"))
        {
            // First, check if the eggPrefab has been assigned in the Inspector.
            if (eggPrefab != null)
            {
                // --- Spawn a new egg at the top ---
                // Determine a random horizontal position between -6 and +6.
                float randomX = Random.Range(-6f, 6f);
                // Set the spawn position high above the screen.
                Vector3 spawnPosition = new Vector3(randomX, 8f, 0);

                // Instantiate a new egg prefab at the calculated position.
                Instantiate(eggPrefab, spawnPosition, Quaternion.identity);
            }

            // Finally, destroy the current egg GameObject that was caught.
            Destroy(gameObject);
        }
    }

    // This part remains to clean up eggs that are missed.
    void Update()
    {
        // If the egg has fallen below the screen...
        if (transform.position.y < -5f)
        {
            // ...destroy the egg GameObject.
            Destroy(gameObject);
        }
    }
}