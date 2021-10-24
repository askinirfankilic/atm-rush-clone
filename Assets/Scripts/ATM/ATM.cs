using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.PackageManager;
using UnityEngine;

public class ATM : MonoBehaviour
{
    private bool isAlready = false;

    private void Update()
    {
        if (transform.position.z < PlayerController.Instance.transform.position.z && !isAlready)
        {
            // Debug.LogError("IT ISNT IN ATM");
            if (PlayerController.Instance.isInATM)
            {
                PlayerController.Instance.isInATM = false;
            }
            isAlready = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Collectible) && other.GetComponent<Collectible>().isInPlayer)
        {
            PlayerController.Instance.isInATM = true;
            Collectible collectible = other.GetComponent<Collectible>();

            int totalCount = PlayerController.Instance.collectibles.Count;

            EventManager.Invoke_OnATMTrigger(collectible._scoreFactor);

            if (collectible.isLastCollectible)
            {
                if (totalCount == 1)
                {
                    PlayerController.Instance.collectibles.RemoveAt(totalCount - 1);
                    Destroy(collectible.gameObject);
                }
                else
                {
                    PlayerController.Instance.collectibles.RemoveAt(totalCount - 1);
                    Destroy(collectible.gameObject);

                    PlayerController.Instance.collectibles[totalCount - 2]
                        .GetComponent<Collectible>().isLastCollectible = true;
                }
            }
            else
            {
                int index = PlayerController.Instance.collectibles.IndexOf(collectible.gameObject);

                if (index == 0)
                {
                    PlayerController.Instance.collectibles.RemoveAt(index);
                    Destroy(collectible.gameObject);
                }
                else
                {
                    
                    Debug.Log("INDEX:    " + index);
                    PlayerController.Instance.collectibles.RemoveAt(index);
                    Destroy(collectible.gameObject);

                    PlayerController.Instance.collectibles[index - 1]
                        .GetComponent<Collectible>().isLastCollectible = true;
                }


                EventManager.Invoke_OnCollectionSpread(index);
            }
        }

        if (other.CompareTag(Tags.Player))
        {
            EventManager.Invoke_OnScoreIncrement(ScoreManager.Instance.StoredScore);
        }
    }
}