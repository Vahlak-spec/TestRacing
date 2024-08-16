using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private GameObject _carTransform;
    [SerializeField] private TriggerCollider _collider;
    [Space]
    [SerializeField] private float[] _lines;
    [SerializeField] private float _changeLineTime;

    private int _tempLine;
    private bool _isChangeLanes;
    private Coroutine _CLProcces;


    public void Launch(Action onObstacleCollide)
    {
        _isChangeLanes = false;
        _tempLine = 0;
        _collider.SetAction<Obstacle>(onObstacleCollide);
        _carTransform.transform.position = new Vector3(_lines[_tempLine], _carTransform.transform.position.y, _carTransform.transform.position.z);
    }
    public void Play()
    {
        if(_isChangeLanes)
        _CLProcces = StartCoroutine(ChangeLinesProcces());
    }
    public void Stop()
    {
        if(_isChangeLanes || _CLProcces != null)
        {
            StopCoroutine(_CLProcces);
        }
    }

    public void ToLeft()
    {
        if (_isChangeLanes) return;
        if (_tempLine == 0) return;

        _tempLine--;

        ChangeLines(_tempLine);
    }
    public void ToRight() 
    {
        if (_isChangeLanes) return;
        if (_tempLine == _lines.Length - 1) return;

        _tempLine++;

        ChangeLines(_tempLine);
    }

    private void ChangeLines(int newLine)
    {
        _isChangeLanes = true;
        _TCLtime = 0;
        _oldPosition = _carTransform.transform.position;
        _newPosition = _oldPosition;
        _newPosition.x = _lines[newLine];

        _CLProcces = StartCoroutine(ChangeLinesProcces());
    }

    float _TCLtime;
    Vector3 _newPosition;
    Vector3 _oldPosition;

    private IEnumerator ChangeLinesProcces()
    {
        while(_TCLtime < _changeLineTime)
        {
            _carTransform.transform.position = Vector3.Lerp(_oldPosition, _newPosition, _TCLtime / _changeLineTime);
            _TCLtime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _isChangeLanes = false;
    }
}
