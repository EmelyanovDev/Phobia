using Inventory;
using UnityEngine;

namespace Interaction.InteractiveObjects.Item
{
    [RequireComponent(typeof(ItemLayer))]
    [RequireComponent(typeof(ItemPhysics))]
    
    public class Item : MonoBehaviour, IInteractive
    {
        [SerializeField] private Sprite itemIcon;

        private SlotsHub _slotsHub;
        private ItemPhysics _physics;
        private ItemLayer _layer;
        
        protected bool _inHand;
        
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

        public void DropItem(Transform dropPoint)
        {
            ChangeHandCondition(false, null);
            ChangeTransform(dropPoint);
        }

        private void ChangeHandCondition(bool condition, Transform parent)
        {
            _inHand = condition;
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