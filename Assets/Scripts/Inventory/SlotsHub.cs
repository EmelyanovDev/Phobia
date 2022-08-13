using System.Linq;
using Interaction.InteractiveObjects.Item;
using Player;
using Utilities;

namespace Inventory
{
    public class SlotsHub : Singleton<SlotsHub>
    {
        private Slot[] _slots;
        private PlayerHand _playerHand;

        private void Awake()
        {
            _slots = GetComponentsInChildren<Slot>();
            _playerHand = PlayerHand.Instance;
        }

        private void OnEnable()
        {
            foreach (var slot in _slots)
                slot.OnSlotClicked += _playerHand.ChangeItem;
        }
        
        private void OnDisable()
        {
            foreach (var slot in _slots)
                slot.OnSlotClicked += _playerHand.ChangeItem;
        }

        public void FillEmptySlot(Item item)
        {
            var slot = GetEmptySlot();
            if (slot == null) return;
            slot.FillSlot(item);
            if(_playerHand.IsBusy == false)
                _playerHand.ChangeItem(slot);
        }

        private Slot GetEmptySlot()
        {
            return _slots.FirstOrDefault(slot => slot.SelfItem == null);
        }
    }
}
