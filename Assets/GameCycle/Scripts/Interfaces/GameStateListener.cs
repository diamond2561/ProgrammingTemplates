//Разделение ответственности : один класс управляет состоянием игры (GameCycle), другой — обновлением объектов (GameUpdater), третий — регистрацией (GameInstaller).
//Гибкость : легко добавлять новые слушатели без изменения существующего кода.
//Централизация логики : нет множества Update() в каждом скрипте — всё контролируется из одного места.
//Поддержка паузы и других состояний : можно гибко управлять, какие объекты обновляются, а какие — нет.


// Базовый маркерный интерфейс для всех игровых событий.
// Используется как общий тип для всех слушателей событий.
public interface IGameEventListener { }

// Слушатель события "Игра началась".
// Любой объект, реализующий этот интерфейс, может отреагировать на начало игры.
public interface IStartGameListener : IGameEventListener
{
    void StartGame();
}

// Слушатель события "Игра приостановлена".
// Реакция на паузу в игре.
public interface IPauseGameListener : IGameEventListener
{
    void PauseGame();
}

// Слушатель события "Игра возобновлена".
// Реакция на продолжение игры после паузы.
public interface IResumeGameListener : IGameEventListener
{
    void ResumeGame();
}

// Слушатель события "Игра окончена".
// Объекты могут выполнить действия при завершении игры.
public interface IFinishGameListener : IGameEventListener
{
    void FinishGame();
}

// Интерфейс для объектов, которые хотят получать вызов Update,
// но не через MonoBehaviour.Update(), а через централизованную систему GameUpdater.
public interface ICustomUpdateble
{
    void CustomUpdate();
}

// Интерфейс для объектов, которые должны обновляться только когда игра активна (не на паузе).
// Нужно для контроля поведения во время паузы.
public interface IPausableUpdatable
{
    void PausableUpdate();
}
