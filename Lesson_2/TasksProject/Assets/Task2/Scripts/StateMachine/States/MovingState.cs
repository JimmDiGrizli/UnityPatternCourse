using System;
using UnityEngine;

namespace Task2.Scripts.StateMachine.States
{
    public class MovingState : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly Npc _npc;
        private readonly NpcStateMachineData _data;

        private Transform _target;
        private Action _switch;

        public MovingState(IStateSwitcher stateSwitcher, NpcStateMachineData data, Npc npc)
        {
            _stateSwitcher = stateSwitcher;
            _npc = npc;
            _data = data;
        }

        public void Enter()
        {
            Debug.Log("Start moving.");

            _target = _data.NextPosition;
            _npc.SleepStated += OnSleepStated;
            _npc.WorkStarted += OnWorkStated;
        }

        public void Exit()
        {
            Debug.Log("Stop moving.");

            _target = null;
            _npc.SleepStated -= OnSleepStated;
            _npc.WorkStarted -= OnWorkStated;
        }

        public void Update()
        {
            _npc.transform.position = Vector3.MoveTowards(
                _npc.transform.position,
                _target.position,
                _npc.Config.MovingStateConfig.Speed * Time.deltaTime
            );

            if (Vector3.Distance(_npc.transform.position, _target.position) < 0.001f)
            {
                _switch();
            }
        }

        private void OnWorkStated()
        {
            _switch = () => { _stateSwitcher.SwitchState<WorkingState>(); };
        }

        private void OnSleepStated()
        {
            _switch = () => { _stateSwitcher.SwitchState<SleepingState>(); };
        }
    }
}