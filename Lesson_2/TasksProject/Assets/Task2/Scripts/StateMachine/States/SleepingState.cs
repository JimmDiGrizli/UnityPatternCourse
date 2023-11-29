namespace Task2.Scripts.StateMachine.States
{
    public class SleepingState : ActionState
    {
        public SleepingState(IStateSwitcher stateSwitcher, NpcStateMachineData data, Npc npc) :
            base(stateSwitcher, data, npc)
        {
        }

        public override void Enter() => _expectedTime = _npc.Config.SleepingStateConfig.Time;
        
        protected override void OnTimeEnd()
        {
            _data.NextPosition = _npc.WorkZone;
            _stateSwitcher.SwitchState<MovingState>();
        }
    }
}