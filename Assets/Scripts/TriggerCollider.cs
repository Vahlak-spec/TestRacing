using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollider : MonoBehaviour
{

    private Collider2D _collider;
    private Action _action;
    private Action<Collider2D> _checkCollision;

    private void Start()
    {
        _collider = gameObject.GetComponent<Collider2D>();
    }

    public void SetActiveCollider(bool value)
    {
        _collider.enabled = value;
    } 

    public void SetAction<T>(Action action)
    {
        _checkCollision = CheckCollision<T>;
        _action = action;
    }

    private void CheckCollision<T>(Collider2D collision)
    {
        if (collision.GetComponent<T>() != null)
        {
            _action.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _checkCollision?.Invoke(collision);
    }
}
