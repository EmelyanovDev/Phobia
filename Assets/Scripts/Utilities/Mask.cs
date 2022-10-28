using UnityEngine;

namespace Utilities
{
    [RequireComponent(typeof(MeshRenderer))]
    
    public class Mask : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<MeshRenderer>().material.renderQueue = 3001;
        }
    }
}
