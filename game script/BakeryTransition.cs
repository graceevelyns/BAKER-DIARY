using UnityEngine;

public class BakeryTransition : MonoBehaviour
{
    public GameObject store; // Assign the Store parent GameObject
    public GameObject kitchen; // Assign the Kitchen parent GameObject
    public Transform player; // Assign the player's Transform
    public Vector3 kitchenSpawnPosition; // Spawn position in the kitchen
    public Vector3 storeSpawnPosition; // Spawn position in the store

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player enters the trigger
        {
            if (gameObject.name == "ToKitchen") // If the player is entering the kitchen
            {
                store.SetActive(false); // Disable the Store area
                kitchen.SetActive(true); // Enable the Kitchen area
                player.position = kitchenSpawnPosition; // Move the player into the kitchen
            }
            else if (gameObject.name == "ToStore") // If the player is entering the store
            {
                kitchen.SetActive(false); // Disable the Kitchen area
                store.SetActive(true); // Enable the Store area
                player.position = storeSpawnPosition; // Move the player into the store
            }
        }
    }
}