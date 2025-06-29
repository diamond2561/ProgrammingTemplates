using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Основная система жизненного цикла игры.
// Может запускать, останавливать, ставить на паузу и завершать игру.
public enum GameState
{
    None,
    Playing,
    Paused,
    Finished
}

public class GameCycle : MonoBehaviour
{
    // Списки слушателей разных событий
    private List<IStartGameListener> _startGameListeners = new();
    private List<IPauseGameListener> _pauseGameListeners = new();
    private List<IResumeGameListener> _resumeGameListeners = new();
    private List<IFinishGameListener> _finishGameListeners = new();

    private GameState _gameState;

    // Регистрация слушателя в нужных списках
    public void AddListeners(IGameEventListener listener)
    {
        if (listener is IStartGameListener start) _startGameListeners.Add(start);
        if (listener is IPauseGameListener pause) _pauseGameListeners.Add(pause);
        if (listener is IResumeGameListener resume) _resumeGameListeners.Add(resume);
        if (listener is IFinishGameListener finish) _finishGameListeners.Add(finish);
    }

    // Запуск игры — вызывается из инспектора через контекстное меню
    [ContextMenu("Start Game")]
    public void StartGame()
    {
        if (_gameState == GameState.Playing) return;
        _gameState = GameState.Playing;

        foreach (IStartGameListener listener in _startGameListeners)
        {
            listener.StartGame();
        }
    }

    // Постановка на паузу
    [ContextMenu("Pause Game")]
    public void PauseGame()
    {
        if (_gameState != GameState.Playing) return;
        _gameState = GameState.Paused;

        foreach (IPauseGameListener listener in _pauseGameListeners)
        {
            listener.PauseGame();
        }
    }

    // Возобновление после паузы
    [ContextMenu("Resume Game")]
    public void ResumeGame()
    {
        if (_gameState != GameState.Paused) return;
        _gameState = GameState.Playing;

        foreach (IResumeGameListener listener in _resumeGameListeners)
        {
            listener.ResumeGame();
        }
    }

    // Завершение игры
    [ContextMenu("Finish Game")]
    public void FinishGame()
    {
        if (_gameState == GameState.Finished) return;
        _gameState = GameState.Finished;

        foreach (IFinishGameListener listener in _finishGameListeners)
        {
            listener.FinishGame();
        }
    }
}
