using System.Collections;
using Inventory;
using UnityEngine;

namespace Interaction.InteractiveObjects
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    
    public abstract class Item : Interactive
    {
        [SerializeField] private Sprite itemIcon;

        private SlotsHub _slotsHub;
        private Rigidbody _rigidbody;
        private Collider _collider;
        private Transform[] _childs;
        private int _defaultLayer, _topLayer;
        
        protected bool InHand;
        
        public Sprite ItemIcon => itemIcon;

        private void Awake()
        {
            _slotsHub = SlotsHub.Instance;
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            _childs = GetComponentsInChildren<Transform>();
            
            _defaultLayer = LayerMask.NameToLayer("Default");
            _topLayer = LayerMask.NameToLayer("TopLayer");
        }

        public override void Interact()
        {
            _slotsHub.TryFillEmptySlot(this);  
        }

        public void HandMode(bool condition, Transform spawnPoint)
        {
            InHand = condition;
            _rigidbody.isKinematic = condition;
            _collider.enabled = !condition;
            
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;

            ChangeLayer(condition ? _topLayer : _defaultLayer);
        }

        private void ChangeLayer(int newLayer)
        {
            gameObject.layer = newLayer;
            foreach (var child in _childs)
                child.gameObject.layer = newLayer;
        }
    }
}