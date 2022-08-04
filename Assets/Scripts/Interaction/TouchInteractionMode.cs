using System;
using System.Linq;
using UnityEngine;

namespace Interaction
{
    public class TouchInteractionMode : InteractionMode
    {
        [SerializeField] private float acceptableTouchDifference;
        
        private InteractionRaycast _interactionRaycast;
        private Vector2 _touchStartPosition;

        private void Awake()
        {
            _interactionRaycast = GetComponent<InteractionRaycast>();
        }

        public override Interactive CheckInteractiveObject()
        {
            if (Input.touchCount <= 0) return null;
            Touch touch = Input.touches.Last();
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _touchStartPosition = touch.position;
                    break;
                case TouchPhase.Ended:
                    var difference = touch.position - _touchStartPosition;
                    if (difference.magnitude <= acceptableTouchDifference)
                    {
                        var collider = _interactionRaycast.RaycastInTouch(touch.position);
                        return IsInteractive(collider);
                        Interact();
                    }
                    break;
            }
        }
    }
}