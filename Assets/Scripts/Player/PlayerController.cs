using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoSingleton<PlayerController>
{
    #region Public Fields

    public List<GameObject> collectibles;
    public bool isInATM = false;

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

        DOTween.Init();
    }

    private void SpreadCollection(int startingIndex)
    {
        int totalCount = collectibles.Count;

        for (int i = startingIndex; i < totalCount; i++)
        {
            Debug.Log("starting index : " + startingIndex + "  i:   " + i + "totalCount:  " + totalCount);
            Collectible collectible = collectibles[startingIndex].GetComponent<Collectible>();
            
            
            collectible.isInPlayer = false;
            collectible.GetComponent<BoxCollider>().isTrigger = true;
            Rigidbody newRigidbody = collectible.gameObject.AddComponent<Rigidbody>();
            newRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                                       RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
            newRigidbody.useGravity = false;
            collectibles.RemoveAt(startingIndex);
            collectible._lastCollectible = null;
            collectible.isLastCollectible = false;

            collectible.transform.DOJump(new Vector3(-4f + UnityEngine.Random.Range(0f, 8f), collectible.transform.position.y,
                    collectible.transform.position.z + 13f + UnityEngine.Random.Range(0f, 3f)),
                4f, 1, 0.5f);
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