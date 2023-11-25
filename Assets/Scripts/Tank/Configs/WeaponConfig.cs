using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Configs/Weapon Config")]
public class WeaponConfig : ScriptableObject
{
    [SerializeField] private GameObject _shellPrefab;
    [SerializeField] private float _shellSpeed;
    [SerializeField] private float _shellDamage;
    [SerializeField] private float _tankFireRate;
    [SerializeField] private WeaponType _type;

    public GameObject ShellPrefab => _shellPrefab;
    public float ShellSpeed => _shellSpeed;
    public float ShellDamage => _shellDamage;
    public float TankFireRate => _tankFireRate;
    public WeaponType Type => _type;
}

