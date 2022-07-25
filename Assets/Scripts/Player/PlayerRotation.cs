using UI;
using UnityEngine;
using View;

namespace Player
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float smoothnessValue;
        
        private CameraRotation _cameraRotation;

        private void Awake()
        {
            _cameraRotation = GetComponentInChildren<CameraRotation>();
        }

        private void OnEnable() => RotationPanel.OnPointerDrag += Rotate;

        private void OnDisable() => RotationPanel.OnPointerDrag -= Rotate;

        private void Rotate(Vector2 touchDelta)
        {
            Vector2 rotate = touchDelta * Time.deltaTime * rotationSpeed;
            Vector3 target = transform.localEulerAngles += new Vector3(0, rotate.x);
            transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, target, smoothnessValue * Time.deltaTime);
            
            _cameraRotation.RotateCamera(-rotate.y);
        }
    }
}