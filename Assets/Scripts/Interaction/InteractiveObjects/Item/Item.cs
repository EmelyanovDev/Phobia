using Inventory;
using UnityEngine;

namespace Interaction.InteractiveObjects.Item
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(ItemLayer))]
    [RequireComponent(typeof(ItemPhysics))]
    
    public abstract class Item : MonoBehaviour, IInteractive
    {
        [SerializeField] private Sprite itemIcon;

        private SlotsHub _slotsHub;
        private ItemPhysics _physics;
        private ItemLayer _layer;
        
        protected bool InHand;
        
        public Sprite ItemIcon => itemIcon;

        private void Awake()
        {
            _slotsHub = SlotsHub.Instance;
            _physics = GetComponent<ItemPhysics>();
            _layer = GetComponent<ItemLayer>();
        }

        public void Interact()
        {
            _slotsHub.FillEmptySlot(this);  
        }

        public void TakeItem(Transform handPoint)
        {
            gameObject.SetActive(true);
            ChangeHandCondition(true, handPoint);
            ChangeTransform(handPoint);
        }

        public void DropItem()
        {
            ChangeHandCondition(false, null);
        }

        private void ChangeHandCondition(bool condition, Transform parent)
        {
            InHand = condition;
            _physics.ChangePhysics(!condition);
            _layer.ChangeLayer(condition);
            transform.SetParent(parent);
        }

        private void ChangeTransform(Transform target)
        {
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
    }
    
    public enum ItemStatus
    {
        Taken,
        InInventory,
    }
}