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

    private void SpreadCollection(int startingIndex)
    {
        for (int i = collectibles.Count - 1; i >= startingIndex; i--)
        {
            //burada dagit
                
            Destroy(collectibles[i]);
            collectibles.RemoveAt(i);
        }
    }

    private void OnEnable()
    {
        EventManager.OnCollectionSpread += SpreadCollection;
    }

    private void OnDisable()
    {
        EventManager.OnCollectionSpread -= SpreadCollection;
    }
}