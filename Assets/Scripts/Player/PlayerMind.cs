using Settings;
using UnityEngine;

namespace Player
{
    public class PlayerMind : MonoBehaviour
    {
        [SerializeField] private float lossMindRate;
        private float _mindValue = 1f;
        
        public void Attack(float value)
        {
            _mindValue -= value;
        }
    }   
}