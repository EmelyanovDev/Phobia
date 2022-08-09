using Interaction.InteractionModes;
using UnityEngine;
using UnityEngine.UI;

namespace Interaction
{
    [RequireComponent(typeof(Image))]
    
    public class InteractionCursor : MonoBehaviour
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
            ButtonMode.OnInteractiveObject += ChangeCursor;
        }

        private void OnDisable()
        {
            ButtonMode.OnInteractiveObject -= ChangeCursor;
        }

        private void ChangeCursor(bool onInteractionObject)
        {
            _selfImage.sprite = onInteractionObject ? interactionSprite : _defaultSprite;
        }
        
    }
}