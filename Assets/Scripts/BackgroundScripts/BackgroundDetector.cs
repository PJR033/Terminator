using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BackgroundDetector : MonoBehaviour
{
    public event Action<BackgroundObject> BackgroundOut;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out BackgroundObject background))
        {
            BackgroundOut?.Invoke(background);
        }
    }
}
