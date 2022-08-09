using System;
using System.Linq;
using Interaction.InteractiveObjects.Item;
using Player;
using Utilities;

namespace Inventory
{
    public class SlotsHub : Singleton<SlotsHub>
    {
        private Slot[] _slots;
        private PlayerHands _playerHands;

        private void Awake()
        {
            _slots = GetComponentsInChildren<Slot>();
            _playerHands = PlayerHands.Instance;
        }

        private void OnEnable()
        {
            foreach (var slot in _slots)
                slot.OnSlotClicked += _playerHands.ChangeItem;
        }
        
        private void OnDisable()
        {
            foreach (var slot in _slots)
                slot.OnSlotClicked += _playerHands.ChangeItem;
        }

        public void FillEmptySlot(Item item)
        {
            var slot = GetEmptySlot();
            if (slot == null) return;
            slot.FillSlot(item);
            if(_playerHands.IsBusy == false)
                _playerHands.ChangeItem(slot);
        }

        private Slot GetEmptySlot()
        {
            return _slots.FirstOrDefault(slot => slot.SelfItem == null);
        }
    }
}
