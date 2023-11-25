using System;

public class EnemyData
{
    private float _heath;
    private float _defence;
    private float _damage;
    private float _speed;

    public EnemyData(EnemyConfig config)
    {
        _heath = config.DefenseHealthConfig.Health;
        _defence = config.DefenseHealthConfig.Defense;
        _damage = config.AttackConfig.Damage;
    }

    public float Speed
    {
        get => _speed;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _speed = value;
        }
    }

    public float Health
    {
        get => _heath;
        set
        {
            if (value < 0)
               value = 0;

            _heath = value;
        }
    }

    public float Defence => _defence;
    public float Damage => _damage;
}