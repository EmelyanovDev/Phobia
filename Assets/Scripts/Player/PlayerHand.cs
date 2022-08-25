using System;
using Inventory;
using UI;
using UnityEngine;
using Utilities;

namespace Player
{
    public class PlayerHand : Singleton<PlayerHand>
    {
        [SerializeField] private Transform itemsSpawnPoint;
        [SerializeField] private Transform itemsDropPoint;
        
        private Slot _takenItemSlot;
        
        public bool IsBusy => _takenItemSlot != null;

        public static event Action<bool> OnItemChanged;

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
            itemSlot.TakeItemInHand(itemsSpawnPoint);
            ChangeSlot(itemSlot);
        }
        
        private void DropItem()
        {
            _takenItemSlot.ReleaseSlot(itemsDropPoint);
            ChangeSlot(null);
        }

        private void ChangeSlot(Slot itemSlot)
        {
            _takenItemSlot = itemSlot;
            OnItemChanged?.Invoke(itemSlot);
        }

        private void ReturnItemInSlot()
        {
            _takenItemSlot.ReturnItemFromHand();
            ChangeSlot(null);
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
    }
}