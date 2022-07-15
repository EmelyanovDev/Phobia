using Player;
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

        private void Awake()
        {
            _selfImage = GetComponent<Image>();
            _defaultSprite = _selfImage.sprite;
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