public class RunningState : MovementState
{
    private readonly MovingStateConfig _config;

    public RunningState(IStateSwitcher stateSwitcher, Enemy enemy) : base(stateSwitcher, enemy)
        => _config = enemy.Config.MovingStateConfig;

    public override void Enter()
    {
        base.Enter();

        View.StartRunning();
        Data.Speed = _config.RunningSpeed;
    }

    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (IsInputZero())
            StateSwitcher.SwitchState<IdlingState>();

        if (IsHPZero())
        {
            StateSwitcher.SwitchState<DyingState>();
        }
    }
}