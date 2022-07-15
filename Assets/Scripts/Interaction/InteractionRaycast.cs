using UnityEngine;

namespace Interaction
{
    public class InteractionRaycast : MonoBehaviour
    {
        private Camera _camera;
        private Vector3 _screenCenter;

        private void Awake()
        {
            _camera = Camera.main;
            _screenCenter.Set(Screen.width / 2, Screen.height / 2, 0);
        }

        public Collider RaycastInCenter()
        {
            Ray ray = _camera.ScreenPointToRay(_screenCenter);
            RaycastHit hit;
            
            return Physics.Raycast(ray, out hit) ? hit.collider : null;
        }
    }
}