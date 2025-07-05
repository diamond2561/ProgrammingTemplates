using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер движения персонажа.
/// Запрашивает зависимости через ServiceLocator и управляет движением.
/// </summary>
public class CapsuleMoveController : MonoBehaviour
{
    // Ссылки на зависимости, которые будут получены через ServiceLocator
    public CapsuleMoveInput moveInput;
    public CapsuleCharacter capsuleCharacter;

    private void Awake()
    {
        // Получаем зависимости из ServiceLocator
        this.moveInput = ServiceLocator.Resolve<CapsuleMoveInput>();
        this.capsuleCharacter = ServiceLocator.Resolve<CapsuleCharacter>();
    }

    private void Update()
    {
        // Получаем направление от ввода и передаём его персонажу
        Vector3 direction = moveInput.GetDirection();
        capsuleCharacter.Move(direction, Time.deltaTime);
    }
}