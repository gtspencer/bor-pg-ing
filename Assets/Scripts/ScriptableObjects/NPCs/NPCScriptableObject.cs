using System;
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
    public NPCScheduleScriptableObject schedule;
    public Transform navTarget;

    public enum Gender
    {
        Male,
        Female,
        Nonbinary,
        PreferNotToAnswer,
        None
    }

    private void Awake()
    {
        schedule = ScriptableObject.CreateInstance<NPCScheduleScriptableObject>();
    }
}
