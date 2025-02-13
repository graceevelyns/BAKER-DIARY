using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterKitchen : MonoBehaviour
{
    public string bakerySceneName = "BakeryKitchen"; // Name of the BakeryInterior scene
    public Vector3 spawnPositionInBakeryKitchen; // Where the player should spawn in the bakery
    public Vector3 returnPositionOnMap; // Where the player should spawn when exiting the bakery

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player enters the trigger
        {
            // Update the spawn position in the GameManager
            GameManager.Instance.spawnPosition = spawnPositionInBakeryKitchen;

            // Store the return position for when exiting the bakery
            PlayerPrefs.SetFloat("ReturnX", returnPositionOnMap.x);
            PlayerPrefs.SetFloat("ReturnY", returnPositionOnMap.y);
            PlayerPrefs.SetFloat("ReturnZ", returnPositionOnMap.z);

            // Load the BakeryInterior scene
            SceneManager.LoadScene(bakerySceneName);
        }
    }
}
