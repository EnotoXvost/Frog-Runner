using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> _movementPosition = new List<Transform> ();
    [SerializeField] private int _currentPointPosition = 1;
    private Transform _currentTransform;
    private bool IsDead = false;

    private void Awake()
    {
        EventManager.onEndedHealth.AddListener(StopPlayerMovement);
    }
    private void Start()
    {
        transform.position = _movementPosition[_currentPointPosition].position;
        _currentTransform = transform;
    }

    private void Update()
    {
        MoveToPoint();
    }

    private void MoveToPoint()
    {
        if (!IsDead)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (_currentPointPosition + 1 > 2) return;
                DOTween.To(() => _currentTransform.position, pos => transform.position = pos, _movementPosition[_currentPointPosition + 1].position, 0.7f).Play();
                _currentTransform = transform;
                _currentPointPosition++;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (_currentPointPosition - 1 < 0) return;
                DOTween.To(() => _currentTransform.position, pos => transform.position = pos, _movementPosition[_currentPointPosition - 1].position, 0.7f).Play();
                _currentTransform = transform;
                _currentPointPosition--;
            }
        }
        else return;
    }

    private void StopPlayerMovement()
    {
        IsDead = true;
    }
}
