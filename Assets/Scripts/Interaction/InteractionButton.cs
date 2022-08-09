using System;
using Interaction.InteractionModes;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Interaction
{
    [RequireComponent(typeof(Animator))]
    
    public class InteractionButton : MonoBehaviour, IPointerClickHandler
    {
        public static Action OnButtonClick;

        private void OnEnable()
        {
            ButtonMode.OnInteractiveObject += ChangeActive;
        }
        
        private void OnDestroy()
        {
            ButtonMode.OnInteractiveObject -= ChangeActive;
        }

        private void ChangeActive(bool onInteractive)
        {   
            gameObject.SetActive(onInteractive);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnButtonClick?.Invoke();
        }
    }
}