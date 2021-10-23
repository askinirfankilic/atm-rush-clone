using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoSingleton<ScoreManager>
{
    [SerializeField] private int _score;

    public int Score => _score;

    private void Awake()
    {
        _score = 0;
    }

    private void IncrementScore(int score)
    {
        _score += score;
    }

    private void DecrementScore(int score)
    {
        _score -= score;
    }

    private void OnEnable()
    {
        EventManager.OnScoreIncrement += IncrementScore;
    }

    private void OnDisable()
    {
        EventManager.OnScoreIncrement -= IncrementScore;
    }
}