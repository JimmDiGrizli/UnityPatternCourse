namespace Task2.Scripts.StateMachine.States
{
    public class WorkingState : ActionState
    {
        public WorkingState(IStateSwitcher stateSwitcher, NpcStateMachineData data, Npc npc) :
            base(stateSwitcher, data, npc)
        {
        }

        public override void Enter() => _expectedTime = _npc.Config.WorkingStateConfig.Time;

        protected override void OnTimeEnd()
        {
            _data.NextPosition = _npc.SleepZone;
            _stateSwitcher.SwitchState<MovingState>();
        }
    }
}