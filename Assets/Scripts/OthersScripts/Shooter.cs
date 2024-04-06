using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _speedForce;

    private bool _isCanShoot;
    private Rigidbody2D _rigidbody;
    private WaitForSeconds _delay;

    public event Action IsShoot;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _delay = new WaitForSeconds(_shootDelay);
    }

    private void OnEnable()
    {
        _isCanShoot = true;
    }

    public void SetPool(ObjectPool pool)
    {
        _pool = pool;
    }

    public IEnumerator Shooting()
    {
        Rigidbody2D bulletRigidbody;

        if(_isCanShoot)
        {
            IsShoot?.Invoke();
            var bullet = _pool.GetObject();
            bullet.SetActive(true);
            bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.position = _shootPoint.position;
            bullet.transform.rotation = _shootPoint.rotation;
            bulletRigidbody.velocity = (bulletRigidbody.transform.position - _rigidbody.transform.position).normalized * _speedForce;
            _isCanShoot = false;
            yield return _delay;
            _isCanShoot = true;
        }
    }
}
