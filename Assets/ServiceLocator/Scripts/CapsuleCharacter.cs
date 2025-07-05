using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCharacter : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;

    public void Move(Vector3 direction, float deltaTime)
    {
        transform.position += direction * (deltaTime * speed);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
