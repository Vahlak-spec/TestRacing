using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafikController : SpeedTaker
{
    [SerializeField] private Transform[] _posibsSpawnPoints;
    [SerializeField] private Obstacle[] _obstacles;
    [SerializeField] private float _destroyDistance;
    [Space]
    [SerializeField] private float _minSpawenTime;
    [SerializeField] private float _maxSpawenTime;

    private Coroutine _procces;
    private float _waitTime;

    public override void Launch()
    {
        foreach (var item in _obstacles)
        {
            item.Hide();
        }
        Play();
    }
    public override void SetSpeed(float speed)
    {
        base.SetSpeed(speed);
        foreach (var item in _obstacles)
        {
            if (!item.IsHide) item.SetSpeed(speed);
        }
    }

    public override void Play()
    {
        Debug.Log("Play");
        _procces = StartCoroutine(Procces());

        foreach (var item in _obstacles)
        {
            item.SetSpeed(_speed);
        }
    }

    public override void Stop()
    {
        if (_procces != null)
            StopCoroutine(_procces);

        foreach (var item in _obstacles)
        {
            item.SetSpeed(0);
        }
    }
    private IEnumerator Procces()
    {
        while (true)
        {
            if (_waitTime <= 0)
            {
                _waitTime = Random.Range(_minSpawenTime, _maxSpawenTime);
                Debug.Log("WT - " + _waitTime);
                SummonSomeObstacle();
            }

            _waitTime -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    private void SummonSomeObstacle()
    {
        int i = Random.Range(0, _obstacles.Length);

        if (_obstacles[i].IsHide)
        {
            _obstacles[i].Summon(_posibsSpawnPoints[Random.Range(0, _posibsSpawnPoints.Length)].position, _destroyDistance);
            _obstacles[i].SetSpeed(_speed);
        }
        else
        {
            SummonSomeObstacle();
        }

    }
}
