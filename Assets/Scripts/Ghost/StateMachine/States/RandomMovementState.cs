using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Ghost.StateMachine.States
{
    [RequireComponent(typeof(NavMeshAgent))]   
    
    public class RandomMovementState : GhostState
    {
        [SerializeField] private Vector2 standingTimeRange;
        [SerializeField] private HouseRandomizer houseRandomizer;
        [SerializeField] private PlayerMind playerMind;

        private void Start()
        {
            StartCoroutine(SetNewDestination());
        }

        private float GetRandomDelay()
        {
            return Random.Range(standingTimeRange.x, standingTimeRange.y);
        }

        private IEnumerator SetNewDestination()
        {
            while (true)
            {
                yield return new WaitForSeconds(GetRandomDelay());
                Vector3 point = houseRandomizer.GetRandomPoint();
                _agent.SetDestination(point);
                CheckForSwitch();
            }
        }

        private void CheckForSwitch()
        {
            //if(playerMind.)
            _stateSwitcher.SwitchState<ChasePlayerState>();
        }
    }
}