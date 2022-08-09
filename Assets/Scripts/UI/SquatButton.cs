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
        [SerializeField] private Sprite squatSprite;
        private Sprite _defaultSprite;
        private Image _image;
        private Animator _animator;
        private bool _isSat;    

        public static event Action OnButtonClick;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _animator = GetComponent<Animator>();
            _defaultSprite = _image.sprite;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnButtonClick?.Invoke();
            _animator.Play(_isSat ? "ButtonGettingUp" : "ButtonSquat");
            _isSat = !_isSat;
            //_image.sprite = _image.sprite == _defaultSprite ? squatSprite : _defaultSprite;
        }
    }
}