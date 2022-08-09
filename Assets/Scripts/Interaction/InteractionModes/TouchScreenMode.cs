using System.Linq;
using UnityEngine;

namespace Interaction.InteractionModes
{
    public class TouchScreenMode : InteractionMode
    {
        [SerializeField] private float permissibleTouchDifference;
        
        private Vector2 _touchStartPosition;
        
        public override void CheckInteractive()
        {
            if (Input.touchCount <= 0) return;
            Touch touch = Input.touches.Last();
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _touchStartPosition = touch.position;
                    break;
                case TouchPhase.Ended:
                    var difference = touch.position - _touchStartPosition;
                    if (difference.magnitude <= permissibleTouchDifference)
                    {
                        var collider = InteractionRaycast.RaycastInTouch(touch.position);
                        var interactive = IsInteractive(collider);
                        interactive?.Interact();
                    }
                    break;
            }
        }
    }
}