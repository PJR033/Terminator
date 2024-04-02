using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Shooter : MonoBehaviour
{
    [SerializeField] protected Transform ShootPoint;
    [SerializeField] protected float ShootDelay;
    [SerializeField] protected float SpeedForce;

    protected bool IsCanShoot = true;

    protected abstract IEnumerator Shoot();

    protected GameObject CreateBullet(ObjectPool pool, Rigidbody2D rigidbody)
    {
        Rigidbody2D bulletRigidbody;

        var bullet = pool.GetObject();
        bullet.SetActive(true);
        bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bullet.transform.position = ShootPoint.position;
        bulletRigidbody.velocity = (bulletRigidbody.transform.position - rigidbody.transform.position).normalized * SpeedForce;

        return bullet;
    }
}
