using UnityEngine;

public class PlayerDestroyer : MonoBehaviour
{
    private Player _player;
    private PlayerMover _mover;
    private PlayersShooter _shooter;
    private Collider2D _collider;
    private Rigidbody2D _body;
    private CollisionHandler _handler;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _mover = GetComponent<PlayerMover>();
        _shooter = GetComponent<PlayersShooter>();
        _collider = GetComponent<Collider2D>();
        _body = GetComponent<Rigidbody2D>();
        _handler = GetComponent<CollisionHandler>();
    }

    private void DestroyComponents()
    {
        Destroy(_shooter);
        Destroy(_collider);
        Destroy(_player);
        Destroy(_mover);
        Destroy(_handler);
        Destroy(_body);
    }

    private void KillPlayer()
    {
        Destroy(gameObject);
    }
}
