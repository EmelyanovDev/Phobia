using UnityEngine;

namespace Utilities
{
    public class Singleton<TSource> : MonoBehaviour where TSource : MonoBehaviour
    {
        private static TSource _instance;
        
        public static TSource Instance
        {
            get
            {
                if (_instance != null) 
                    return _instance;
                _instance = FindObjectOfType<TSource>();
                
                return _instance;
            }
        }
    }
}