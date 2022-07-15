using Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Interaction
{
    public class InteractButton : MonoBehaviour, IPointerDownHandler
    {
        private PlayerInteraction _interaction;

        private void Awake()
        {
            _interaction = PlayerInteraction.Instance;
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

        public void OnPointerDown(PointerEventData eventData)
        {
            _interaction.Interact();
        }
    }
}