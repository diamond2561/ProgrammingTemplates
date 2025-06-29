using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeMoveController : MonoBehaviour
{
    [SerializeField] private CubePlayer _cubePlayer;
    [SerializeField] private CubeKeyboardInput _keyboardInput;

    public CubeMoveController (CubePlayer cubePlayer, CubeKeyboardInput keyboardInput)
    {
        this._cubePlayer = cubePlayer;
        this._keyboardInput = keyboardInput;
    }

    private void Awake()
    {
        _keyboardInput.OnMove += OnMove;
    }

    private void OnDestroy()
    {
        _keyboardInput.OnMove -= OnMove;
    }
    
    private void OnMove(Vector2 direction)
    {
        var offset = new Vector3(direction.x, 0, direction.y) * Time.deltaTime;
        this._cubePlayer.Move(offset);
    }
}
