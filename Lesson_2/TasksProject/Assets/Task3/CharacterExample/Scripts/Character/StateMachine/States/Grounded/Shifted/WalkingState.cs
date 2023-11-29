using UnityEngine.InputSystem;

public class WalkingState : ShiftingState
{
    private readonly WalkingStateConfig _config;

    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RunningStateConfig.WalkingStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed *= _config.SpeedRate;
    }
}
