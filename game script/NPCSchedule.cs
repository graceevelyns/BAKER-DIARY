using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCSchedule
{
    public string npcName; // Name of the NPC
    public List<ScheduleEntry> scheduleEntries = new List<ScheduleEntry>(); // List of schedule entries
}

[System.Serializable]
public class ScheduleEntry
{
    public string time; // Time in "HH:mm" format
    public string sceneName; // Scene where the NPC should be
    public Vector3 position; // Position in the scene
}
