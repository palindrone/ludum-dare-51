using Delegates;
using Helpers;
using Managers;

namespace Trigger
{
    public class MarketTrigger : SimpleTrigger
    {
        protected override void ProcessTrigger(Item item)
        {
            if (item.GetSaleValue() >= 0)
            {
                // increase moneys...
                Player.Instance.AddMoney(item.GetSaleValue() * item.GetCount());

                // play sound
                AudioManager.Instance.PlayEffect(AudioManager.Effect.NewMoney);
            }
            
            Destroy(item.gameObject);
        }
    }
}
