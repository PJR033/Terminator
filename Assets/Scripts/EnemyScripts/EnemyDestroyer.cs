using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private Enemy _enemy;
    private EnemyShooter _shooter;
    private Collider2D _collider;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _shooter = GetComponent<EnemyShooter>();
        _collider = GetComponent<Collider2D>();
    }

    private void DestroyComponents()
    {
        Destroy(_shooter);
        Destroy(_enemy);
        Destroy(_collider);
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }
}
