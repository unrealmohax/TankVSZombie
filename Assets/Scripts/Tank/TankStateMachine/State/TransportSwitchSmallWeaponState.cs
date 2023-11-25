using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

public sealed class TransportSwitchSmallWeaponState : TransportMovementState
{
    private IReadOnlyList<WeaponConfig> configs;

    internal TransportSwitchSmallWeaponState(ITransportStateSwitcher stateSwitcher, Tank tank) : base(stateSwitcher, tank) =>
        configs = tank.Config.WeaponConfigs;

    public override void Enter()
    {
        base.Enter();
        
       Data.Weapon = new Weapon(configs[0]);
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