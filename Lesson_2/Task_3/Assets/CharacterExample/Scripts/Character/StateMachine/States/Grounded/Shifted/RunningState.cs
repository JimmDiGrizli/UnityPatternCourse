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

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        Input.Movement.BoostMove.started += OnBoostMoveKeyPressed;
        Input.Movement.BoostMove.canceled += OnBoostMoveKeyCanceled;

        Input.Movement.SlowDownMove.started += OnSlowDownMoveKeyPressed;
        Input.Movement.SlowDownMove.canceled += OnSlowDownMoveKeyCanceled;
    }

    protected override void RemoveInputActionsCallback()
    {
        base.RemoveInputActionsCallback();

        Input.Movement.BoostMove.started -= OnBoostMoveKeyPressed;
        Input.Movement.BoostMove.canceled -= OnBoostMoveKeyCanceled;

        Input.Movement.SlowDownMove.started -= OnSlowDownMoveKeyPressed;
        Input.Movement.SlowDownMove.canceled -= OnSlowDownMoveKeyCanceled;
    }

    private void OnBoostMoveKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<BoostRunningState>();

    private void OnBoostMoveKeyCanceled(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<RunningState>();

    private void OnSlowDownMoveKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<WalkingState>();

    private void OnSlowDownMoveKeyCanceled(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<RunningState>();
}
