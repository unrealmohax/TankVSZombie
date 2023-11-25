public class VehicleMovementState : TransportMovementState
{
    private readonly TransportSpeedConfig _config;

    public VehicleMovementState(ITransportStateSwitcher stateSwitcher, Tank tank) : base(stateSwitcher, tank)
        => _config = tank.Config.TransportSpeedConfig;

    public override void Enter()
    {
        base.Enter();

        View.StartMovement();
        Data.Speed = _config.Speed;
        Data.RotationSpeed = _config.RotationSpeed;
        Data.RotationTowerSpeed = _config.RotationTowerSpeed;
    }

    public override void Exit()
    {
        base.Exit();

        View.StopMovement();
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
            StateSwitcher.SwitchState<TransportIdlingState>();
    }
}