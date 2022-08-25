using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Ghost
{
    [RequireComponent(typeof(NavMeshAgent))]
    
    public class GhostMovement : MonoBehaviour
    {
        
        [SerializeField] private HouseRandomizer houseRandomizer;

        

        private void Awake()
        {
            //_agent = GetComponent<NavMeshAgent>();
        }

        
    }
}