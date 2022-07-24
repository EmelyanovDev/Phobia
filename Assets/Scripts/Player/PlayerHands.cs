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

        private Item _takenItem;
        private SlotsHub _slotsHub;

        public bool IsBusy => _takenItem != null;

        private void Awake() => _slotsHub = SlotsHub.Instance;

        public void TakeItem(Item item)
        {
            item.HandMode(true);
            item.gameObject.SetActive(true);
            item.transform.position = itemsSpawnPoint.position;
            item.transform.rotation = itemsSpawnPoint.rotation;
            item.transform.parent = itemsSpawnPoint;
            itemButtons.SetActive(true);
            _takenItem = item;
        }

        public void PutItemInInventory()
        {
            if (_slotsHub.TryFillEmptySlot(_takenItem))
            {
                itemButtons.SetActive(false);
                _takenItem = null;
            }
        }

        public void DropItem()
        {
            var itemTransform = _takenItem.transform;
            itemTransform.position = itemsDropPoint.position;
            itemTransform.parent = null;
            _takenItem.HandMode(false);
            itemButtons.SetActive(false);
            _takenItem = null;
        }
    }
}