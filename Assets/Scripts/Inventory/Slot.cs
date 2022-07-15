using Interaction.InteractiveObjects;
using UnityEngine;

namespace Inventory
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private SlotItemView slotItemTemplate;

        private SlotItemView _itemView;

        private Item _slotItem;
        
        public bool IsEmpty => _itemView == null;

        public void Fill(Item item)
        {
            var newItem = Instantiate(slotItemTemplate, transform);
            _itemView = newItem;
            _itemView.SetIcon(item.ItemIcon);
            _slotItem = item;
        }

        public void Release()
        {
            
        }
    }
}
