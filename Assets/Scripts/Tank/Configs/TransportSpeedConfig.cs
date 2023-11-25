using System;
using UnityEngine;

[Serializable]
public class TransportSpeedConfig
{
    [SerializeField, Range(0, 10)] private float _speed;
    [SerializeField, Range(0, 500)] private float _rotationSpeed;
    [SerializeField, Range(0, 500)] private float _rotationTowerSpeed;

    public float Speed => _speed;
    public float RotationSpeed => _rotationSpeed;
    public float RotationTowerSpeed => _rotationTowerSpeed;
}