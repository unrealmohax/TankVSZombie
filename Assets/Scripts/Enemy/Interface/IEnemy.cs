using UnityEngine;
using UnityEngine.Events;

internal interface IEnemy
{
    UnityEvent DeadEvent { get; }
    void SetTarget(Transform target);
}