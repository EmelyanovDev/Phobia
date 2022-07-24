using System.Linq;
using Interaction.InteractiveObjects;
using Utilities;

namespace Inventory
{
    public class SlotsHub : Singleton<SlotsHub>
    {
        private Slot[] _slots;

        private void Awake() => _slots = GetComponentsInChildren<Slot>();

        public bool TryFillEmptySlot(Item item)
        {
            var emptySlot = _slots.FirstOrDefault(slot => slot.IsEmpty);
            if (emptySlot == null) return false;
            
            emptySlot.Fill(item);
            item.gameObject.SetActive(false);
            return true;
        }
    }
}
