using TMPro;
using UnityEngine;

[RequireComponent(typeof(ScoreCounter))]
public class ScoreViewer : MonoBehaviour
{
    private ScoreCounter _counter;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _counter = GetComponent<ScoreCounter>();
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _counter.ScoreChanged += ShowScore;
    }

    private void OnDisable()
    {
        _counter.ScoreChanged -= ShowScore;
    }

    private void ShowScore()
    {
        string currentScore = _counter.ScoreCount.ToString();
        _text.text = "Score: " + currentScore;
    }
}
