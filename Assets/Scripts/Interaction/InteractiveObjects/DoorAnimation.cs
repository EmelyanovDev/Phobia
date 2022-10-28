using UnityEngine;

namespace Interaction.InteractiveObjects
{
    [RequireComponent(typeof(HingeJoint))]

    public class DoorAnimation : MonoBehaviour, IInteractive
    {
        [SerializeField] private float opennessPosition;
        
        private HingeJoint _hingeJoint;
        private bool _isOpen;
        private float _startPosition;

        private void Awake()
        {
            _hingeJoint = GetComponent<HingeJoint>();
            _startPosition = _hingeJoint.spring.targetPosition;
        }

        public void Interact()
        {
            var spring = _hingeJoint.spring;
            spring.targetPosition = _isOpen ? _startPosition : opennessPosition;
            _hingeJoint.spring = spring;
            _isOpen = !_isOpen;
        }
    }
}