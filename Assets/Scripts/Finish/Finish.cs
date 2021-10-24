using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Finish : MonoBehaviour
{
    private void Awake()
    {
        DOTween.Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Player))
        {
            
            EventManager.Invoke_OnScoreChange();
            EventManager.Invoke_OnLevelFinish();
        }
        
        if (other.CompareTag(Tags.Collectible))
        {
            Collectible collectible = other.GetComponent<Collectible>();
            Collectible.CollectibleType type = collectible._type;
            Transform collectibleObj = other.transform;

            collectible.isInPlayer = false;
            collectible.isLastCollectible = false;
            int index = PlayerController.Instance.collectibles.IndexOf(other.gameObject);
            if (index == 0)
            {
                PlayerController.Instance.collectibles.RemoveAt(index);
            }
            else
            {
                PlayerController.Instance.collectibles[index - 1].GetComponent<Collectible>().isLastCollectible = true;
                PlayerController.Instance.collectibles.RemoveAt(index);
            }
            
            collectibleObj.DOMoveX(-40f, 4f).OnComplete(()=>
            {
                Destroy(other.gameObject);
            });

            if (type == Collectible.CollectibleType.Dollar)
            {
                EventManager.Invoke_OnScoreIncrement(1);
                EventManager.Invoke_OnScoreChange();
            }
            else if(type == Collectible.CollectibleType.Gold)
            {
                EventManager.Invoke_OnScoreIncrement(2);
                EventManager.Invoke_OnScoreChange();
            }
            else if(type == Collectible.CollectibleType.Diamond)
            {
                EventManager.Invoke_OnScoreIncrement(3);
                EventManager.Invoke_OnScoreChange();
            }
            
        }

        
    }
}
