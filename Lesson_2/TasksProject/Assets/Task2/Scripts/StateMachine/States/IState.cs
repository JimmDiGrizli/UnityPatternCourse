namespace Task2.Scripts.StateMachine.States
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Update();
    }
}