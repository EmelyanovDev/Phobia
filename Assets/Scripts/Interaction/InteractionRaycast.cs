using System;
using UnityEngine;

namespace Interaction
{
    public class InteractionRaycast : MonoBehaviour
    {
        private Camera _camera;
        private Vector2 _screenCenter;
        private RaycastHit _hit;

        private void Awake()
        {
            _camera = Camera.main;
            _screenCenter = new Vector2(_camera.pixelWidth / 2, _camera.pixelHeight / 2);
        }

        public Collider RaycastInCenter()
        {
            Ray ray = _camera.ScreenPointToRay(_screenCenter);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            _hit = hit;
            return Physics.Raycast(ray, out hit) ? hit.collider : null;
        }

        public Collider RaycastInTouch(Vector2 touchPosition)
        {
            Ray ray = _camera.ScreenPointToRay(touchPosition);
            RaycastHit hit;
            return Physics.Raycast(ray, out hit) ? hit.collider : null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_hit.point, 0.1f);
        }
    }
}