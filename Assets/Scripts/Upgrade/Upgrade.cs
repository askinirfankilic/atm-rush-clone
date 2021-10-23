using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private int _doorUsageCount;

    #region Unity Methods

    private void Awake()
    {
        _doorUsageCount = 0;
    }

    [SerializeField]private int a = 0;
    [SerializeField]private int b = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Collectible))
        {
            _doorUsageCount++;
            Collectible collectible = other.GetComponent<Collectible>();
            Collectible.CollectibleType type = collectible._type;

            if (type == Collectible.CollectibleType.Dollar)
            {
                EventManager.Invoke_OnCollectibleUpgrade(collectible, Collectible.CollectibleType.Gold);
                a++;
            }
            else if(type == Collectible.CollectibleType.Gold)
            {
                EventManager.Invoke_OnCollectibleUpgrade(collectible, Collectible.CollectibleType.Diamond);
                b++;
            }
            else
            {
                Debug.Log("DIAMOND CANT UPGRADE");
            }
            
        }
    }

    #endregion
}