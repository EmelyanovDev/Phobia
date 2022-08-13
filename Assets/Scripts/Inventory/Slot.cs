using System;
using Interaction.InteractiveObjects.Item;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory
{
    public class Slot : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SlotItemView slotItemView;
        
        private Item _selfItem;

        public Item SelfItem => _selfItem;
        
        public Action<Slot> OnSlotClicked;

        public void FillSlot(Item item)
        {
            item.gameObject.SetActive(false);
            slotItemView.ChangeIcon(item.ItemIcon);
            _selfItem = item;
        }

        public void ReleaseSlot()
        {
            slotItemView.ChangeIcon(null);
            _selfItem.DropItem();
            _selfItem = null;
        }

        public void ReturnItemFromHand()
        {
            slotItemView.ChangeTransparency(ItemStatus.InInventory);
            _selfItem.gameObject.SetActive(false);
        }

        public void TakeItem(Transform handPoint)
        {
            slotItemView.ChangeTransparency(ItemStatus.Taken);
            _selfItem.TakeItem(handPoint);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_selfItem == null) return;
            OnSlotClicked?.Invoke(this);
        }
    }
}
