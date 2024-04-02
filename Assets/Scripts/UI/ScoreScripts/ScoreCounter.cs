using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public event Action ScoreChanged;

    public int ScoreCount { get; private set; }

    public void IncreaseCount()
    {
        ScoreCount++;
        ScoreChanged?.Invoke();
    }
}
