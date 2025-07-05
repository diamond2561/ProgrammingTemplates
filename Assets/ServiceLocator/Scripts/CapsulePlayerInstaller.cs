using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс для регистрации зависимостей (сервисов) в ServiceLocator.
/// Выполняется при старте игры.
/// </summary>
public class CapsulePlayerInstaller : MonoBehaviour
{
    // Ссылки на компоненты, которые будут зарегистрированы в ServiceLocator
    public CapsuleMoveInput moveInput;
    public CapsuleCharacter capsuleCharacter;

    private void Awake()
    {
        // Регистрируем сервисы в ServiceLocator
        ServiceLocator.Register(moveInput);
        ServiceLocator.Register(capsuleCharacter);
    }
}