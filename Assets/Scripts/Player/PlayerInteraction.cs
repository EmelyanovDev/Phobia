using System;
using Interaction;
using UnityEngine;
using Utilities;

namespace Player
{
    [RequireComponent(typeof(InteractionRaycast))]
    
    public class PlayerInteraction : Singleton<PlayerInteraction>
    {
        [SerializeField] private float requiredDistance;
        
        private Interactive _interactiveObject;
        private InteractionRaycast _interactionRaycast;

        public static Action<bool> OnInteractiveObject;

        private void Awake()
        {
            _interactionRaycast = GetComponent<InteractionRaycast>();
        }

        private void Update() => CheckInteractiveObject();

        private void CheckInteractiveObject()
        {
            var collider = _interactionRaycast.RaycastInCenter();
            _interactiveObject = IsInteractive(collider);
            OnInteractiveObject.Invoke(_interactiveObject != null);
        }

        private Interactive IsInteractive(Collider collider)
        {
            if (collider == null) return null;
            if (collider.TryGetComponent(out Interactive interactable) == false) return null;
            if (transform.position.DistanceIsLess(collider.transform.position, requiredDistance))
                return interactable;
            return null;
        }

        public void Interact()
        {
            if(_interactiveObject != null)
                _interactiveObject.Interact();
        }
    }
}

