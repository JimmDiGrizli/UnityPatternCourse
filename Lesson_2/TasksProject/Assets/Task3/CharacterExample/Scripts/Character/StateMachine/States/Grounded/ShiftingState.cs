using UnityEngine.InputSystem;

public class ShiftingState : GroundedState
{
    public ShiftingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        View.StartRunning();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
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