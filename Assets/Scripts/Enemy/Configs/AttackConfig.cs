using System;
using UnityEngine;

[Serializable]
public class AttackConfig
{
    [SerializeField, Range(0, 10)] private float _damage;

    public float Damage => _damage;
}