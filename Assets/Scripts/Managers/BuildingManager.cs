using Factories;
using Resources.ScriptableObjects;
using UnityEngine;

namespace Managers
{
    public class BuildingManager : MonoBehaviour
    {
        public static BuildingManager Instance { get; private set; }
        
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public void InitiateBuild(Building buildingType)
        {
            var remainingSand = Player.Instance.SpendSand(buildingType.sandCost);
            var remainingMoney = Player.Instance.SpendMoney(buildingType.goldCost);
            
            if (remainingMoney == -1 || remainingSand == -1)
            {
                // TODO Express lack of money or sand
                MainSceneManager.PlayerShake();
                return;
            }
            
            
            BuildingFactory.Instance.GenerateBuilding(buildingType, Vector3.zero);
        }
    }
}
