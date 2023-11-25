public sealed class IdlingState : MovementState
{
    internal IdlingState(IStateSwitcher stateSwitcher, Enemy enemy) : base(stateSwitcher, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        View.StartIdling();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopIdling();
    }

    public override void Update()
    {
        base.Update();

        if (IsInputZero())
            return;

        if (IsLowHP())
        {
            StateSwitcher.SwitchState<RunningState>();
        }
        else 
        {
            StateSwitcher.SwitchState<WalkingState>();
        }

        if (IsHPZero())
        {
            StateSwitcher.SwitchState<DyingState>();
        }
    }
}