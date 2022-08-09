using System;

namespace Interaction.InteractionModes
{
    public class ButtonMode : InteractionMode
    {
        private IInteractive _interactiveObject;

        public static Action<bool> OnInteractiveObject;

        private void OnEnable()
        {
            InteractionButton.OnButtonClick += Interact;
        }
        
        private void OnDisable()
        {
            InteractionButton.OnButtonClick -= Interact;
        }

        private void Interact()
        {
            _interactiveObject.Interact();
        }
        
        public override void CheckInteractive()
        {
            var collider = InteractionRaycast.RaycastInCenter();
            _interactiveObject = IsInteractive(collider);
            OnInteractiveObject?.Invoke(_interactiveObject != null);
        }
    }
}