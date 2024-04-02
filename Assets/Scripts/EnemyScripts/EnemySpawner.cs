using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _enemiesPool;
    [SerializeField] private ObjectPool _bulletsPool;
    [SerializeField] private ScoreCounter _counter;

    public void Spawn()
    {
        var spawnedEnemy = _enemiesPool.GetObject();
        EnemyShooter shooter = spawnedEnemy.GetComponent<EnemyShooter>();
        Enemy enemy = shooter.GetComponent<Enemy>();
        spawnedEnemy.transform.position = transform.position;
        spawnedEnemy.SetActive(true);
        shooter.SetPool(_bulletsPool);
        enemy.SetCounter(_counter);
    }
}
