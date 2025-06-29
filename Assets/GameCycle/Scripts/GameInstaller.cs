// Устанавливает связи между GameCycle, GameUpdater и всеми слушателями.
// Находит все компоненты в дочерних объектах и подписывает их на события.
using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    void Start()
    {
        // Собираем всех, кто хочет реагировать на игровые события
        var listeners = GetComponentsInChildren<IGameEventListener>();
        var gameCycle = GetComponent<GameCycle>();

        // Регистрируем их в GameCycle
        foreach (var listener in listeners)
        {
            gameCycle.AddListeners(listener);
        }

        // Регистрируем все обновляемые объекты в GameUpdater
        var updatables = GetComponentsInChildren<ICustomUpdateble>();
        var gameUpdater = GetComponent<GameUpdater>();

        foreach (var updatable in updatables)
        {
            gameUpdater.AddUpdatable(updatable);
        }

        // Регистрируем все паузабельные обновляемые
        var pausableUpdatables = GetComponentsInChildren<IPausableUpdatable>();
        foreach (var pauseUpdatable in pausableUpdatables)
        {
            gameUpdater.AddPausableUpdatable(pauseUpdatable);
        }
    }
}