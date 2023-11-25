using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [field : SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private int _enemyCount;
    [SerializeField] private Transform _target;
    [SerializeField, Range(0, 100f)] private float _radius = 1;

    private const float MIN_ANGLE_SPAWN = 0f;
    private const float MAX_ANGLE_SPAWN = 360f;
    private void Start()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            CreateEnemy();
        }
    }
    
    public void SetTarget(Transform target)
    {
        if (target == null) return;

        _target = target;
    }

    private void CreateEnemy() 
    {
        int randomIndex = Random.Range(0, _enemyPrefab.Length);

        Vector3 position = GetSpawnPosition();

        var enemyGO = Instantiate(_enemyPrefab[randomIndex], position, Quaternion.identity, transform);
        var enemy = enemyGO.GetComponent<IEnemy>();
        enemy?.SetTarget(_target);
        enemy.DeadEvent.AddListener(CreateEnemy);
    }

    private Vector3 GetSpawnPosition() 
    {
        float angle = Random.Range(MIN_ANGLE_SPAWN, MAX_ANGLE_SPAWN);
        float x = Mathf.Cos(Mathf.Deg2Rad * angle) * _radius;
        float z = Mathf.Sin(Mathf.Deg2Rad * angle) * _radius;

        Vector3 spawnPosition = new Vector3(x, 0f, z) + _target.position; 
        return spawnPosition;
    }
}
