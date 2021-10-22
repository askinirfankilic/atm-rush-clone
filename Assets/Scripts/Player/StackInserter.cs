using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackInserter : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private float _nextStackOffset = 1f;
    
    #endregion

    
    private void MoveStack(Collider collectible)
    {
        transform.position += new Vector3(0, 0, _nextStackOffset);
    }

    private void OnEnable()
    {
        EventManager.OnCollectiblePlayerCollision += MoveStack;
    }

    private void OnDisable()
    {
        EventManager.OnCollectiblePlayerCollision -= MoveStack;
    }
}