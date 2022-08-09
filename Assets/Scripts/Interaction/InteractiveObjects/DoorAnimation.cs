using UnityEngine;

namespace Interaction.InteractiveObjects
{
    [RequireComponent(typeof(Animator))]

    public class DoorAnimation : MonoBehaviour, IInteractive
    {
        private Animator _animator;
        private bool _isOpen;

        private int _opening = Animator.StringToHash("DoorOpening");
        private int _closing = Animator.StringToHash("DoorClosing");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Interact()
        {
            _animator.Play(_isOpen ? _closing : _opening);
            _isOpen = !_isOpen;
        }
    }
}