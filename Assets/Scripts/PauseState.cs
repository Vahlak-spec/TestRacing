using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseState : GameStateBase
{
    public override GameState StateType => GameState.Pause;

    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _toMainMenuButton;

    [SerializeField] private GameObject _uiGO;

    public override void Init(GameStateController controller)
    {
        base.Init(controller);

        _continueButton.onClick.AddListener(() =>
        {
            _controller.ContinueState(GameState.Game);
        });
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
