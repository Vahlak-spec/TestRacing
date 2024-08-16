using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    [SerializeField] private GameStateBase[] _states;
    [SerializeField] private GameState _startstate;

    public void Start()
    {
        foreach(var item in _states) 
        {
            item.Init(this);
            item.StopState();
        }

        Array.Find<GameStateBase>( _states, s => s.StateType == _startstate).StartState();
    }

    public void LaunchState(GameState state)
    {
        foreach (var item in _states)
        {
            item.StopState();
        }

        Array.Find<GameStateBase>(_states, s => s.StateType == state).StartState();
    }
    public void ContinueState(GameState state)
    {
        foreach (var item in _states)
        {
            item.StopState();
        }

        Array.Find<GameStateBase>(_states, s => s.StateType == state).ContinState();
    }
}
