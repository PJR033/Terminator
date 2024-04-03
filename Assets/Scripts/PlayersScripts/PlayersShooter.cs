using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayersShooter : Shooter
{
    [SerializeField] private ObjectPool _pool;

    public event Action IsShoot;

    private Rigidbody2D _rigidbody;
    private WaitForSeconds _delay;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _delay = new WaitForSeconds(ShootDelay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsCanShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    protected override IEnumerator Shoot()
    {
        IsShoot?.Invoke();
        IsCanShoot = false;
        var bullet = CreateBullet(_pool, _rigidbody);
        bullet.transform.rotation = ShootPoint.rotation;
        yield return _delay;
        IsCanShoot = true;
    }
}
