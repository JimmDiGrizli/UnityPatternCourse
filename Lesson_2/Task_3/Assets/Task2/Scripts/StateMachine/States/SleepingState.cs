using UnityEngine;

namespace Task2.Scripts.StateMachine.States
{
    public class SleepingState : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly Npc _npc;
        private readonly NpcStateMachineData _data;
        private float _timer;

        public SleepingState(IStateSwitcher stateSwitcher, NpcStateMachineData data, Npc npc)
        {
            _stateSwitcher = stateSwitcher;
            _npc = npc;
            _data = data;
        }

        public void Enter()
        {
            Debug.Log("Start sleeping.");
            _timer = 0;
        }

        public void Exit()
        {
            Debug.Log("Finish sleeping.");
        }

        public void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _npc.Config.SleepingStateConfig.Time)
            {
                _data.NextPosition = _npc.WorkZone;
                _stateSwitcher.SwitchState<MovingState>();
            }
        }
    }
}