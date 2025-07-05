using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    // Ссылка на объект "View", который отвечает за визуальное отображение.
    private readonly View _view;

    // Хранилище уже использованных позиций, чтобы не создавать дубликаты в одном месте.
    private readonly HashSet<Vector3> _positions = new();

    // Текущая позиция объекта.
    private Vector3 _position;

    // Конструктор принимает шаблон View для создания новых объектов.
    public Controller(View view)
    {
        _view = view;
        _position = view.transform.position; // Запоминаем начальную позицию.
    }

    // Метод, вызываемый каждый кадр через Main (обновления контроллера).
    public void OnUpdate()
    {
        // Проверяем нажатия клавиш W, S, A, D и изменяем текущую позицию.
        if (Input.GetKeyDown(KeyCode.W))
        {
            _position += Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _position += Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _position += Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _position += Vector3.right;
        }

        // Если такая позиция ещё не использовалась...
        if (_positions.Contains(_position) == false)
        {
            // ...сохраняем её в список,
            _positions.Add(_position);

            // ...и создаём новый объект на этой позиции.
            Object.Instantiate(_view, _position, Quaternion.identity);
        }
    }
}