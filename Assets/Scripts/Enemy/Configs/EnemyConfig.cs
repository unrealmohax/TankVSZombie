using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private MovingStateConfig _movingStateConfig;
    [SerializeField] private DefenseHealthConfig _defenseHealthConfig;
    [SerializeField] private AttackConfig _attackConfig;

    public MovingStateConfig MovingStateConfig => _movingStateConfig;
    public DefenseHealthConfig DefenseHealthConfig => _defenseHealthConfig;
    public AttackConfig AttackConfig => _attackConfig;
}
