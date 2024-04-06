using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _enemiesPool;
    [SerializeField] private ObjectPool _bulletsPool;
    [SerializeField] private ObjectPool _explosionsPool;
    [SerializeField] private ScoreCounter _counter;

    public void Spawn()
    {
        GameObject spawnedEnemy = _enemiesPool.GetObject();
        Shooter shooter = spawnedEnemy.GetComponent<Shooter>();
        Enemy enemy = shooter.GetComponent<Enemy>();
        spawnedEnemy.transform.position = transform.position;
        spawnedEnemy.SetActive(true);
        shooter.SetPool(_bulletsPool);
        enemy.SetCounter(_counter);
        enemy.SetPools(_enemiesPool, _explosionsPool);
    }
}
