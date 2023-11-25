public class DyingState : MovementState
{
    public DyingState(IStateSwitcher stateSwitcher, Enemy enemy) : base(stateSwitcher, enemy) 
    {
    }

    public override void Enter()
    {
        base.Enter();

        View.StartDieing();
        Data.Speed = 0;

        Die();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopDieing();
    }
}