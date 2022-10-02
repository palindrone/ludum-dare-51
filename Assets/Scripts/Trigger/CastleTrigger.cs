using Delegates;
using Helpers;
using Managers;

namespace Trigger
{
    public class CastleTrigger : SimpleTrigger
    {
        protected override void ProcessTrigger(Item item)
        {
            if (item.GetItemType() == Item.Type.Pacifier)
            {
                return;
            }

            if (item.GetItemType() == Item.Type.Sand)
            {
                // increase moneys...
                Player.Instance.AddSand(item.GetCount());

                // play sound
                AudioManager.Instance.PlayEffect(AudioManager.Effect.NewSand);
            }
            
            Destroy(item.gameObject);
        }
    }
}
