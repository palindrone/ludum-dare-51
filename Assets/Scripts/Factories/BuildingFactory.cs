using System;
using Delegates;
using UnityEngine;

using BuildingScript = Resources.ScriptableObjects.Building;

namespace Factories
{
    public class BuildingFactory : MonoBehaviour
    {
        private const string BuildingPrefab = "Prefabs/ProductionBuilding";
        public BuildingPlatform mineParent;
        public BuildingPlatform farmParent;
        public BuildingPlatform sandParent;
        public BuildingPlatform pacifierParent;

        private static BuildingFactory _instance;
        public static BuildingFactory Instance => _instance;
        
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }

            _instance = this;
        }

        public Building GenerateBuilding(BuildingScript buildingScript, Vector3 position)
        {
            var buildingParent = GetParent(buildingScript.spawnItem.type);
            var nextPosition = buildingParent.NextPosition();
            
            if (nextPosition == null)
            {
                return null;
            }
            
            var buildingObject = Instantiate(
                UnityEngine.Resources.Load<GameObject>(BuildingPrefab),
                buildingParent.transform
            );

            buildingObject.transform.localPosition = nextPosition.Value;
            
            var buildingComponent = buildingObject.GetComponent<Building>();
            buildingComponent.SetScript(buildingScript);
            buildingObject.SetActive(true);
            return buildingComponent;
        }

        private BuildingPlatform GetParent(Item.Type type)
        {
            switch (type)
            {
                case Item.Type.Food:
                    return farmParent;
                case Item.Type.Gold:
                    return mineParent;
                case Item.Type.Sand:
                    return sandParent;
                case Item.Type.Pacifier:
                    return pacifierParent;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}