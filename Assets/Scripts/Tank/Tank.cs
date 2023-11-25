using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(TankView))]
public class Tank : MonoBehaviour, IDamageable
{
    [SerializeField] private Transform _tower;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private TankView _view;
    [SerializeField] private TankConfig _config;
    [SerializeField] private Transform _spawnPointSmallWeapon;
    [SerializeField] private Transform _spawnPointLargeWeapon;

    private TankStateMachine _stateMachine;
    private TankData _data;

    public TankData Data => _data;
    public TankView View => _view;
    public TankConfig Config => _config;
    public Transform Transform => transform;
    public Rigidbody Rigidbody => _rigidbody;
    public Transform Tower => _tower;

    private void OnValidate()
    {
        _rigidbody = _rigidbody != null ? _rigidbody : GetComponent<Rigidbody>();
        _collider = _collider != null ? _collider : GetComponent<BoxCollider>();
        _view = _view != null ? _view : GetComponent<TankView>();
    }
    private void Awake()
    {
        _view.Initialize();
        _data = new TankData(_config);
        _stateMachine = new TankStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _data.Health -= damage * (1 / _data.Defence);
    }

    public void Shoot(IWeapon weapon)
    {
        Vector3 spawnpoint = GetSpawnPoint(weapon);

        GameObject shell = Instantiate(weapon.ShellPrefab, spawnpoint, _tower.rotation);
        TankShell tankShell = shell.GetComponent<TankShell>();

        tankShell.SetParametrs(weapon);

    }

    private Vector3 GetSpawnPoint(IWeapon weapon)
    {
        Vector3 spawnpoint = Vector3.zero;

        if (weapon.Type == WeaponType.Small)
            spawnpoint = _spawnPointSmallWeapon.position;

        if (weapon.Type == WeaponType.Large)
            spawnpoint = _spawnPointLargeWeapon.position;

        return spawnpoint;
    }
}