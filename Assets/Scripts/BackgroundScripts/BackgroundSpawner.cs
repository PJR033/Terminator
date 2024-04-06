using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
[RequireComponent (typeof(BackgroundDetector))]
public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    private ObjectPool _pool;
    private BackgroundDetector _detector;

    private void Awake()
    {
        _pool = GetComponent<ObjectPool>();
        _detector = GetComponent<BackgroundDetector>();
    }

    private void OnEnable()
    {
        _detector.BackgroundOut += Spawn;
    }

    private void OnDisable()
    {
        _detector.BackgroundOut -= Spawn;
    }

    private void Spawn(BackgroundObject disabledBackground)
    {
        float xOffset = 16.31f;

        _pool.PutObject(disabledBackground.gameObject);
        GameObject spawnedBackground = _pool.GetObject();
        spawnedBackground.SetActive(true);
        spawnedBackground.transform.position = _spawnPoint.position;
        _spawnPoint.position = new Vector3(_spawnPoint.position.x + xOffset, _spawnPoint.position.y, _spawnPoint.position.z);
    }
}
