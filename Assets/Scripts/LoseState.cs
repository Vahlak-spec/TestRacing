using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseState : GameStateBase
{
    public override GameState StateType => GameState.Lose;

    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _toMainMenuButton;

    [SerializeField] private GameObject _uiGO;

    public override void Init(GameStateController controller)
    {
        base.Init(controller);

        _restartButton.onClick.AddListener(() =>
        {
            _controller.LaunchState(GameState.Game);
        });
        _toMainMenuButton.onClick.AddListener(() =>
        {
            _controller.LaunchState(GameState.MainMenu);
        });
    }

    public override void StartState()
    {
        _uiGO.SetActive(true);
    }
    public override void StopState()
    {
        _uiGO.SetActive(false);
    }
}
