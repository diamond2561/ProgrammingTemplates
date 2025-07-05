using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Атрибут [RequireComponent] гарантирует, что объект будет иметь компонент Renderer.
[RequireComponent(typeof(Renderer))]

public class View : MonoBehaviour
{
    // Метод Awake вызывается при инициализации объекта.
    private void Awake()
    {
        // Получаем компонент Renderer (т.е. то, что отвечает за отображение объекта).
        Renderer renderer = GetComponent<Renderer>();

        // Устанавливаем случайный цвет материала при запуске игры.
        renderer.material.color = Random.ColorHSV();
    }
}