namespace Ghost.StateMachine
{
    public interface IStateSwitcher
    {
        public void SwitchState<T>() where T : GhostState;
    }
}