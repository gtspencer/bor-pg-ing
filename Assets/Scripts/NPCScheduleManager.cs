using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScheduleManager : MonoBehaviour
{
    [SerializeField] private TimeManager timeManager;

    [SerializeField] private List<NPC> npcs;

    // Start is called before the first frame update
    void Start()
    {
        timeManager.onHourChange += HourChanged;

        foreach (NPC npc in npcs)
        {
            timeManager.onHourChange += npc.OnHourChanged;
        }
    }

    private void HourChanged(int hour)
    {
        
    }

    private void OnDestroy()
    {
        timeManager.onHourChange -= HourChanged;

        foreach (NPC npc in npcs)
        {
            timeManager.onHourChange -= npc.OnHourChanged;
        }
    }
}
