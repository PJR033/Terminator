using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    public event Action IsDead;

    private int _isDead = Animator.StringToHash("isDead");
    private int _playersBulletLayer = 8;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private ScoreCounter _scoreCounter;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _playersBulletLayer)
        {
            _animator.SetBool(_isDead, true);
            Destroy(collision.gameObject);
            IsDead?.Invoke();
            _scoreCounter.IncreaseCount();
        }
    }

    private void Update()
    {
        Move();
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