using Inventory;
using UnityEngine;
using Utilities;

namespace Player
{
    public class PlayerHands : Singleton<PlayerHands>
    {
        [SerializeField] private GameObject itemButtons;
        [SerializeField] private Transform itemsSpawnPoint;
        
        private Slot _takenItemSlot;
        
        public bool IsBusy => _takenItemSlot != null;

        private void TakeItem(Slot itemSlot)
        {
            _takenItemSlot = itemSlot;
            itemButtons.SetActive(true);
            itemSlot.ChangeTransparency(0.5f);
            var item = itemSlot.SelfItem;
            item.HandMode(true, itemsSpawnPoint);
            item.transform.parent = itemsSpawnPoint;
            item.gameObject.SetActive(true);
        }

        private void ReturnItemInSlot()
        {
            _takenItemSlot.ReturnItemFromHand();
            itemButtons.SetActive(false);
            _takenItemSlot = null;
        }

        public void ChangeItem(Slot itemSlot)
        {
            if(IsBusy)
            {
                var previousSlot = _takenItemSlot;
                 ReturnItemInSlot();
                 if(previousSlot != itemSlot)
                     TakeItem(itemSlot);
            }
            else
            {
                TakeItem(itemSlot);
            }
        }

        public void DropItem()
        {
            var item = _takenItemSlot.SelfItem;
            item.transform.parent = null;
            item.HandMode(false, itemsSpawnPoint);
            itemButtons.SetActive(false);
            _takenItemSlot.ReleaseSlot();
            _takenItemSlot = null;
        }
    }
}