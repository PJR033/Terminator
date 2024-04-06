using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayersInputHandler))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Rigidbody2D _rigidbody2D;
    private PlayersInputHandler _inputHandler;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private bool _isCanMove;

    private void Awake()
    {
        _inputHandler = GetComponent<PlayersInputHandler>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void OnEnable()
    {
        _inputHandler.MoveStarted += SetMoveBoolean;
    }

    private void OnDisable()
    {
        _inputHandler.MoveStarted -= SetMoveBoolean;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_isCanMove)
        {
            _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        _isCanMove = false;
    }

    private void SetMoveBoolean()
    {
        _isCanMove = true;
    }
}
