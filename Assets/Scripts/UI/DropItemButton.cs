using System;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class DropItemButton : MonoBehaviour, IPointerClickHandler
    {
        public static event Action OnButtonClick;

        private void Start()
        {
            PlayerHand.OnItemChanged += gameObject.SetActive;
            gameObject.SetActive(false);
        }
        
        private void OnDestroy()
        {
            PlayerHand.OnItemChanged -= gameObject.SetActive;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnButtonClick?.Invoke();
        }
    }
}
