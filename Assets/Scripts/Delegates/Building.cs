using Factories;
using Managers;
using UnityEngine;
using UnityEngine.UI;
using BuildingScript = Resources.ScriptableObjects.Building;

namespace Delegates
{
    public class Building : MonoBehaviour
    {
        protected float MaxTime;
        protected float CurrentTime = 0.0f;

        [SerializeField]
        protected BuildingScript Script;

        private Rigidbody2D _rigidbody;
        private SpriteRenderer _renderer;
        private BoxCollider2D _collider;

        private Animator _animator;
        
        [SerializeField]
        private Image _counterImage;
    
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<BoxCollider2D>();
            _animator = GetComponent<Animator>();
        }
    
    
        void Start()
        {
            if (Script != null)
            {
                LoadScriptData();
            }
            MaxTime = GetTime();
            UpdateImage();
        }

        private void FixedUpdate()
        {
            if (!MainSceneManager.IsTimerRunning)
            {
                return;
            }
        
            CurrentTime += Time.deltaTime;
            UpdateImage();

            if (CurrentTime >= MaxTime)
            {
                TriggerTimer();
                CurrentTime = 0;
            }
        }

        public void SetScript(BuildingScript script)
        {
            Script = script;
            LoadScriptData();
        }

        private void LoadScriptData()
        {
            _renderer.sprite = Script.sprite;

            if (Script.animationTrigger == "")
            {
                _animator.enabled = false;
            }
            else
            {
                _animator.enabled = true;
                _animator.SetTrigger(Script.animationTrigger);   
            }
        }

        protected void TriggerTimer()
        {
            ItemFactory.Instance.GenerateItem(Script.spawnItem, transform.position);
        }

        protected float GetTime()
        {
            return Script.spawnTime;
        }

        private void UpdateImage()
        {
            var diff = CurrentTime / MaxTime;

            _counterImage.fillAmount = diff;
        }
    }
}
