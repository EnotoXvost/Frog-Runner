using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FroggSpawner : MonoBehaviour
{
    private enum FrogColor
    {
        green,
        blue,
        red
    }

    [SerializeField] private List<GameObject> _frogPrefabs = new List<GameObject>();
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    [SerializeField] private float _startTimeBetweenSpawn = 0f;
    private float _timeBetweenSpawn = 0f;

    private GameObject _frogType;
    private GameObject _gameController;
    private Score _score;

    private float _minTimeBetweenSpawn = 0.2f;

    private void Awake()
    {
        EventManager.onEndedHealth.AddListener(StopSpawn);
        _gameController = GameObject.FindGameObjectWithTag("GameController");
        _score = _gameController.GetComponent<Score>();
    }
    private void Start()
    {
        _frogType = _frogPrefabs[(int)FrogColor.green];
       _timeBetweenSpawn = _startTimeBetweenSpawn;
    }
    private void Update()
    {
        FrogSpawn();
        ChangeFrogType(_score.CurrentScoreShare());
    }

    private void FrogSpawn()
    {
        var startTimeBtwSpawn = TimeBetweenSpawnFunction(_startTimeBetweenSpawn, _score.CurrentScoreShare());
        //Debug.Log("Frog spawn rate: " + startTimeBtwSpawn);
        if (_timeBetweenSpawn < 0)
        {
            Instantiate(_frogType, _spawnPoints[Random.Range(0, 3)].position, Quaternion.Euler(0, -180, 0));
            _timeBetweenSpawn = startTimeBtwSpawn;
        }
        else
        {
            _timeBetweenSpawn -= Time.deltaTime;
        }       
    }

    private void ChangeFrogType(int score)
    {
        switch (score)
        {
            case 50:
                _frogType = _frogPrefabs[(int)FrogColor.blue];
                break;
            case 100:
                _frogType = _frogPrefabs[(int)FrogColor.red];
                break;
        }
    }
    private void StopSpawn()
    {
        _timeBetweenSpawn = 0;
    }

    private float TimeBetweenSpawnFunction(float curStartTimeBtwSpawn, int score)
    {
        var timeBtwSpawn = curStartTimeBtwSpawn - Mathf.Sqrt(score) / 20f;

        if (timeBtwSpawn > _minTimeBetweenSpawn)
        {
            return timeBtwSpawn;
        }
        else
        {
            return _minTimeBetweenSpawn;
        }
    }
}
