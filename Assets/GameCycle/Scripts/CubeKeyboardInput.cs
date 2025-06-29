using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeKeyboardInput : MonoBehaviour, IPausableUpdatable
{
    public Action<Vector2> OnMove;

    void IPausableUpdatable.PausableUpdate()
    {
        this.HandleKeyboard();
    }

    private void HandleKeyboard()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.OnMove(Vector2.up);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.OnMove(Vector2.down);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.OnMove(Vector2.left);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.OnMove(Vector2.right);
        }
    }

    private void Move(Vector2 direction)
    {
        this.OnMove?.Invoke(direction);
    }

    
}
