using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Shooter))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private int _playersBulletLayer = 8;
    private Rigidbody2D _rigidbody;
    private ScoreCounter _scoreCounter;
    private ObjectPool _enemiesPool;
    private ObjectPool _explosionsPool;
    private Shooter _enemyShooter;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyShooter = GetComponent<Shooter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _playersBulletLayer)
        {
            Destroy(collision.gameObject);
            _enemiesPool.PutObject(gameObject);
            GameObject createdExplosion = _explosionsPool.GetObject();
            Explosion explosion = createdExplosion.GetComponent<Explosion>();
            explosion.SetPool(_explosionsPool);
            createdExplosion.SetActive(true);
            createdExplosion.transform.position = transform.position;
            _scoreCounter.IncreaseCount();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        StartCoroutine(_enemyShooter.Shooting());
    }

    public void SetPools(ObjectPool enemiesPool, ObjectPool explosionsPool)
    {
        _enemiesPool = enemiesPool;
        _explosionsPool = explosionsPool;
    }

    public void SetCounter(ScoreCounter counter)
    {
        _scoreCounter = counter;
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_speed, 0);
    }
}