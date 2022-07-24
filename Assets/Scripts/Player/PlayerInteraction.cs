using System;
using Interaction;
using UnityEngine;
using Utilities;

namespace Player
{
    [RequireComponent(typeof(InteractionRaycast))]
    
    public class PlayerInteraction : Singleton<PlayerInteraction>
    {
        [SerializeField] private InteractionMode interactionMode;
        [SerializeField] private float requiredDistance;
        [SerializeField] private float acceptableDifference;
        
        private Interactive _interactiveObject;
        private InteractionRaycast _interactionRaycast;
        private Vector2 _touchStartPosition;

        public InteractionMode InteractionMode => interactionMode;
        public static Action<bool> OnInteractiveObject;

        private void Awake()
        {
            _interactionRaycast = GetComponent<InteractionRaycast>();
        }

        private void Update()
        {
            switch (interactionMode)
            {
                case InteractionMode.Button:
                    CheckInteractiveObject();
                    break;
                case InteractionMode.ScreenTouch:
                    CheckScreenTouch();
                    break;
            }
        }

        private void CheckScreenTouch()
        {
            if (Input.touchCount <= 0) return; 
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _touchStartPosition = touch.position;
                    break;
                case TouchPhase.Ended:
                    var difference = touch.position - _touchStartPosition;
                    if (difference.magnitude <= acceptableDifference)
                    {
                        var collider = _interactionRaycast.RaycastInTouch(touch.position);
                        _interactiveObject = IsInteractive(collider);
                        Interact();
                    }
                    break;
            }
        }

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
            Vector3 colliderPosition = collider.transform.position;
            if (Vector3.Distance(transform.position, colliderPosition) < requiredDistance)
                return interactable;
            return null;
        }

        public void Interact()
        {
            if(_interactiveObject != null)
                _interactiveObject.Interact();
        }

        public void ChangeInteractionMode(InteractionMode mode)
        {
            interactionMode = mode;
        }
    }
}

