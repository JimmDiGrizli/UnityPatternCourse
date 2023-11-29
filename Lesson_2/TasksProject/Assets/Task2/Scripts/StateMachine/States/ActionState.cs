using UnityEngine;

namespace Task2.Scripts.StateMachine.States
{
    public abstract class ActionState : IState
    {
        protected readonly IStateSwitcher _stateSwitcher;
        protected readonly Npc _npc;
        protected readonly NpcStateMachineData _data;
        
        private float _timer;
        protected float _expectedTime;

        protected ActionState(IStateSwitcher stateSwitcher, NpcStateMachineData data, Npc npc)
        {
            _stateSwitcher = stateSwitcher;
            _npc = npc;
            _data = data;
        }

        public virtual void Enter() => _timer = 0;

        public void Exit() => _expectedTime = 0;

        public void Update()
        {
            _timer += Time.deltaTime;

            if (!(_timer >= _expectedTime)) return;

            Execute();
        }

        protected abstract void Execute();
    }
}