using Interaction.InteractiveObjects;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private Image slotItemIcon;
        
        private Item _item;

        private PlayerHands _playerHands;
        
        public bool IsEmpty => _item == null;
        public Item Item => _item;

        private void Awake() => _playerHands = PlayerHands.Instance;

        public void Fill(Item item)
        {
            slotItemIcon.gameObject.SetActive(true);
            slotItemIcon.sprite = item.ItemIcon;
            _item = item;
        }

        public void Release()
        {
            if (_playerHands.IsBusy) return;
            
            slotItemIcon.gameObject.SetActive(false);
            _playerHands.TakeItem(this);
        }
    }
}
