using UnityEngine;
using UnityEngine.AI;

namespace Ghost.StateMachine
{
    [RequireComponent(typeof(NavMeshAgent))]
    
    public abstract class GhostState : MonoBehaviour
    {
        protected IStateSwitcher _stateSwitcher;
        protected NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void Init(IStateSwitcher switcher)
        {
            _stateSwitcher = switcher;
            enabled = false;
        }

        public virtual void Enable() => enabled = true;

        public virtual void Disable() => enabled = false;
    }
}