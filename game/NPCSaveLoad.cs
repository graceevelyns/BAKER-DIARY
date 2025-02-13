using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class NPCSaveLoad : MonoBehaviour
{
    private string savePath;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/npc_states.json";
    }

    public void SaveAllNPCStates(List<NPCSchedule> npcSchedules)
    {
        List<NPCData> npcDataList = new List<NPCData>();
        NPCManager npcManager = Object.FindFirstObjectByType<NPCManager>();

        foreach (GameObject npc in npcManager.activeNPCs)
        {
            NPCData npcData = new NPCData
            {
                npcName = npc.name,
                currentScene = SceneManager.GetActiveScene().name,
                currentPosition = npc.transform.position
            };
            npcDataList.Add(npcData);
        }

        string jsonData = JsonUtility.ToJson(new NPCDataWrapper { npcDataList = npcDataList }, true);
        File.WriteAllText(savePath, jsonData);
        Debug.Log("NPC states saved to: " + savePath);
    }

    public void LoadNPCsInScene(string currentScene, List<NPCSchedule> npcSchedules)
    {
        if (!File.Exists(savePath)) return;

        string jsonData = File.ReadAllText(savePath);
        List<NPCData> npcDataList = JsonUtility.FromJson<NPCDataWrapper>(jsonData).npcDataList;
        NPCManager npcManager = Object.FindFirstObjectByType<NPCManager>();

        foreach (NPCData npcData in npcDataList)
        {
            if (npcData.currentScene == currentScene)
            {
                GameObject npc = npcManager.activeNPCs.Find(n => n.name == npcData.npcName);
                if (npc == null)
                {
                    GameObject npcPrefab = Resources.Load<GameObject>("NPCs/" + npcData.npcName);
                    if (npcPrefab != null)
                    {
                        npc = Instantiate(npcPrefab, npcData.currentPosition, Quaternion.identity);
                        npc.name = npcData.npcName;
                        npcManager.activeNPCs.Add(npc);
                    }
                }
                else
                {
                    npc.transform.position = npcData.currentPosition;
                }
            }
        }
    }
}

[System.Serializable]
public class NPCData
{
    public string npcName;
    public string currentScene;
    public Vector3 currentPosition;
}

[System.Serializable]
public class NPCDataWrapper
{
    public List<NPCData> npcDataList;
}
