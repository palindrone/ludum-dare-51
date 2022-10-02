using UnityEngine;

namespace Resources.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "Scriptable Objects/Building", order = 1)]
    public class Building : ScriptableObject
    {
        public string buildingName;
        public Sprite sprite;
        public string animationTrigger;
        public int spawnTime;
        public Item spawnItem;
        
        // cost?
        public int goldCost;
        public int sandCost;

        public string description;
        public string description2;
    }
}
