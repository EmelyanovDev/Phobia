using UnityEngine;

namespace Ghost
{
    public class HouseRandomizer : MonoBehaviour
    {
        [SerializeField] private Collider _randomCollider;

        public Vector3 GetRandomPoint()
        {
            Bounds bounds = _randomCollider.bounds;
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }
    }
}
