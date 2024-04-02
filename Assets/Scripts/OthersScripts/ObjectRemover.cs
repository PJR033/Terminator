using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private int _layerNumber;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == _layerNumber)
        {
            _pool.PutObject(other.gameObject);
        }
    }
}
