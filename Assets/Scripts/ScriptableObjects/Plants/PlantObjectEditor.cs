using System;
using System.Collections;
using System.Collections.Generic;
using Resources.ScriptableAssets.Farming;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlantScriptableObject))]
public class PlantObjectEditor : Editor
{
    private PlantScriptableObject plantObject;
    
    private void OnEnable()
    {
        plantObject = target as PlantScriptableObject;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (plantObject == null)
            return;

        plantObject.harvestable = EditorGUILayout.Toggle("harvestable", plantObject.harvestable);

        if (plantObject.daysUntilBloom < plantObject.plantPhases.Length)
        {
            EditorGUILayout.HelpBox($"More phases ({plantObject.plantPhases.Length}) than days ({plantObject.daysUntilBloom}), defaulting to 1 day per phase", MessageType.Warning);
        }

        if (plantObject.inventoryIcon != null)
        {
            DrawSprite("Inventory Icon", plantObject.inventoryIcon);
        }

        if (plantObject.plantPhases.Length > 0)
        {
            for (int i = 0; i < plantObject.plantPhases.Length; i++)
            {
                var labelText = $"Phase {i} Sprite";
                if (i == 0)
                    labelText = "Seed sprite";
                if (i == plantObject.plantPhases.Length - 1)
                    labelText = "Bloom Sprite";
                
                DrawSprite(labelText, plantObject.plantPhases[i]);
            }
        }
    }

    private void DrawSprite(string label, Sprite s)
    {
        //Convert the weaponSprite (see SO script) to Texture
        Texture2D texture = AssetPreview.GetAssetPreview(s);
        //We crate empty space 80x80 (you may need to tweak it to scale better your sprite
        //This allows us to place the image JUST UNDER our default inspector
        GUILayout.Label(label, GUILayout.Height(40), GUILayout.Width(100));
        GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
        //Draws the texture where we have defined our Label (empty space)
        GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
    }
}
