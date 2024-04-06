using System.Collections;
using UnityEngine;

public class SpawnerChooser : MonoBehaviour
{
    [SerializeField] private float _spawnTime;

    private EnemySpawner[] _spawners;
    private WaitForSeconds _delay;
    private bool _isCanChoose = true;

    private void Awake()
    {
        _spawners = GetComponentsInChildren<EnemySpawner>();
        _delay = new WaitForSeconds(_spawnTime);
    }

    private void Start()
    {
        StartCoroutine(Choosing());
    }

    private IEnumerator Choosing()
    {
        while (_isCanChoose && _spawners.Length > 0)
        {
            EnemySpawner choosenSpawner = _spawners[Random.Range(0, _spawners.Length)];
            choosenSpawner.Spawn();
            yield return _delay;
        }
    }
}
