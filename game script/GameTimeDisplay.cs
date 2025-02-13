using UnityEngine;
using UnityEngine.UI;

public class GameTimeDisplay : MonoBehaviour
{
    public Text timeText; // Reference to the Text UI element
    private GameClock gameClock; // Reference to the GameClock

    private void Start()
    {
        // Find the GameClock in the scene
        gameClock = FindObjectOfType<GameClock>();
    }

    private void Update()
    {
        if (gameClock != null)
        {
            // Update the Text element with the current time
            timeText.text = "Time: " + gameClock.CurrentTime;
        }
    }
}
