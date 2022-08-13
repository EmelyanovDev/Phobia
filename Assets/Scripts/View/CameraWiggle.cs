using Player;
using UnityEngine;

namespace View
{
    public class CameraWiggle : MonoBehaviour
    {
        [SerializeField] private AnimationCurve wiggleCurve;
        [SerializeField] private float wigglePower;
        [SerializeField] private float wiggleSpeed;

        private float _wiggleTime;

        private void OnEnable() => PlayerMovement.OnPlayerMoved += Wiggle;
        
        private void OnDisable() => PlayerMovement.OnPlayerMoved -= Wiggle;
        
        private void Wiggle()
        {
            Vector3 angles = transform.localPosition;
            angles.y += wiggleCurve.Evaluate(_wiggleTime) * wigglePower;
            transform.localPosition = angles;
            _wiggleTime += Time.deltaTime * wiggleSpeed;
            if (_wiggleTime >= 1f) _wiggleTime = 0f;
        }
    }
}