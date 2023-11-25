public interface ITransportStateSwitcher
{
    void SwitchState<State>() where State : ITransportState;
}