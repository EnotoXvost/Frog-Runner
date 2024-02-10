using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class frogMovement : MonoBehaviour
{
    [SerializeField] private float _jumpPower;
    [SerializeField] private int _NumbJump;
    [SerializeField] private float _JumpDuration;

    private FrogDeleteFromScene _frogDeleteFromScene;
    private GameObject _gameController;
    private Score _score;

    private float _minJumpDuration = 3.5f;

    private void Awake()
    {
        _frogDeleteFromScene = GetComponent<FrogDeleteFromScene>();
        _gameController = GameObject.FindGameObjectWithTag("GameController");
        _score = _gameController.GetComponent<Score>();
    }
    private void Start()
    {
        FrogJump();
    }
    private void FrogJump()
    {
        var jumpDur = DurationFunction(_JumpDuration, _score.CurrentScoreShare());
        //Debug.Log("Jump duration: " + jumpDur);
        gameObject.transform.DOJump(new Vector3(transform.position.x, transform.position.y,_frogDeleteFromScene.DeletedZonePositionShare()),
                                    _jumpPower, _NumbJump, jumpDur).SetEase(Ease.Linear).Play();
    }

    private float DurationFunction(float currentJumpDur, int score)
    {
        var jumpDur = currentJumpDur - Mathf.Sqrt(score) / 5f;

        if (jumpDur > _minJumpDuration)
        {
            return jumpDur;
        }
        else
        {
            return _minJumpDuration;
        }
    }

}
