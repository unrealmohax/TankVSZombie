using System.Collections.Generic;
using System.Linq;

public class EnemyStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public EnemyStateMachine(Enemy enemy)
    {
        _states = new List<IState>()
        {
            new IdlingState(this, enemy),
            new RunningState(this, enemy),
            new WalkingState(this, enemy),
            new DyingState(this, enemy),
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<State>() where State : IState
    {
        IState state = _states.FirstOrDefault(state => state is State);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void HandleInput() => _currentState.HandleInput();

    public void Update() => _currentState.Update();
}