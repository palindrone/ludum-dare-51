using UnityEngine;
using UnityEngine.EventSystems;

namespace Delegates
{
    public class BuildButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        private static Sprite goldImage;
        private static Sprite sandImage;
        
        public Resources.ScriptableObjects.Building building;


        private void Awake()
        {
            if (goldImage == null)
            {
                goldImage = UnityEngine.Resources.Load<Sprite>("Images/testGold");
            }

            if (sandImage == null)
            {
                sandImage = UnityEngine.Resources.Load<Sprite>("Images/testSand");
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Sprite costSpr = null;
            int costAmount = 0;

            if (building.sandCost > 0)
            {
                costSpr = sandImage;
                costAmount = building.sandCost;
            }
            
            if (building.goldCost > 0)
            {
                costSpr = goldImage;
                costAmount = building.goldCost;
            }
            
            
            
            InstructionManager.Instance.SetData(building.buildingName, building.description, building.description2, costSpr, costAmount);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            InstructionManager.Instance.Hide();
        }
    }
}
