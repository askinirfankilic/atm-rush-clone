using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : Movement
{
    [SerializeField] private float _minLimitAmount;
    [SerializeField] private float _maxLimitAmount;

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minLimitAmount, _maxLimitAmount),
            transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        Move(new Vector3(MouseInput.Instance.MoveFactorX, 0f, 0f));
    }
}
