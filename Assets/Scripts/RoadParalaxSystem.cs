using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadParalaxSystem : SpeedTaker
{
    [SerializeField] private Transform[] _roads;
    [SerializeField] private float _Yoffset;

    private Coroutine _procces;

    public override void Launch()
    {
        Vector3 pos = Vector3.zero;

        for (int i = 0; i < _roads.Length; i++)
        {
            _roads[i].position = pos;
            pos.y += _Yoffset;
        }
        Play();
    }
    public override void Play()
    {
        _procces = StartCoroutine(Procces());
    }

    public override void Stop()
    {
        if (_procces != null)
            StopCoroutine(_procces);
    }

    private IEnumerator Procces()
    {
        Vector3 pos;

        while (true)
        {
            for (int i = 0; i < _roads.Length; i++)
            {
                pos = _roads[i].position;

                pos.y -= _speed * Time.fixedDeltaTime;

                if (pos.y < -_Yoffset) 
                {
                    pos.y += (_roads.Length) * _Yoffset;
                }

                _roads[i].position = pos;

            }

            yield return new WaitForFixedUpdate();
        }
    }
}
