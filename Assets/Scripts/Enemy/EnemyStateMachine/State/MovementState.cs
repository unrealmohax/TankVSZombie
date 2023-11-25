using UnityEngine;

public class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly EnemyData Data;
    private readonly Enemy _enemy;

    public MovementState(IStateSwitcher stateSwitcher, Enemy enemy)
    {
        StateSwitcher = stateSwitcher;
        Data = enemy.Data;
        _enemy = enemy;
    }


    protected Rigidbody Rigidbody => _enemy.Rigidbody;
    protected EnemyView View => _enemy.View;
    protected Transform Target => _enemy.Target;
    protected Transform Transform => _enemy.Transform;

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void HandleInput()
    {
    }

    public virtual void Update()
    {
        Vector3 direction;

        Movement(out direction);
        RotationFrom(direction);
    }

    protected bool IsInputZero() => GetDistance() < 1f;
    protected bool IsLowHP() => Data.Health < _enemy.Config.DefenseHealthConfig.Health * 0.2f;
    protected bool IsHPZero() => Data.Health == 0;
    protected void Die() => _enemy.Die();
    private void Movement(out Vector3 direction) 
    {
        direction = GetDirection();
        float distance = GetDistance();
        if (distance > 1) 
        {
            Rigidbody.Move(Rigidbody.position + direction.normalized * Data.Speed * Time.deltaTime, Quaternion.identity);
        }
    }

    private float GetDistance() 
    {
        if (Target == null) return 0;

        Vector2 targetPosition = new Vector2(Target.position.x, Target.position.z);
        Vector2 transformPosition = new Vector2(Transform.position.x, Transform.position.z);

        float distance = Vector2.Distance(transformPosition, targetPosition);
        distance = Mathf.Abs(distance);

        return distance;
    }

    private Vector3 GetDirection() 
    {
        if (Target == null) return Vector3.zero;

        float directionX = Target.position.x - Transform.position.x;
        float directionZ = Target.position.z - Transform.position.z;

        return new Vector3(directionX, 0, directionZ);
    }

    private void RotationFrom(Vector3 direction)
    {
        _enemy.Transform.LookAt(_enemy.Transform.position + direction);
    }
}