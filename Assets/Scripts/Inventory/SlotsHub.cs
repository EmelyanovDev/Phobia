using System.Linq;
using Interaction.InteractiveObjects;
using UnityEngine;
using Utilities;

namespace Inventory
{
    public class SlotsHub : Singleton<SlotsHub>
    {
        [SerializeField] private Slot[] _slots;

        private void Awake() => _slots = GetComponentsInChildren<Slot>();

        public void FillEmptySlot(Item item)
        {
            var emptySlot = _slots.FirstOrDefault(slot => slot.IsEmpty);
            if (emptySlot == null) return;
            
            emptySlot.Fill(item);
            Destroy(item.gameObject);
        }
    }
}
