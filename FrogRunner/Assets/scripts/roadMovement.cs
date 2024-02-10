using System.Collections.Generic;
using UnityEngine;

public class roadMovement : MonoBehaviour
{
    [SerializeField] private List<GameObject> _roadPrefabsFirstLVL = new List<GameObject>();
    [SerializeField] private List<GameObject> _roadPrefabsSecondLVL = new List<GameObject>();
    [SerializeField] private List<GameObject> _roadPrefabsThirdLVL = new List<GameObject>();
    [SerializeField] private float _maxSpeed;
    [SerializeField] private int _maxRoadCount;

    private List<GameObject> _roads = new List<GameObject>();

    private GameObject _gameController;
    private Score _score;

    private float _speed;

    private void Awake()
    {
        EventManager.onEndedHealth.AddListener(StopLevel);
        _gameController = GameObject.FindGameObjectWithTag("GameController");
        _score = _gameController.GetComponent<Score>();
    }
    private void Start()
    {
        ResetLevel();
        StartLevel();
    }
    private void Update()
    {
        if (_speed == 0) return;

        foreach (var road in _roads)
        {
            road.transform.position -= new Vector3(0, 0,_speed * Time.deltaTime);
        }

        DeleteRoad();
    }

    private void ResetLevel()
    {
        _speed = 0;
        while (_roads.Count > 0)
        {
            Destroy(_roads[0]);
            _roads.RemoveAt(0);
        }
        for (int i = 0; i < _maxRoadCount; i++)
        {
            CreateRoad();
        }
    }
    private void StartLevel()
    {
        _speed = _maxSpeed;
    }
    private void StopLevel()
    {
        _speed = 0;
    }
    private void DeleteRoad()
    {
        if (_roads[0].transform.position.z < -15)
        {
            Destroy(_roads[0]);
            _roads.RemoveAt(0);

            CreateRoad();
        }
    }
    private void CreateRoad()
    {
        Vector3 pos = Vector3.zero;
        if (_roads.Count > 0)
        {
            pos = _roads[_roads.Count - 1].transform.position + new Vector3(0, 0, 12);
        }
        GameObject go = Instantiate(ChooseRandomRoadPrefab(_score.CurrentScoreShare()), pos, Quaternion.identity);
        go.transform.SetParent(transform);
        _roads.Add(go);
    }

    private GameObject ChooseRandomRoadPrefab(int score)
    {
        var randomRoad = _roadPrefabsFirstLVL[Random.Range(0, _roadPrefabsFirstLVL.Count)];

        if (score >= 0 && score < 50)
        {
            randomRoad = _roadPrefabsFirstLVL[Random.Range(0, _roadPrefabsFirstLVL.Count)];
            Debug.Log("1 case");
        }

        if (score >= 50 && score < 100)
        {
            randomRoad = _roadPrefabsSecondLVL[Random.Range(0, _roadPrefabsSecondLVL.Count)];
            Debug.Log("2 case");
        }

        if (score >= 100)
        {
            randomRoad = _roadPrefabsThirdLVL[Random.Range(0, _roadPrefabsThirdLVL.Count)];
            Debug.Log("3 case");
        }

        return randomRoad;
    }

}
