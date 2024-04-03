using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent (typeof(Rigidbody2D))]
public class EnemyShooter : Shooter
{
    public event Action IsShoot;

    private Rigidbody2D _rigidbody;
    private WaitForSeconds _delay;
    private ObjectPool _pool;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _delay = new WaitForSeconds(ShootDelay);
    }

    private void OnEnable()
    {
        IsCanShoot = true;
    }

    private void Update()
    {
        if (IsCanShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    protected override IEnumerator Shoot()
    {
        IsShoot?.Invoke();
        var bullet = CreateBullet(_pool, _rigidbody);
        IsCanShoot = false;
        yield return _delay;
        IsCanShoot = true;
    }

    public void SetPool(ObjectPool pool)
    {
        _pool = pool;
    }
}
