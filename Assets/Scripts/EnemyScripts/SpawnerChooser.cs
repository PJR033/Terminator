using UnityEngine;

public class SpawnerChooser : MonoBehaviour
{
    [SerializeField] private float _spawnTime;

    private EnemySpawner[] _spawners;
    private float _currentTime;

    private void Awake()
    {
        _spawners = GetComponentsInChildren<EnemySpawner>();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _spawnTime)
        {
            _currentTime = 0;
            Choose();
        }
    }

    private void Choose()
    {
        EnemySpawner current = _spawners[Random.Range(0, _spawners.Length)];
        current.Spawn();
    }
}
