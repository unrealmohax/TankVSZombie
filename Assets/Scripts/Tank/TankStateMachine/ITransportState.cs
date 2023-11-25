public interface ITransportState
{
    void Enter();
    void Exit();
    void HandleInput();
    void Update();
}