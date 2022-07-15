using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        
        private Joystick _joystick;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _joystick = Joystick.Instance;
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() => Move();

        private void Move()
        {
            Vector3 move = transform.rotation * _joystick.Direction;
            move *= movementSpeed * Time.deltaTime;
            _rigidbody.velocity = new Vector3(move.x, _rigidbody.velocity.y, move.z);
        }
    }
}