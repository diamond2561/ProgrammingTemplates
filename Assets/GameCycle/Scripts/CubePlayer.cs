using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayer : MonoBehaviour
{
    [SerializeField] private float _speed = 2.5f;

    public void Move(Vector3 offset)
    {
        this.transform.position += offset * this._speed;
    }

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }
}
