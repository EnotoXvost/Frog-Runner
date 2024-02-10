using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int _currentScore = 0;
    [SerializeField] private int _maxScore = 0;

    private void Awake()
    {
        EventManager.onFrogDeleted.AddListener(Scoring);
    }
    private void Scoring()
    {
        _currentScore++;
    }

    public int CurrentScoreShare()
    {
        return _currentScore;
    }
}
