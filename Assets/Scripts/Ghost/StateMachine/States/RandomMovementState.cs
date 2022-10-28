using System;
using System.Collections;
using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

namespace Ghost.StateMachine.States
{
    [RequireComponent(typeof(GhostActivity))]
    
    public class RandomMovementState : GhostState
    {
        [SerializeField] private Vector2 standingTimeRange;
        [SerializeField] private HouseRandomizer houseRandomizer;
        
        private GhostActivity _activity;
        private float _periodTime;

        private void Start()
        {
            StartCoroutine(SetNewDestination());
            _activity = GetComponent<GhostActivity>();
        }

        private float GetRandomDelay()
        {
            return Random.Range(standingTimeRange.x, standingTimeRange.y);
        }

        private IEnumerator SetNewDestination()
        {
            print("A");
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
            // print(_activity.GetActivity());
            // if(Randomizer.PlayLottery(_activity.GetActivity()))
            //     _stateSwitcher.SwitchState<ChasePlayerState>();
        }
    }
}