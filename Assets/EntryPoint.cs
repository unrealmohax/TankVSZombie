using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject Tank;
    [SerializeField] private GameObject EnemySpawner;
    [SerializeField] private GameObject Camera;

    private void Start()
    {
        GameObject tank = Instantiate(Tank);
        GameObject enemySpawnerGO = Instantiate(EnemySpawner);
        var enemySpawner = enemySpawnerGO.GetComponent<EnemySpawner>();
        enemySpawner.SetTarget(tank.transform);

        var camera = Camera.AddComponent<CameraFollow>();
        camera.SetTarget(tank.transform);
    }
}
