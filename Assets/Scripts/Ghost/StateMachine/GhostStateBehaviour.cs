using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ghost.StateMachine
{
    public class GhostStateBehaviour : MonoBehaviour, IStateSwitcher
    {
        [SerializeField] private GhostState currentState;
        private List<GhostState> _states;

        private void Awake()
        {
            _states = GetComponents<GhostState>().ToList();
            foreach (var state in _states)
                state.Init(this);
            currentState.Enable();
        }

        public void SwitchState<T>() where T : GhostState
        {
            currentState.Disable();
            var state = _states.FirstOrDefault(state => state is T);
            currentState = state;
            state.Enable();
        }
    }
}