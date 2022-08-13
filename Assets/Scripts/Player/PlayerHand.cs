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
        
        private Slot _takenItemSlot;
        
        public bool IsBusy => _takenItemSlot != null;

        public static Action<bool> OnItemChanged;

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
            itemSlot.TakeItem(itemsSpawnPoint);
            ChangeItemSlot(itemSlot);
        }

        private void ReturnItemInSlot()
        {
            _takenItemSlot.ReturnItemFromHand();
            ChangeItemSlot(null);
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

        private void DropItem()
        {
            _takenItemSlot.ReleaseSlot();
            ChangeItemSlot(null);
        }

        private void ChangeItemSlot(Slot itemSlot)
        {
            _takenItemSlot = itemSlot;
            OnItemChanged?.Invoke(itemSlot);
        }
    }
}