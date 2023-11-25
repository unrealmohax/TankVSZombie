using System;
using UnityEngine;

public class TransportMovementState : ITransportState
{
    protected readonly ITransportStateSwitcher StateSwitcher;
    protected readonly TankData Data;
    private readonly Tank _tank;

    public TransportMovementState(ITransportStateSwitcher stateSwitcher, Tank tank)
    {
        StateSwitcher = stateSwitcher;
        Data = tank.Data;
        Data.Weapon = new Weapon(tank.Config.WeaponConfigs[0]);
        _tank = tank;
    }

    protected Rigidbody Rigidbody => _tank.Rigidbody;
    protected TankView View => _tank.View;
    protected Transform Transform => _tank.Transform;
    protected Transform Tower => _tank.Tower;

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void HandleInput()
    {
        Data.InputMovement = ReadMovingInput();
        Data.InputRotation = ReadRotationInput();
        Data.InputRotationTower = ReadRotationTowerInput();

        if (ReadFireInput() && ShootReady()) 
        {
            Data.Time = 0;
            _tank.Shoot(Data.Weapon);
        }
    }

    public virtual void Update()
    {
        Data.Time += Time.deltaTime;
        Vector3 velocity = GetConvertedVecloity();

        Movement(velocity);
        Rotation();
        RotationTower();
    }

    protected bool IsHPZero() => Data.Health == 0;
    protected bool IsInputZero() => Data.InputMovement == 0 && Data.InputRotation == 0 && Data.InputRotationTower == 0;
    protected bool IsWeaponSmall() => ReadSwitchWeaponSmallInput();
    protected bool IsWeaponLarge() => ReadSwitchWeaponLargeInput();
    protected bool ShootReady() => (1 / Data.Weapon.TankFireRate) <= Data.Time;
    

    private Vector3 GetConvertedVecloity() => Data.Velocity * Vector3.forward;

    private void Movement(Vector3 velocity) 
    {
        
        Rigidbody.velocity = Transform.TransformDirection(velocity);
    }

    private void Rotation()
    {
        Transform.Rotate(Vector3.up, Data.VelocityRotation * Time.deltaTime);
    }

    private void RotationTower()
    {
        Tower.Rotate(Vector3.up, Data.VelocityRotationTower * Time.deltaTime);
    }

    private float ReadMovingInput()
    {
        return Input.GetAxis("Horizontal");
    }

    private float ReadRotationInput()
    {
        return Input.GetAxis("Vertical");
    }

    private float ReadRotationTowerInput()
    {
        return Input.GetAxis("HorizontalTower");
    }

    private bool ReadSwitchWeaponSmallInput()
    {
        return Input.GetButton("WeaponSmall");
    }

    private bool ReadSwitchWeaponLargeInput()
    {
        return Input.GetButton("WeaponLarge");
    }

    private bool ReadFireInput()
    {
        return Input.GetButton("Fire");
    }
}