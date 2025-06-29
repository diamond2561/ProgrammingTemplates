using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, IPausableUpdatable
{
    [SerializeField] private CubePlayer _player;


    void IPausableUpdatable.PausableUpdate()
    {
        transform.LookAt(_player.GetPosition());
    }
}
