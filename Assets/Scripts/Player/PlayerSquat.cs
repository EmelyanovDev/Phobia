using System.Collections;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerSquat : MonoBehaviour
    {
        [SerializeField] private Vector3 squatPosition;
        [SerializeField] private float squatSpeed;

        private Vector3 _standingPosition;
        private Vector3 _targetPosition;

        private void Awake()
        {
            _standingPosition = transform.localPosition;
            _targetPosition = _standingPosition;
        }

        private void OnEnable() => SquatButton.OnButtonClick += ChangeTargetPosition;
        
        private void OnDisable() => SquatButton.OnButtonClick += ChangeTargetPosition;
        
        private void ChangeTargetPosition()
        {
            if (_targetPosition == squatPosition)
                _targetPosition = _standingPosition;
            else if (_targetPosition == _standingPosition)
                _targetPosition = squatPosition;
        }

        private void FixedUpdate()
        {
            if (transform.localPosition == _targetPosition) return;
            float speed = squatSpeed * Time.fixedDeltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _targetPosition, speed);
        }
    }
}