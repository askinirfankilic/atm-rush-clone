using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATM : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Collectible))
        {
            Collectible collectible = other.GetComponent<Collectible>();
            
            EventManager.Invoke_OnATMTrigger(collectible._scoreFactor);

            int objIndex = PlayerController.Instance.collectibles.IndexOf(other.gameObject);
            
            if (objIndex == PlayerController.Instance.collectibles.Count - 1)
            {
                //burada destroy et
                Destroy(PlayerController.Instance.collectibles[objIndex]);
                PlayerController.Instance.collectibles.RemoveAt(objIndex);
                return;
            }
            
            EventManager.Invoke_OnCollectionSpread(objIndex);
            
            
            
            
        }

        if (other.CompareTag(Tags.Player))
        {
            EventManager.Invoke_OnScoreIncrement(ScoreManager.Instance.StoredScore);
        }
    }
}
