using System;
using Player;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Interaction
{
    [RequireComponent(typeof(Image))]
    
    public class InteractCursor : MonoBehaviour
    {
        [SerializeField] private Sprite interactionSprite;
        
        private Sprite _defaultSprite;
        private Image _selfImage;
        private PlayerInteraction _interaction;

        private void Awake()
        {
            _selfImage = GetComponent<Image>();
            _defaultSprite = _selfImage.sprite;
            _interaction = PlayerInteraction.Instance;
        }

        private void Start()
        {
            if(_interaction.InteractionMode == InteractionMode.ScreenTouch)
                gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            PlayerInteraction.OnInteractiveObject += ChangeCursor;
        }

        private void OnDisable()
        {
            PlayerInteraction.OnInteractiveObject -= ChangeCursor;
        }

        private void ChangeCursor(bool onInteraction)
        {
            _selfImage.sprite = onInteraction ? interactionSprite : _defaultSprite;
        }
        
    }
}