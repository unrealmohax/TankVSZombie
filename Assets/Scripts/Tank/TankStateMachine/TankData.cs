using System;
using UnityEngine;

public class TankData
{
    private float _speed;
    private float _rotationSpeed;
    private float _rotationTowerSpeed;

    private float _inputMovement;
    private float _inputRotation;
    private float _inputRotationTower;

    private float _time;
    private float _heath;
    private float _defence;
    private Weapon _weapon;

    public TankData(TankConfig config)
    {
        _time = 0;
        _heath = config.FightStateConfig.Health;
        _defence = config.FightStateConfig.Defense;
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

    public float RotationSpeed
    {
        get => _rotationSpeed;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _rotationSpeed = value;
        }
    }

    public float RotationTowerSpeed
    {
        get => _rotationTowerSpeed;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _rotationTowerSpeed = value;
        }
    }

    public float InputMovement
    {
        get => _inputMovement;
        set
        {
            if (value < -1 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(value));

            _inputMovement = value;
        }
    }

    public float InputRotation
    {
        get => _inputRotation;
        set
        {
            if (value < -1 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(value));

            _inputRotation = value;
        }
    }

    public float InputRotationTower
    {
        get => _inputRotationTower;
        set
        {
            if (value < -1 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(value));

            _inputRotationTower = value;
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
    public float Time
    {
        get => _time;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _time = value;
        }
    }

    public Weapon Weapon
    {
        get => _weapon;
        set
        {
            _weapon = value;
        }
    }

    public float Defence => _defence;
    public float VelocityRotationTower => _inputRotationTower * _rotationTowerSpeed;
    public float VelocityRotation => _inputMovement * _rotationSpeed;
    public float Velocity => _inputRotation * _speed;

    
}