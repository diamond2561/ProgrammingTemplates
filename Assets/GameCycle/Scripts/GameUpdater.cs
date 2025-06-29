// Управляет обновлением объектов, реализующих:
// - ICustomUpdateble — обновление всегда
// - IPausableUpdatable — обновление только если игра активна
using System.Collections.Generic;
using UnityEngine;

public class GameUpdater : MonoBehaviour,
    IStartGameListener, IPauseGameListener, IResumeGameListener, IFinishGameListener
{
    private List<ICustomUpdateble> _updatables = new();      // Всегда обновляемые
    private List<IPausableUpdatable> _pausableUpdatables = new(); // Обновляемые при активной игре

    public void AddUpdatable(ICustomUpdateble updatable)
    {
        _updatables.Add(updatable);
    }

    public void AddPausableUpdatable(IPausableUpdatable pauseUpdatable)
    {
        _pausableUpdatables.Add(pauseUpdatable);
    }

    private bool _isActive; // Игровой процесс активен (не на паузе)

    void IStartGameListener.StartGame() => _isActive = true;
    void IPauseGameListener.PauseGame() => _isActive = false;
    void IResumeGameListener.ResumeGame() => _isActive = true;
    void IFinishGameListener.FinishGame() => _isActive = false;

    private void Update()
    {
        // Вызываем Update у всех обычных обновляемых объектов
        foreach (var updatable in _updatables)
        {
            updatable.CustomUpdate();
        }

        // Если игра активна — обновляем и паузабельные объекты
        if (_isActive)
        {
            foreach (var updatable in _pausableUpdatables)
            {
                updatable.PausableUpdate();
            }
        }
    }
}