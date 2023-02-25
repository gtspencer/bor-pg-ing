using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/Tool")]
public class ToolScriptableObject : ItemScriptableObject
{
    private void Awake()
    {
        category = Category.Tool;
    }
}
