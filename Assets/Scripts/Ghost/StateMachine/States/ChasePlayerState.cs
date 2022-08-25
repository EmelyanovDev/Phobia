using UnityEngine;

namespace Ghost.StateMachine.States
{
    public class ChasePlayerState : GhostState
    {
        [SerializeField] private Transform player;

        private void Update()
        {
            _agent.SetDestination(player.position);
        }
    }
}