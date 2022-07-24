using UnityEngine;

namespace Interaction.InteractiveObjects
{
    [RequireComponent(typeof(Animator))]
    
    public class Door : Interactive
    {
        private Animator _animator;
        private bool _isOpen;

        private int _closing = Animator.StringToHash("DoorClosing");
        private int _opening = Animator.StringToHash("DoorOpening");

        private void Awake() => _animator = GetComponent<Animator>();

        public override void Interact()
        {
            _animator.Play(_isOpen ? _closing : _opening);
            _isOpen = !_isOpen;
        }
    }
}