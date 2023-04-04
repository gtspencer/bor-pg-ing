using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/NPC Schedule")]
public class NPCScheduleScriptableObject : ScriptableObject
{
    public string[] locations = new string[24];
}
