using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(CollisionHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private ScoreCounter _counter;
    [SerializeField] private ObjectPool _explosionsPool;

    private CollisionHandler _handler;

    private void Awake()
    {
        _handler = GetComponent<CollisionHandler>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += OnCollisionDetected;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= OnCollisionDetected;
    }

    private void OnCollisionDetected()
    {
        GameObject createdExplosion = _explosionsPool.GetObject();
        Explosion explosion = createdExplosion.GetComponent<Explosion>();
        explosion.SetPool(_explosionsPool);
        createdExplosion.transform.position = transform.position;
        createdExplosion.SetActive(true);
        gameObject.SetActive(false);
    }
}
