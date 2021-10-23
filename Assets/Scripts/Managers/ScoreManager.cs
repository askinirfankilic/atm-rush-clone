using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoSingleton<ScoreManager>
{
    [SerializeField] private int _score;
    [SerializeField] private int _storedScore;

    public int Score => _score;
    public int StoredScore => _storedScore;

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

    private void StoreScore(int scoreFactor)
    {
        _storedScore += scoreFactor;
    }

    private void OnEnable()
    {
        EventManager.OnScoreIncrement += IncrementScore;
        EventManager.OnATMTrigger += StoreScore;
    }

    private void OnDisable()
    {
        EventManager.OnScoreIncrement -= IncrementScore;
        EventManager.OnATMTrigger -= StoreScore;
    }
}