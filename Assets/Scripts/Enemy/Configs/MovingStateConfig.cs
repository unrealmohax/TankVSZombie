using System;
using UnityEngine;

[Serializable]
public class MovingStateConfig
{
    [SerializeField, Range(0, 10)] private float _walkingSpeed;
    [SerializeField, Range(0, 50)] private float _runningSpeed;

    public float WalkingSpeed => _walkingSpeed;
    public float RunningSpeed => _runningSpeed;
}