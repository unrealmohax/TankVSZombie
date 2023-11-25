public class WalkingState : MovementState
{
    private readonly MovingStateConfig _config;

    public WalkingState(IStateSwitcher stateSwitcher, Enemy enemy) : base(stateSwitcher, enemy)
        => _config = enemy.Config.MovingStateConfig;

    public override void Enter()
    {
        base.Enter();

        View.StartWalking();
        Data.Speed = _config.WalkingSpeed;
    }

    public override void Exit()
    {
        base.Exit();

        View.StopWalking();
    }

    public override void Update()
    {
        base.Update();

        if (IsInputZero())
            StateSwitcher.SwitchState<IdlingState>();

        if (IsLowHP())
        {
            StateSwitcher.SwitchState<RunningState>();
        }

        if (IsHPZero())
        {
            StateSwitcher.SwitchState<DyingState>();
        }
    }
}