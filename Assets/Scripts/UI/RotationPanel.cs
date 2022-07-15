using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class RotationPanel : MonoBehaviour, IDragHandler
    { 
        public static Action<Vector2> OnPointerDrag;

        public void OnDrag(PointerEventData eventData)
        {
            OnPointerDrag?.Invoke(eventData.delta);
        }
    }
}