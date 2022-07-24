using UI;
using UnityEngine;
using View;

namespace Player
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        
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
            transform.localEulerAngles += new Vector3(0, rotate.x);
            
            _cameraRotation.RotateCamera(-rotate.y);
        }
    }
}