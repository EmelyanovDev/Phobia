using Interaction.InteractiveObjects;
using Player;
using Utilities;

namespace Inventory
{
    public class InventoryHub : Singleton<InventoryHub>
    {
        private SlotsHub _slotsHub;
        private PlayerHands _playerHands;

        private void Awake()
        {
            _slotsHub = SlotsHub.Instance;
            _playerHands = PlayerHands.Instance;
        }

        public void TakeItem(Item item)
        {
            _slotsHub.FillEmptySlot(item);
            _playerHands.TakeItem(item);
        }
    }
}
