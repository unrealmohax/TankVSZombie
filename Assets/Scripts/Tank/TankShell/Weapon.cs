using UnityEngine;

public struct Weapon : IWeapon
{
    private GameObject _prefab;
    private float _shellSpeed;
    private float _shellDamage;
    private float _tankFireRate;
    private WeaponType _type;

    public Weapon(WeaponConfig config)
    {
        _prefab = config.ShellPrefab;
        _shellSpeed = config.ShellSpeed;
        _shellDamage = config.ShellDamage;
        _tankFireRate = config.TankFireRate;
        _type = config.Type;
    }

    public GameObject ShellPrefab => _prefab;

    public float ShellSpeed => _shellSpeed;
    public float ShellDamage => _shellDamage;
    public float TankFireRate => _tankFireRate;
    public WeaponType Type => _type;
}

public enum WeaponType 
{
    Small,
    Large,
}