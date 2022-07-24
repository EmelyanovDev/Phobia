using Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Interaction
{
    public class InteractButton : MonoBehaviour, IPointerClickHandler
    {
        private PlayerInteraction _interaction;

        private void Awake()
        {
            _interaction = PlayerInteraction.Instance;
            if(_interaction.InteractionMode == InteractionMode.ScreenTouch)
                gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            PlayerInteraction.OnInteractiveObject += ChangeActive;
        }
        
        private void OnDestroy()
        {
            PlayerInteraction.OnInteractiveObject -= ChangeActive;
        }

        private void ChangeActive(bool onInteractive)
        {
            gameObject.SetActive(onInteractive);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _interaction.Interact();
        }
    }
}