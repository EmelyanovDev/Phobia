using Interaction.InteractiveObjects;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private Image slotItemIcon;
        
        private Item _slotItem;

        private PlayerHands _playerHands;
        
        public bool IsEmpty => _slotItem == null;

        private void Awake() => _playerHands = PlayerHands.Instance;

        public void Fill(Item item)
        {
            slotItemIcon.gameObject.SetActive(true);
            slotItemIcon.sprite = item.ItemIcon;
            _slotItem = item;
        }

        public void Release()
        {
            if (_playerHands.IsBusy) return;
            
            slotItemIcon.gameObject.SetActive(false);
            _playerHands.TakeItem(_slotItem);
            _slotItem = null;
        }
    }
}
