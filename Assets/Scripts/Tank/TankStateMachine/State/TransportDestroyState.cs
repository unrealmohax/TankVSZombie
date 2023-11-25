public class TransportDestroyState : TransportMovementState
{
    public TransportDestroyState(ITransportStateSwitcher stateSwitcher, Tank tank) : base(stateSwitcher, tank)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = 0;
        Data.RotationSpeed = 0;
        Data.RotationTowerSpeed = 0;
    }
}