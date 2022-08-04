using UnityEngine;

namespace Interaction
{
    public abstract class InteractionMode : MonoBehaviour
    {
        [SerializeField] private float acceptableDistance;
        
        public abstract Interactive CheckInteractiveObject();
        
        protected Interactive IsInteractive(Collider collider)
        {
            if (collider == null) return null;
            if (collider.TryGetComponent(out Interactive interactable) == false) return null;
            Vector3 colliderPosition = collider.transform.position;
            if (Vector3.Distance(transform.position, colliderPosition) < acceptableDistance)
                return interactable;
            return null;
        }
    }
}