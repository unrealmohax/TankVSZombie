using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TankView : MonoBehaviour
{
    private const string IsIdling = "IsIdling";
    private const string IsMovement = "IsMovement";

    private Animator _animator;

    public void Initialize() => _animator = GetComponent<Animator>();

    public void StartIdling() => _animator.SetBool(IsIdling, true);
    public void StopIdling() => _animator.SetBool(IsIdling, false);

    public void StartMovement() => _animator.SetBool(IsMovement, true);
    public void StopMovement() => _animator.SetBool(IsMovement, false);
}