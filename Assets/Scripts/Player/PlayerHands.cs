using Interaction.InteractiveObjects;
using Inventory;
using UnityEngine;
using Utilities;

namespace Player
{
    public class PlayerHands : Singleton<PlayerHands>
    {
        [SerializeField] private GameObject itemButtons;
        [SerializeField] private Transform itemsSpawnPoint;
        [SerializeField] private Transform itemsDropPoint;
        [SerializeField] private float itemsActivateDelay;

        private Slot _takenItemSlot;
        private SlotsHub _slotsHub;

        public bool IsBusy => _takenItemSlot != null;

        private void Awake() => _slotsHub = SlotsHub.Instance;

        public void TakeItem(Slot slot)
        {
            var item = slot.Item;
            item.HandMode(true);
            item.gameObject.SetActive(true);
            item.transform.position = itemsSpawnPoint.position;
            item.transform.rotation = itemsSpawnPoint.rotation;
            item.transform.parent = itemsSpawnPoint;
            itemButtons.SetActive(true);
            _takenItemSlot = slot;
        }

        /*
        public void PutItemInInventory()
        {
            if (_slotsHub.TryFillEmptySlot(_takenItemSlot))
            {
                itemButtons.SetActive(false);
                _takenItemSlot = null;
            }
        }*/

        public void DropItem()
        {
            var item = _takenItemSlot.Item;
            var itemTransform = item.transform;
            itemTransform.position = itemsDropPoint.position;
            itemTransform.parent = null;
            item.HandMode(false);
            itemButtons.SetActive(false);
            _takenItemSlot = null;
        }
    }
}