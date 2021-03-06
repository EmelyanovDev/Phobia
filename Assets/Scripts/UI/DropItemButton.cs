using Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class DropItemButton : MonoBehaviour, IPointerClickHandler
    {
        private PlayerHands _playerHands;

        private void Awake()
        {
            _playerHands = PlayerHands.Instance;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _playerHands.DropItem();
        }
    }
}
