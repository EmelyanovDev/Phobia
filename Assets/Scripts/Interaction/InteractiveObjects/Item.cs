

using Inventory;
using UnityEngine;

namespace Interaction.InteractiveObjects
{
    public class Item : Interactive
    {
        [SerializeField] private Sprite itemIcon;
        [SerializeField] private Vector3 handOffset;

        private InventoryHub _inventory;

        public Sprite ItemIcon => itemIcon;
        public Vector3 HandOffset => handOffset;

        private void Awake() => _inventory = InventoryHub.Instance;

        public override void Interact()
        {
            _inventory.TakeItem(this);  
        }
    }
}