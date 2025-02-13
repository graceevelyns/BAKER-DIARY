using UnityEngine;

public class GameClock : MonoBehaviour
{
    public int hour = 8; // Starting hour (e.g., 8:00 AM)
    public int minute = 0; // Starting minute
    public float timeSpeed = 1f; // Speed of in-game time (1 second = 1 in-game minute)

    public string CurrentTime => $"{hour:D2}:{minute:D2}"; // Formatted current time

    private void Update()
    {
        // Update time based on the timeSpeed
        minute += Mathf.FloorToInt(Time.deltaTime * timeSpeed);

        // Handle overflow of minutes
        if (minute >= 60)
        {
            minute = 0;
            hour++;
            if (hour >= 24) hour = 0; // Reset after 24 hours
        }
    }
}
