using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class TankShell : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigibody;
    [SerializeField] private IWeapon _weapon;
    [SerializeField, Range(0, 30f)] private float _lifeTime = 15f;

    private void OnValidate()
    {
        _rigibody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigibody ??= GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out IDamageable damageable)) 
        {
            damageable.TakeDamage(_weapon.ShellDamage);
        }

        Destroy(gameObject);
    }
    internal void SetParametrs(IWeapon weapon)
    {
        _weapon = weapon;

        Initialized();
    }

    protected virtual void Initialized()
    {
        Vector3 initialVelocityVector = GetInitialVelocityVector();
        _rigibody.velocity = transform.TransformDirection(initialVelocityVector);
        StartCoroutine(DelayDestroy());
    }
    private IEnumerator DelayDestroy() 
    {
        yield return new WaitForSeconds(_lifeTime);

        Destroy(gameObject);
    }

    private Vector3 GetInitialVelocityVector()
    {
        // Calculate and return the velocity vector
        return Vector3.forward * _weapon.ShellSpeed;
    }
}
