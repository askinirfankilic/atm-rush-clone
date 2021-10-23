using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreText : MonoBehaviour
{
    [SerializeField] private string _scoreText;

    private Text _scoreTextComponent;
    // Start is called before the first frame update
    void Start()
    {
        _scoreTextComponent = GetComponent<Text>(); 
        _scoreText = "0";
        _scoreTextComponent.text = _scoreText;
    }

    void UpdateScoreText()
    {
        _scoreText = ScoreManager.Instance.Score.ToString();
        _scoreTextComponent.text = _scoreText;
    }

    private void OnEnable()
    {
        EventManager.OnScoreChange += UpdateScoreText;
    }

    private void OnDisable()
    {
        EventManager.OnScoreChange -= UpdateScoreText;

    }
}
