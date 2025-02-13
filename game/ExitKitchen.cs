using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitKitchen : MonoBehaviour
{
    public string mapSceneName = "BakeryInterior"; // Name of the map scene
    public Vector3 manualSpawnPosition = new Vector3(-22.2002f, 1.806313f, 0f); // Your specified spawn position

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the Player enters the trigger
        {
            // Set the spawn position in the GameManager
            GameManager.Instance.spawnPosition = manualSpawnPosition;

            // Load the Map scene
            SceneManager.LoadScene(mapSceneName);
        }
    }
}
