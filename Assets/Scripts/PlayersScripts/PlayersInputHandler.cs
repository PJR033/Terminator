using System;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class PlayersInputHandler : MonoBehaviour
{
    private Shooter _playersShooter;

    public event Action MoveStarted;

    private void Awake()
    {
        _playersShooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveStarted?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(_playersShooter.Shooting());
        }
    }
}