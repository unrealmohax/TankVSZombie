using System.Collections.Generic;
using System.Linq;

public class TankStateMachine : ITransportStateSwitcher
{
    private List<ITransportState> _states;
    private ITransportState _currentState;

    public TankStateMachine(Tank tank)
    {
        _states = new List<ITransportState>()
        {
            new TransportIdlingState(this, tank),
            new VehicleMovementState(this, tank),
            new TransportSwitchSmallWeaponState(this, tank),
            new TransportSwitchLargeWeaponState(this, tank),
            new TransportDestroyState(this, tank),
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<State>() where State : ITransportState
    {
        ITransportState state = _states.FirstOrDefault(state => state is State);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void HandleInput() => _currentState.HandleInput();

    public void Update() => _currentState.Update();
}