using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private Transform navTarget;

    [SerializeField] public NPCScriptableObject npcData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHourChanged(int hour)
    {
        Debug.LogError("Hour changed " + hour);
        if (!string.IsNullOrEmpty(npcData.schedule.locations[hour - 1]))
        {
            SetNewTarget(NPCLocationsScriptableObject.namesToLocations[npcData.schedule.locations[hour - 1]]);
        }
    }

    public void SetNewTarget(Vector3 target)
    {
        navTarget.position = target;
    }
}
