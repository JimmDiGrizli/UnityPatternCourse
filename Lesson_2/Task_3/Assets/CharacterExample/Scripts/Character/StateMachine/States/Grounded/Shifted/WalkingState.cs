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

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        Input.Movement.BoostMove.started += OnBoostMoveKeyPressed;

        Input.Movement.SlowDownMove.canceled += OnSlowDownMoveKeyCanceled;
    }

    protected override void RemoveInputActionsCallback()
    {
        base.RemoveInputActionsCallback();

        Input.Movement.BoostMove.started -= OnBoostMoveKeyPressed;

        Input.Movement.SlowDownMove.canceled -= OnSlowDownMoveKeyCanceled;
    }

    private void OnBoostMoveKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<BoostRunningState>();

    private void OnSlowDownMoveKeyCanceled(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<RunningState>();
}
