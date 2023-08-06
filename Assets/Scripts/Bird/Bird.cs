using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private int _score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    public int Score => _score;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
        _mover.enabled = false;
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void ResetBird()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _mover.enabled = true;
        _mover.ResetBird();
    }

    public void Die()
    {
        _mover.enabled = false;
        GameOver?.Invoke();
    }
}
