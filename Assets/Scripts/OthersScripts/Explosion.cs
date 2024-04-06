using UnityEngine;

public class Explosion : MonoBehaviour
{
    private ObjectPool _explosionPool;

    public void SetPool(ObjectPool explosionPool)
    {
        _explosionPool = explosionPool;
    }

    private void PutExplosion()
    {
        _explosionPool.PutObject(gameObject);
    }
}
