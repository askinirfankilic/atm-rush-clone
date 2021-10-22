using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoSingleton<PlayerController>
{
    #region Public Fields

    public List<GameObject> collectibles;

    #endregion
    #region Serialized Fields

    [SerializeField] private GameObject _stackInserter;
    
    #endregion

    #region private Fields

    private Rigidbody _playerRb;
    private Vector3 rbVelocity;

    #endregion

    #region Properties

    public Vector3 RbVelocity
    {
        get => rbVelocity;
        set => rbVelocity = value;
    }

    #endregion

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody>();
        collectibles = new List<GameObject>();
    }
}