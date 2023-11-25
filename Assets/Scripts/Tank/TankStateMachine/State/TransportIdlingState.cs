public sealed class TransportIdlingState : TransportMovementState
{
    internal TransportIdlingState(ITransportStateSwitcher stateSwitcher, Tank tank) : base(stateSwitcher, tank)
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

        if (IsHPZero()) 
        {
            StateSwitcher.SwitchState<TransportDestroyState>();
            return;
        }

        if (IsWeaponSmall()) 
        { 
            StateSwitcher.SwitchState<TransportSwitchSmallWeaponState>(); 
        }

        if (IsWeaponLarge())
        {
            StateSwitcher.SwitchState<TransportSwitchLargeWeaponState>();
        }

        if (IsInputZero())
            return;

        StateSwitcher.SwitchState<VehicleMovementState>();
    }
}