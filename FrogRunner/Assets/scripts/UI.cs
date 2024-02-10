using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Image[] _heartsImage;
    [SerializeField] private Sprite _fullHearts;
    [SerializeField] private Sprite _emptyHearts;
    [SerializeField] private GameObject _playerGameObject;

    private int _health = 0;

    private Player _player = null;
    private Score _score;

    private void Awake()
    {
        EventManager.onPlayerTakedDamage.AddListener(TakeAwayHearth);
        _player = _playerGameObject.GetComponent<Player>();     
        _score = GetComponent<Score>();
    }
    private void Update()
    {
        OutputCurrentScore();
        _health = _player.HealthShare();
    }
    private void OutputCurrentScore()
    {
        _scoreText.text = "Score: " + _score.CurrentScoreShare();
    }

    private void TakeAwayHearth()
    {
        for (int i = 0; i < _heartsImage.Length; i++)
        {
            if (i < _health - 1)
                _heartsImage[i].sprite = _fullHearts;
            else
                _heartsImage[i].sprite = _emptyHearts;
        }
    }
}
