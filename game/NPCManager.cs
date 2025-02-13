using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCManager : MonoBehaviour
{
    public List<NPCSchedule> npcSchedules = new List<NPCSchedule>(); // List of all NPC schedules
    public float updateInterval = 1f; // Interval to check schedules (in seconds)
    public string currentTime = "08:00"; // Current in-game time (placeholder)
    public List<GameObject> activeNPCs = new List<GameObject>(); // Tracks active NPCs in the current scene

    private void Start()
    {
        InvokeRepeating(nameof(UpdateNPCPositions), 0f, updateInterval);
    }

    private void OnDisable()
    {
        // Save NPC states when the scene unloads
        NPCSaveLoad saveLoad = Object.FindFirstObjectByType<NPCSaveLoad>();
        if (saveLoad != null)
        {
            saveLoad.SaveAllNPCStates(npcSchedules);
        }
    }

    private void OnEnable()
    {
        // Load NPCs when the scene loads
        NPCSaveLoad saveLoad = Object.FindFirstObjectByType<NPCSaveLoad>();
        if (saveLoad != null)
        {
            saveLoad.LoadNPCsInScene(SceneManager.GetActiveScene().name, npcSchedules);
        }
    }

    private void UpdateNPCPositions()
    {
        GameClock gameClock = FindObjectOfType<GameClock>();
        if (gameClock == null) return;

        string currentScene = SceneManager.GetActiveScene().name;
        string currentTime = gameClock.CurrentTime; // Get the current game time

        foreach (NPCSchedule npcSchedule in npcSchedules)
        {
            foreach (ScheduleEntry entry in npcSchedule.scheduleEntries)
            {
                if (entry.time == currentTime && entry.sceneName == currentScene)
                {
                    GameObject npc = activeNPCs.Find(n => n.name == npcSchedule.npcName);

                    if (npc == null)
                    {
                        GameObject npcPrefab = Resources.Load<GameObject>("NPCs/" + npcSchedule.npcName);
                        if (npcPrefab != null)
                        {
                            npc = Instantiate(npcPrefab, entry.position, Quaternion.identity);
                            npc.name = npcSchedule.npcName;
                            activeNPCs.Add(npc);
                        }
                    }
                    else
                    {
                        npc.transform.position = entry.position;
                    }
                }
            }
        }
    }

}
