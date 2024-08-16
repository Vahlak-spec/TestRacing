using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : GameStateBase
{
    public override GameState StateType => GameState.MainMenu;

    [SerializeField] private GameObject _uiGO;
    [SerializeField] private Button _playButton;

    public override void Init(GameStateController controller)
    {
        base.Init(controller);
        _uiGO.SetActive(false);
        _playButton.onClick.AddListener(PlayButtonClick);
    }

    public override void StartState()
    {
        _uiGO.SetActive(true);
    }
    public override void StopState()
    {
        _uiGO.SetActive(false);
    }

    private void PlayButtonClick()
    {
        _controller.LaunchState(GameState.Game);
    }
}
