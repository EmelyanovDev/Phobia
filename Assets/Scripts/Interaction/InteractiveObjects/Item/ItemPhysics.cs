using UnityEngine;

namespace Interaction.InteractiveObjects.Item
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    
    public class ItemPhysics : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Collider _collider;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

        public void ChangePhysics(bool condition)
        {
            _rigidbody.isKinematic = !condition;
            _collider.enabled = condition;
        }
    }
}