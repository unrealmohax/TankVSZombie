using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(EnemyView))]
public class Enemy : MonoBehaviour, IEnemy, IDamageable
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private EnemyView _view;
    [SerializeField] private EnemyConfig _config;

    private EnemyStateMachine _stateMachine;
    private EnemyData _data;
    private Transform _target;
    private const float DelayTimeDead = 5;

    public UnityEvent DeadEvent { get; } =  new UnityEvent();

    public EnemyData Data => _data;
    public EnemyView View => _view;
    public EnemyConfig Config => _config;
    public Transform Transform => transform;
    public Rigidbody Rigidbody => _rigidbody;
    public Transform Target => _target;

    private void OnValidate()
    {
        _rigidbody = _rigidbody != null ? _rigidbody : GetComponent<Rigidbody>();
        _capsuleCollider = _capsuleCollider != null ? _capsuleCollider : GetComponent<CapsuleCollider>();
    }
    private void Awake()
    {
        _view.Initialize();
        _data = new EnemyData(Config);
        _stateMachine = new EnemyStateMachine(this);
        
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    private void Update()
    {
        _stateMachine.HandleInput();

        _stateMachine.Update();
    }

    public void SetTarget(Transform target)
    {
        if (target == null || _target != null) return;

        _target = target;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _data.Health -= damage * (1 / _data.Defence);
    }

    public void Die() 
    {
        StartCoroutine(DelayDieing());
    }

    private IEnumerator DelayDieing() 
    {
        yield return new WaitForSeconds(DelayTimeDead);

        EnemyDead();
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(Data.Damage);
            EnemyDead();
        }
    }

    private void EnemyDead()
    {
        DeadEvent.Invoke();
        Destroy(gameObject);
    }
}