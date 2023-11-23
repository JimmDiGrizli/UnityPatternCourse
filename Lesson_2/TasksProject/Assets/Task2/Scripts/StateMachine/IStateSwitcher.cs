namespace Task2.Scripts.StateMachine
{
    public interface IStateSwitcher
    {
        void SwitchState<TState>() where TState : States.IState;
    }
}