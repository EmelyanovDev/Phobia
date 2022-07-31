using Interaction.InteractiveObjects;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory
{
    public class Slot : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SlotItemView slotItemView;
        
        private Item _selfItem;
        private PlayerHands _playerHands;

        public bool IsEmpty => _selfItem == null;
        public Item SelfItem => _selfItem;

        private void Awake()
        {
            _playerHands = PlayerHands.Instance;
        }

        public void FillSlot(Item item)
        {
            item.gameObject.SetActive(false);
            slotItemView.ChangeIcon(item.ItemIcon);
            _selfItem = item;
            if(_playerHands.IsBusy == false)
                _playerHands.ChangeItem(this);
        }

        public void ChangeTransparency(float transparency)
        {
            slotItemView.ChangeTransparency(transparency);
        }

        public void ReleaseSlot()
        {
            slotItemView.ChangeIcon(null);
            _selfItem = null;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_selfItem == null) return;
            _playerHands.ChangeItem(this);
        }
    }
}
