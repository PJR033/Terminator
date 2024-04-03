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

    private void Update()
    {
        if (_isCanChoose)
        {
            StartCoroutine(Choose());
        }
    }

    private IEnumerator Choose()
    {
        _isCanChoose = false;
        EnemySpawner current = _spawners[Random.Range(0, _spawners.Length)];
        current.Spawn();
        yield return _delay;
        _isCanChoose = true;
    }
}
