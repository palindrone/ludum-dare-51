using UnityEngine;

using ItemType = Delegates.Item.Type;

namespace Resources.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "Scriptable Objects/Item", order = 1)]
    public class Item : ScriptableObject
    {
        public string itemName;
        public ItemType type;
        public Sprite sprite;
        public int foodValue = -1;
        public int weaponValue = -1;
        public int saleValue = 0;
    }
}
