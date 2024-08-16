using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateBase : MonoBehaviour
{
    protected GameStateController _controller;

    public virtual void Init(GameStateController controller) => _controller = controller;

    public virtual GameState StateType { get; }
    public virtual void StartState() { }
    public virtual void ContinState() { }
    public virtual void StopState() { }

}

public enum GameState
{
    MainMenu,
    Lose,
    Pause,
    Game
}
