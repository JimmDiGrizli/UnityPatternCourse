using UnityEngine.InputSystem;

public class RunningState : ShiftingState
{
    private readonly RunningStateConfig _config;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RunningStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.Speed;

        if (Input.Movement.BoostMove.IsPressed()) StateSwitcher.SwitchState<BoostRunningState>();
        if (Input.Movement.SlowDownMove.IsPressed()) StateSwitcher.SwitchState<WalkingState>();
    }
}
