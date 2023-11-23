using System.Collections.Generic;
using System.Linq;
using Task2.Scripts.StateMachine.States;

namespace Task2.Scripts.StateMachine
{
    public class NpcStateMachine : IStateSwitcher
    {
        private readonly List<States.IState> _states;
        private States.IState _currentState;

        public NpcStateMachine(Npc npc)
        {
            var data = new NpcStateMachineData();
            _states = new List<States.IState>()
            {
                new SleepingState(this, data, npc),
                new MovingState(this, data, npc),
                new WorkingState(this, data, npc),
            };

            _currentState = _states[0];
            _currentState.Enter();
        }

        public void SwitchState<TState>() where TState : States.IState
        {
            var state = _states.FirstOrDefault(state => state is TState);

            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void Update() => _currentState.Update();
    }
}