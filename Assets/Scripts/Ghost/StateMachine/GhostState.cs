using Settings;
using UnityEngine;
using UnityEngine.AI;

namespace Ghost.StateMachine
{
    [RequireComponent(typeof(NavMeshAgent))]
    
    public abstract class GhostState : MonoBehaviour
    {
        protected IStateSwitcher _stateSwitcher;
        protected GhostSettings _ghostSettings;
        protected NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void Init(IStateSwitcher switcher, GhostSettings settings)
        {
            _stateSwitcher = switcher;
            _ghostSettings = settings;
        }

        public virtual void Enable() => enabled = true;

        public virtual void Disable() => enabled = false;
    }
}