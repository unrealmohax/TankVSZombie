using UnityEngine;

public interface IWeapon
{
    GameObject ShellPrefab { get; }
    float ShellSpeed { get; }
    float ShellDamage { get; }
    float TankFireRate { get; }
    WeaponType Type { get; }
}