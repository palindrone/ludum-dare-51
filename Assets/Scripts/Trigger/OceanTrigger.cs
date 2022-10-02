using System;
using Delegates;
using Helpers;
using Managers;
using UnityEngine;

namespace Trigger
{
    public class OceanTrigger : SimpleTrigger
    {
        private Animator _animator;

        private static OceanTrigger _instance;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _instance = this;
        }

        private void ThrowInOcean(Item item)
        {
            ProcessToss(item);

            Destroy(item.gameObject);
            AudioManager.Instance.PlayEffect(AudioManager.Effect.Splash);
        }

        private void ProcessToss(Item item)
        {
            if (item.GetItemType() == Item.Type.Pacifier)
            {
                MainSceneManager.WinGameStatic();
            }

            if (item.GetItemType() == Item.Type.Food)
            {
                Beast.Instance.Feed(item.GetFoodValue() * item.GetCount());
            }
            
            // TODO: Play a sound effect for throwing the wrong thing?
        }
    
        protected override void ProcessTrigger(Item item)
        {
            ThrowInOcean(item);
        }

        public static void AnimateOcean(bool roil)
        {
            _instance._animator.SetBool("Roil", roil);
        }
    }
}
