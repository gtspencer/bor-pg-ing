using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLocationsScriptableObject : ScriptableObject
{
    public static readonly Dictionary<string, Vector3> namesToLocations = new Dictionary<string, Vector3>
    {
        { "TopLeft", new Vector3(-3.74f, 2.71f, 0) },
        { "BottomRight", new Vector3(5.46f, -1.59f, 0) }
    };
}
