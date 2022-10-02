using Delegates;
using Managers;
using UnityEngine;

namespace Helpers
{
    public abstract class SimpleTrigger : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D col)
        {
            if (!MainSceneManager.IsGameActive)
                return;
            
            var item = col.GetComponent<Item>();
            if (item == null)
                return;
        
            if (item.IsDragging())
            {
                return;
            }

            ProcessTrigger(item);
        }

        protected abstract void ProcessTrigger(Item item);
    }
}
