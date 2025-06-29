using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour, IStartGameListener, IFinishGameListener
{
    [SerializeField] private GameCycle _gameCycle;

    [SerializeField] private Button _playButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private GameObject _background;

    private void Awake()
    {
        if (_playButton != null)
            _playButton.onClick.AddListener(ProcessPlayButtonClick);

        if (_pauseButton != null)
            _pauseButton.onClick.AddListener(ProcessPauseButtonClick);

        if (_resumeButton != null)
            _resumeButton.onClick.AddListener(ProcessResumeButtonClick);
    }

    private void EnablePlayButton()
    {
        _background.SetActive(false);
        _playButton.gameObject.SetActive(true);
        _pauseButton.gameObject.SetActive(true);
        _resumeButton.gameObject.SetActive(false);
    }

    private void EnablePauseButton()
    {
        _background.SetActive(false);
        _playButton.gameObject.SetActive(false);
        _pauseButton.gameObject.SetActive(true);
        _resumeButton.gameObject.SetActive(true);
    }

    private void EnableResumeButton()
    {
        _background.SetActive(false);
        _playButton.gameObject.SetActive(false);
        _pauseButton.gameObject.SetActive(true);
        _resumeButton.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveAllListeners();
        _pauseButton.onClick.RemoveAllListeners();
        _resumeButton.onClick.RemoveAllListeners();
    }

    private void ProcessPlayButtonClick()
    {
        EnablePlayButton();
        _gameCycle.StartGame();
    }

    private void ProcessPauseButtonClick()
    {
        EnablePauseButton();
        _gameCycle.PauseGame();
    }
    private void ProcessResumeButtonClick()
    {
        EnableResumeButton();
        _gameCycle.ResumeGame();
    }

    void IStartGameListener.StartGame()
    {
        gameObject.SetActive(true);
        
    }

    void IFinishGameListener.FinishGame()
    {
        gameObject.SetActive(false);
    }
}
