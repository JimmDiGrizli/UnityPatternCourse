using UnityEngine.InputSystem;

public class BoostRunningState : ShiftingState
{
    private readonly BoostingRunningStateConfig _config;

    public BoostRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RunningStateConfig.BoostingRunningStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed *= _config.SpeedRate;
    }
}