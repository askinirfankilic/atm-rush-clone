using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType
    {
        Dollar,
        Gold,
        Diamond
    }

    [SerializeField] private CollectibleType _type;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Player))
        {
            Debug.Log(other.name);
        }
    }

    
}