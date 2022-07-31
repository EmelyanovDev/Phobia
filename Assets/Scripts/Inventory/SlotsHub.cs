using System.Linq;
using Interaction.InteractiveObjects;
using Player;
using Utilities;

namespace Inventory
{
    public class SlotsHub : Singleton<SlotsHub>
    {
        private Slot[] _slots;

        private void Awake() => _slots = GetComponentsInChildren<Slot>();

        public void TryFillEmptySlot(Item item)
        {
            var emptySlot = _slots.FirstOrDefault(slot => slot.IsEmpty);
            if (emptySlot == null) return;
            emptySlot.FillSlot(item);
        }
    }
}
