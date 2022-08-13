using UnityEngine;

namespace View
{
    public class CameraRotation : MonoBehaviour
    {
        [SerializeField] private Vector2 rotationLimits;
        
        public void RotateCamera(float rotate)
        {
            transform.localEulerAngles += new Vector3(rotate, 0);
            LimitRotation();
        }

        private void LimitRotation()
        {
            Vector3 angles = transform.eulerAngles;
            angles.x = (angles.x > 180) ? angles.x - 360 : angles.x;
            angles.x = Mathf.Clamp(angles.x, rotationLimits.x, rotationLimits.y);
            transform.eulerAngles = angles;
        }
    }
}