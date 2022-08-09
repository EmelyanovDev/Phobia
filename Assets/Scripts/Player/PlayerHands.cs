using System;
using Inventory;
using UI;
using UnityEngine;
using Utilities;

namespace Player
{
    public class PlayerHands : Singleton<PlayerHands>
    {
        [SerializeField] private Transform itemsSpawnPoint;
        
        private Slot _takenItemSlot;
        
        public bool IsBusy => _takenItemSlot != null;

        public static Action<bool> OnItemTaken;

        private void OnEnable()
        {
            DropItemButton.OnButtonClick += DropItem;
        }
        
        private void OnDisable()
        {
            DropItemButton.OnButtonClick -= DropItem;
        }

        private void TakeItem(Slot itemSlot)
        {
            _takenItemSlot = itemSlot;
            var item = itemSlot.SelfItem;
            itemSlot.ChangeViewTransparency(0.5f);
            item.HandMode(true, itemsSpawnPoint);
            item.transform.SetParent(itemsSpawnPoint);
            item.gameObject.SetActive(true);
            
            OnItemTaken?.Invoke(true);
        }

        private void ReturnItemInSlot()
        {
            _takenItemSlot.ChangeViewTransparency(1f);
            _takenItemSlot.SelfItem.gameObject.SetActive(false);
            _takenItemSlot = null;
            
            OnItemTaken?.Invoke(false);
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
            item.transform.SetParent(null);
            item.HandMode(false, itemsSpawnPoint);
            _takenItemSlot.ReleaseSlot();
            _takenItemSlot = null;
            
            OnItemTaken?.Invoke(false);
        }
    }
}