using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfinitGameState : GameStateBase
{
    public override GameState StateType => GameState.Game;

    [SerializeField] private SpeedTaker[] _speedTakers;
    [SerializeField] private CarController _carController;
    [SerializeField] private TriggerCollider _pointsCountCollider;
    [Space]
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _nextLevelTime;
    [SerializeField] private float _speedBustByLevel;
    [SerializeField] private float _maxSpeedLevel;
    [Space]
    [SerializeField] private PointsCounter _pointsCounter;
    [SerializeField] private Button _pauseButton;
    [Space]
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;

    private Coroutine _procces;
    private int _points;
    private int _tempSpeedLevel;
    private float _tempBustLevelTime;

    public override void Init(GameStateController controller)
    {
        base.Init(controller);
        _pointsCounter.Init();
        _leftButton.onClick.AddListener(_carController.ToLeft);
        _rightButton.onClick.AddListener(_carController.ToRight);
        _pauseButton.onClick.AddListener(() => _controller.LaunchState(GameState.Pause));

    }
    public override void ContinState()
    {
        foreach (var item in _speedTakers)
        {
            item.Play();
        }
        _carController.Play();
        _procces = StartCoroutine(Procces());
    }
    public override void StartState()
    {
        _points = 0;
        _pointsCounter.SetValue(0);
        _tempBustLevelTime = _nextLevelTime;
        _tempSpeedLevel = 0;
        foreach (var item in _speedTakers)
        {
            item.Launch();
            item.SetSpeed(_startSpeed);
        }
        _carController.Launch(Lose);
        _procces = StartCoroutine(Procces());
        _pointsCountCollider.SetAction<Obstacle>(() => 
        {
            _points++;
            _pointsCounter.SetValue(_points);
        });

    }
    public void Lose()
    {
        _controller.LaunchState(GameState.Lose);
    }
    public override void StopState()
    {
        foreach (var item in _speedTakers)
        {
            item.Stop();
        }
        _carController.Stop();
        if (_procces != null)
            StopCoroutine(_procces);
    }

    private IEnumerator Procces()
    {
        while (true) 
        {
            _tempBustLevelTime -= Time.deltaTime;

            if(_tempBustLevelTime <= 0)
            {
                _tempSpeedLevel = _tempSpeedLevel == _maxSpeedLevel ? _tempSpeedLevel : _tempSpeedLevel + 1;
                _tempBustLevelTime = _nextLevelTime;
                foreach (var item in _speedTakers)
                {
                    item.SetSpeed(_startSpeed + _tempSpeedLevel * _speedBustByLevel);
                }
            }

            yield return new WaitForFixedUpdate();
        }
    }
}
