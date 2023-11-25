using System;
using UnityEngine;

[Serializable]
public class DefenseHealthConfig
{
    [SerializeField, Range(0, 1000)] private float _health;
    [SerializeField, Range(0, 10)] private float _defense;

    public float Health => _health;
    public float Defense => _defense;
}
