using System;
using UnityEngine;

namespace Resources.ScriptableAssets.Farming
{
    [CreateAssetMenu(menuName ="ScriptableObjects/Plant")]
    public class PlantScriptableObject : ItemScriptableObject
    {
        // inventory icon is seed
        // produce will be linked
        private void Awake()
        {
            category = Category.Plant;
        }

        public bool harvestable = true;
        public ItemScriptableObject harvestedItem;
        public bool edible = true;
        public bool cookable = true;
        public bool craftable;
        public bool singleGrow;
        public bool mutatable;
        
        // first is seed, last is bloom
        public Sprite[] plantPhases;

        // currently using plant phases (1 phase per day)
        [Obsolete]
        public float daysUntilBloom;
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
