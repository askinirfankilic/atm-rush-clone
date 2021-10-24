using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandObstacle : MonoBehaviour
{
    private void Awake()
    {
        DOTween.Init();
    }

    private void Start()
    {
        transform.DOMoveX(transform.position.x - 6f, 2f).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter(Collider other)
    {
        Collectible collectible = other.GetComponent<Collectible>();
        if (other.CompareTag(Tags.Collectible) && collectible.isInPlayer && collectible.isLastCollectible)
        {
            collectible._lastCollectible = null;
            collectible.isInPlayer = false;
            collectible.isLastCollectible = false;
            int index = PlayerController.Instance.collectibles.IndexOf(collectible.gameObject);
            
            if (index == 0)
            {
                PlayerController.Instance.collectibles.RemoveAt(index);
                Destroy(collectible.gameObject);
            }
            else
            {
                PlayerController.Instance.collectibles[index - 1].GetComponent<Collectible>().isLastCollectible = true;
            }
            
            
        }
    }
}