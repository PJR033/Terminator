using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(ObjectPool))]
public class BackgroundGenerator : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    private ObjectPool _pool;

    private void Awake()
    {
        _pool = GetComponent<ObjectPool>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.TryGetComponent(out BackgroundObject background))
        {
            _pool.PutObject(background.gameObject);
            Spawn();
        }
    }

    private void Spawn()
    {
        float xOffset = 16.31f;
        var background = _pool.GetObject();
        background.SetActive(true);
        background.transform.position = _spawnPoint.position;
        _spawnPoint.position = new Vector3(_spawnPoint.position.x + xOffset, _spawnPoint.position.y, _spawnPoint.position.z);
    }
}
