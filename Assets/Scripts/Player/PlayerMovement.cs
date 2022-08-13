using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        
        private Joystick _joystick;
        private Rigidbody _rigidbody;

        public static Action OnPlayerMoved;

        private void Awake()
        {
            _joystick = Joystick.Instance;
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() => Move();

        private void Move()
        {
            if (_joystick.Direction == Vector3.zero) return;
            Vector3 move = transform.rotation * _joystick.Direction;
            move *= movementSpeed * Time.fixedDeltaTime;
            _rigidbody.velocity = new Vector3(move.x, _rigidbody.velocity.y, move.z);
            OnPlayerMoved?.Invoke();
        }
    }
}