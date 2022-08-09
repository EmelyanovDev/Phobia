using Inventory;
using UnityEngine;

namespace Interaction.InteractiveObjects.Item
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(ItemLayer))]
    
    public abstract class Item : MonoBehaviour, IInteractive
    {
        [SerializeField] private Sprite itemIcon;

        private SlotsHub _slotsHub;
        private Rigidbody _rigidbody;
        private Collider _collider;
        private ItemLayer _itemLayer;
        
        protected bool InHand;
        
        public Sprite ItemIcon => itemIcon;

        private void Awake()
        {
            _slotsHub = SlotsHub.Instance;
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            _itemLayer = GetComponent<ItemLayer>();
        }

        public void Interact()
        {
            _slotsHub.FillEmptySlot(this);  
        }

        public void HandMode(bool inHand, Transform spawnPoint)
        {
            InHand = inHand;
            _rigidbody.isKinematic = inHand;
            _collider.enabled = !inHand;
            ChangeTransform(spawnPoint);
            _itemLayer.ChangeLayer(inHand);
        }

        private void ChangeTransform(Transform target)
        {
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
    }
}