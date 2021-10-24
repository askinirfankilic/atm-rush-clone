using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : Movement
{
    public float forwardMovementSpeed = 1f;
    private void FixedUpdate()
    {
        Move(Vector3.forward * forwardMovementSpeed);
    }
}
