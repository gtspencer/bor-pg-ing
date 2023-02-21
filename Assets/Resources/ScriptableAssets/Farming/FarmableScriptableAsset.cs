using System;
using UnityEngine;

namespace Resources.ScriptableAssets.Farming
{
    [CreateAssetMenu(menuName ="ScriptableObjects/Farming")]
    public class FarmableScriptableAsset : ScriptableObject
    {
        [SerializeField] public string plantName;
        [SerializeField] public string description;
        [SerializeField] public bool harvestable = true;
        [SerializeField] public bool edible = true;
        [SerializeField] public bool cookable = true;
        [SerializeField] public bool craftable;
        [SerializeField] public bool singleUse;
        [SerializeField] public bool mutatable;
        
        // first is seed, last is bloom
        [SerializeField] public Sprite[] plantPhases;
        [SerializeField] public Sprite seedIcon;
        [SerializeField] public Sprite inventoryIcon;

        // currently using plant phases (1 phase per day)
        [Obsolete]
        [SerializeField] public float daysUntilBloom;
        [Obsolete]
        public int daysPerPhase => (int)daysUntilBloom / plantPhases.Length;

        public LightRequirements lightRequirement = LightRequirements.Any;
        public enum LightRequirements
        {
            LowLight,
            HighLight,
            Any
        }

        public WaterRequirements waterRequirement = WaterRequirements.Any;
        public enum WaterRequirements
        {
            Low,
            High,
            Any
        }
    }
}
