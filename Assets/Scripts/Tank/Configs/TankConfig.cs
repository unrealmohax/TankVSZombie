using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankConfig", menuName = "Configs/Tank Config")]
public class TankConfig : ScriptableObject
{
    [SerializeField] private TransportSpeedConfig _transportSpeedConfig;
    [SerializeField] private DefenseHealthConfig _fightStateConfig;
    [SerializeField] private List<WeaponConfig> _weaponConfigs;

    public TransportSpeedConfig TransportSpeedConfig => _transportSpeedConfig;
    public DefenseHealthConfig FightStateConfig => _fightStateConfig;
    public IReadOnlyList<WeaponConfig> WeaponConfigs => _weaponConfigs;
}
