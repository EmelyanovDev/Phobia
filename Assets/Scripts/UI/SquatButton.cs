using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Animator))]

    public class SquatButton : MonoBehaviour, IPointerClickHandler
    {
        private Animator _animator;
        private bool _isSat;    

        public static event Action OnButtonClick;

        private void Awake() => _animator = GetComponent<Animator>();

        public void OnPointerClick(PointerEventData eventData)
        {
            OnButtonClick?.Invoke();
            _animator.Play(_isSat ? "ButtonGettingUp" : "ButtonSquat");
            _isSat = !_isSat;
        }
    }
}