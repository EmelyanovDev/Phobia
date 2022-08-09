using System;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class DropItemButton : MonoBehaviour, IPointerClickHandler
    {
        public static Action OnButtonClick;

        private void Start()
        {
            PlayerHands.OnItemTaken += gameObject.SetActive;
            gameObject.SetActive(false);
        }
        
        private void OnDestroy()
        {
            PlayerHands.OnItemTaken -= gameObject.SetActive;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnButtonClick?.Invoke();
        }
    }
}
