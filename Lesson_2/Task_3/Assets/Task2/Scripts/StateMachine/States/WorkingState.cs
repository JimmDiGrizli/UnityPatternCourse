using UnityEngine;

namespace Task2.Scripts.StateMachine.States
{
    public class WorkingState : IState
    {        
        private readonly IStateSwitcher _stateSwitcher;
        private readonly Npc _npc;
        private NpcStateMachineData _data;
        private float _timer;

        public WorkingState(IStateSwitcher stateSwitcher, NpcStateMachineData data, Npc npc)
        {
            _stateSwitcher = stateSwitcher;
            _npc = npc;
            _data = data;
        }
        
        public void Enter()
        {
            Debug.Log("Start working.");
            _timer = 0;
        }

        public void Exit()
        {
            Debug.Log("Finish working.");
        }
        
        public void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _npc.Config.WorkingStateConfig.Time)
            {
                _data.NextPosition = _npc.SleepZone;
                _stateSwitcher.SwitchState<MovingState>();
            }
        }
    }
}