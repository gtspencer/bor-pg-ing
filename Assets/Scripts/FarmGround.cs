using System;
using System.Collections;
using System.Collections.Generic;
using Resources.ScriptableAssets.Farming;
using UnityEngine;

public class FarmGround : MonoBehaviour, IInteractable
{
    private FarmableScriptableAsset currentPlant;
    public SpriteRenderer renderer;

    private int currentDayOfPlant;
    private Dictionary<int, bool> wateredSchedule;

    private void Awake()
    {
        // renderer = GetComponentInChildren<SpriteRenderer>();
        wateredSchedule = new Dictionary<int, bool>();
    }
    
    public void Interact()
    {
        var tomato = UnityEngine.Resources.Load<FarmableScriptableAsset>("ScriptableAssets/Farming/Tomato");
        Plant(tomato);
    }

    // TESTING ONLY
    public bool incrementDay = false;
    public bool waterPlant = false;
    // Update is called once per frame
    void Update()
    {
        if (incrementDay)
        {
            incrementDay = false;
            NewDay();
        }

        if (waterPlant)
        {
            waterPlant = false;
            WaterPlant();
        }
    }

    public void Plant(FarmableScriptableAsset newPlant)
    {
        if (currentPlant != null)
            return;

        currentPlant = newPlant;
        currentDayOfPlant = 0;

        renderer.sprite = currentPlant.plantPhases[currentDayOfPlant];
        wateredSchedule[0] = false;
    }

    public void WaterPlant()
    {
        wateredSchedule[currentDayOfPlant] = true;
    }

    public void PickPlant()
    {
        if (currentDayOfPlant < currentPlant.plantPhases.Length)
        {
            return;
        }

        renderer.sprite = null;
    }

    public void KillPlant()
    {
        renderer.sprite = null;
        Debug.Log("Plant is dead :(");
    }

    public void NewDay()
    {
        currentDayOfPlant++;
        wateredSchedule[currentDayOfPlant] = false;
        
        if (currentDayOfPlant < currentPlant.plantPhases.Length)
            renderer.sprite = currentPlant.plantPhases[currentDayOfPlant];

        switch (currentPlant.waterRequirement)
        {
            // too much watering will kill it
            // must water every other day
            case FarmableScriptableAsset.WaterRequirements.Low:
                bool previousDay = wateredSchedule[0];

                if (!previousDay)
                {
                    KillPlant();
                    return;
                }

                for (int i = 1; i < wateredSchedule.Count; i++)
                {
                    // ensure they are exactly alternating
                    if (wateredSchedule[i] == previousDay)
                    {
                        KillPlant();
                        return;
                    }
                    previousDay = wateredSchedule[i];
                }
                break;
            // to little watering will kill it
            // must water every day
            case FarmableScriptableAsset.WaterRequirements.High:
                // if not watered previous day, kill it
                if (!wateredSchedule[currentDayOfPlant - 1])
                {
                    KillPlant();
                    return;
                }
                break;
            case FarmableScriptableAsset.WaterRequirements.Any:
                break;
        }
    }
    
    
}
