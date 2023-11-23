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

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        Input.Movement.BoostMove.canceled += OnBoostMoveKeyCanceled;

        Input.Movement.SlowDownMove.started += OnSlowDownMoveKeyPressed;
    }

    protected override void RemoveInputActionsCallback()
    {
        base.RemoveInputActionsCallback();

        Input.Movement.BoostMove.canceled -= OnBoostMoveKeyCanceled;

        Input.Movement.SlowDownMove.started -= OnSlowDownMoveKeyPressed;
    }

    private void OnBoostMoveKeyCanceled(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<RunningState>();

    private void OnSlowDownMoveKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<WalkingState>();
}