using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class SquatButton : MonoBehaviour, IPointerClickHandler
    {
        public static event Action OnButtonClick;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnButtonClick?.Invoke();
        }
    }
}