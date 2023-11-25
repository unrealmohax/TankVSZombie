using System.Collections.Generic;

public sealed class TransportSwitchLargeWeaponState : TransportMovementState
{
    private IReadOnlyList<WeaponConfig> configs;

    internal TransportSwitchLargeWeaponState(ITransportStateSwitcher stateSwitcher, Tank tank) : base(stateSwitcher, tank) =>
        configs = tank.Config.WeaponConfigs;

    public override void Enter()
    {
        base.Enter();
        Data.Weapon = new Weapon(configs[1]);
    }

    public override void Update()
    {
        base.Update();

        if (IsHPZero())
        {
            StateSwitcher.SwitchState<TransportDestroyState>();
            return;
        }

        if (IsInputZero())
        {
            StateSwitcher.SwitchState<TransportIdlingState>();
        }
        else
        {
            StateSwitcher.SwitchState<VehicleMovementState>();
        }
    }
}
