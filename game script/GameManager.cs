using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject playerPrefab; // Prefab of the player character
    public Vector3 spawnPosition = Vector3.zero; // Default spawn position for the player

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevent GameManager from being destroyed between scenes
        }
        else
        {
            Destroy(gameObject); // Ensure only one GameManager exists
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"Scene Loaded: {scene.name}");

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            // If no player exists, instantiate a new one
            Debug.Log("Instantiating player...");
            Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            // Move the existing player to the spawn position
            Debug.Log($"Moving player to spawn position: {spawnPosition}");
            player.transform.position = spawnPosition;
        }
    }
}
