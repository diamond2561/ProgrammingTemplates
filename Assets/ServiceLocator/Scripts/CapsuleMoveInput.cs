using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMoveInput : MonoBehaviour
{
    public Vector3 GetDirection()
    {
        Vector3 direction = Vector3.zero;

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (vertical > 0) {direction.z = 1;}
        else if (vertical < 0) { direction.z = -1; }

        if (horizontal > 0) { direction.x = 1; }
        else if (horizontal < 0) { direction.x = -1; }

        return direction;
    }
}
