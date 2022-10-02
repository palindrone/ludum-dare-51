using Delegates;
using UnityEngine;

using ItemScript =  Resources.ScriptableObjects.Item;
using Random = UnityEngine.Random;

namespace Factories
{
    public class ItemFactory : MonoBehaviour
    {
        private const string ItemPrefab = "Prefabs/Item";
        public Transform spawnParent;
        
        public float spawnSpeed = 5.0f;
        
        private static ItemFactory _instance;
        public static ItemFactory Instance => _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }

            _instance = this;
        }
        
        public Item GenerateItem(ItemScript itemScript, Vector3 position)
        {
            var itemObject = Instantiate(
                UnityEngine.Resources.Load<GameObject>(ItemPrefab),
                spawnParent.transform
            );
            
            itemObject.transform.localPosition = position;
            
            var itemComponent = itemObject.GetComponent<Item>();
            itemComponent.SetScript(itemScript);
            itemObject.SetActive(true);
            
            var rand = Random.insideUnitCircle.normalized;
            itemComponent.SetForce(rand * spawnSpeed);
            
            return itemComponent;
        }
    }
}