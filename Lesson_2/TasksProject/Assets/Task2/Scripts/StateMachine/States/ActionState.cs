using UnityEngine;

namespace Task2.Scripts.StateMachine.States
{
    public abstract class ActionState : IState
    {
        protected readonly IStateSwitcher _stateSwitcher;
        protected readonly Npc _npc;
        protected readonly NpcStateMachineData _data;
        protected float _expectedTime;

        private float _timer;

        protected ActionState(IStateSwitcher stateSwitcher, NpcStateMachineData data, Npc npc)
        {
            _stateSwitcher = stateSwitcher;
            _npc = npc;
            _data = data;
        }

        public void Exit() => _timer = 0;

        public void Update(float deltaTime)
        {
            _timer += deltaTime;

            if (!(_timer >= _expectedTime)) return;

            OnTimeEnd();
        }

        public abstract void Enter();

        protected abstract void OnTimeEnd();
    }
}