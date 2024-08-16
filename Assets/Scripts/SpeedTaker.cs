using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTaker : MonoBehaviour
{
    protected float _speed;

    public virtual void SetSpeed(float speed)
    {
        _speed = speed;
    }
    public virtual void Launch() { }
    public virtual void Play() { }
    public virtual void Stop() { }
}   
