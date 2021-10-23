using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Collectible))
        {
            Collectible collectible = other.GetComponent<Collectible>();
            Collectible.CollectibleType type = collectible._type;

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

        if (other.CompareTag(Tags.Player))
        {
            EventManager.Invoke_OnScoreChange();
        }
    }
}
