using System.Collections.Generic;
using System.Linq;
using Settings;
using UnityEngine;

namespace Ghost.StateMachine
{
    public class GhostStateBehaviour : MonoBehaviour, IStateSwitcher
    {
        [SerializeField] private GhostSettings ghostSettings;
        private GhostState _currentState;
        private List<GhostState> _states;

        private void Awake()
        {
            _states = GetComponents<GhostState>().ToList();
            foreach (var state in _states)
                state.Init(this, ghostSettings);
        }

        public void SwitchState<T>() where T : GhostState
        {
            _currentState.Disable();
            var state = _states.FirstOrDefault(state => state is T);
            _currentState = state;
            state.Enable();
        }
    }
}