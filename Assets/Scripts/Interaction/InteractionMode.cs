using UnityEngine;

namespace Interaction
{
    [RequireComponent(typeof(InteractionRaycast))]
    
    public abstract class InteractionMode : MonoBehaviour
    {
        [SerializeField] private float permissibleDistance;

        protected InteractionRaycast InteractionRaycast;

        private void Awake()
        {
            InteractionRaycast = GetComponent<InteractionRaycast>();
        }

        protected IInteractive IsInteractive(Collider collider)
        {
            if (collider == null) return null;
            if (collider.TryGetComponent(out IInteractive interactable) == false) return null;
            Vector3 colliderPosition = collider.transform.position;
            if (Vector3.Distance(transform.position, colliderPosition) < permissibleDistance)
                return interactable;
            return null;
        }

        public abstract void CheckInteractive();
    }
}