using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(CollisionHandler))]
[RequireComponent (typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private ScoreCounter _counter;

    private int _isDead = Animator.StringToHash("isDead");
    private CollisionHandler _handler;
    private Animator _animator;

    private void Awake()
    {
        _handler = GetComponent<CollisionHandler>();
        _animator = GetComponent<Animator>();
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
        _animator.SetBool(_isDead, true);
    }
}
