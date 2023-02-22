using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/NPC")]
public class NPCScriptableObject : ScriptableObject
{
    public string name;
    public string description;
    public Gender gender;
    public Sprite mugShot;
    public int friendLevel;

    public enum Gender
    {
        Male,
        Female,
        Nonbinary,
        PreferNotToAnswer,
        None
    }
}
