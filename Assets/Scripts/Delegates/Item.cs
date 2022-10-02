using System;
using TMPro;
using UnityEngine;
using ItemScript = Resources.ScriptableObjects.Item;

namespace Delegates
{
    public class Item : MonoBehaviour
    {
        public enum Type
        {
            Food,
            Gold,
            Sand,
            Pacifier
        }
    
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _renderer;
        private BoxCollider2D _collider;

        private DraggableSprite _draggable;

        
        
        
        [SerializeField]
        private ItemScript _script;

        [SerializeField]
        private int _count = 1;

        private bool _isLocked = false;
    
        [SerializeField]
        private TextMeshPro mesh;
        
        [SerializeField]
        private SpriteRenderer _shadowRenderer;
    
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<BoxCollider2D>();
            _draggable = GetComponent<DraggableSprite>();
        }

        private void Start()
        {
            if (_script != null)
            {
                SetScript(_script);
            }
            else
            {
                Debug.Log("No Script");
            }
        }

        private void FixedUpdate()
        {
            mesh.text = "" + _count;
        
            if (_count <= 0)
                Destroy(gameObject);

            mesh.renderer.enabled = _count > 1;
        }

        public void SetScript(ItemScript script)
        {
            _script = script;
            _renderer.sprite = script.sprite;
            _shadowRenderer.sprite = script.sprite;
            _shadowRenderer.gameObject.SetActive(true);

            _count = 1;
        }

        public Type GetItemType()
        {
            return _script.type;
        }

        public string GetItemName()
        {
            return _script.itemName;
        }
    
        public int GetFoodValue()
        {
            return _script.foodValue;
        }

        public int GetSaleValue()
        {
            return _script.saleValue;
        }

        public int GetSandValue()
        {
            return _script.weaponValue;
        }

        public int GetCount()
        {
            return _count;
        }

        public void AddCount(int countToAdd)
        {
            _count += countToAdd;
        }

        public bool IsDragging()
        {
            return _draggable.IsDragging();
        }

        public void SetForce(Vector2 force)
        {
            _rigidbody.AddForce(force);
        }

        public void ProcessItemCollision(Item first, Item second)
        {
            if (_isLocked)
            {
                return;
            }

            if (first.transform.GetSiblingIndex() > second.transform.GetSiblingIndex())
            {
                return;
            }

            if (first == null || second == null)
            {
                return;
            }

            if (first.GetItemType() != second.GetItemType())
            {
                return;
            }

            if (first.GetItemName() != second.GetItemName())
            {
                return;
            }

            _isLocked = true;
        
            first.AddCount(second.GetCount());
            //Destroy(second.gameObject, 0.5f);
            Destroy(second.gameObject);

            _isLocked = false;
        }

        private void OnCollisionStay2D(Collision2D col)
        {
            var otherItem = col.gameObject.GetComponent<Item>();
            if (IsDragging() || otherItem == null || otherItem.IsDragging())
            {
                return;
            }
        
            ProcessItemCollision(this, otherItem);
        }

        private void OnMouseEnter()
        {
            
        }


        private void OnTriggerExit2D(Collider2D other)
        {
        
        }
    }
}
