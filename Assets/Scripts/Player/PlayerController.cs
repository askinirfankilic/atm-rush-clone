using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private GameObject _stackInserter;

    #endregion
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Collectible))
        {
            Debug.Log("ASDADASDDSADSD");
            EventManager.Invoke_OnCollectiblePlayerCollision(other);
        }
    }
}
