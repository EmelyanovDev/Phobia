using UnityEngine;

namespace Ghost
{
    public class HouseRandomizer : MonoBehaviour
    {
        [SerializeField] private Collider _randomRangeCollider;

        public Vector3 GetRandomPoint()
        {
            Bounds bounds = _randomRangeCollider.bounds;
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }
    }
}
