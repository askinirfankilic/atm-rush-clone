using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    #region Mouse Inputs

    public static event Action<Vector3> OnMouseInputDown;

    public static void Invoke_OnMouseInputDown(Vector3 mousePos)
    {
        OnMouseInputDown?.Invoke(mousePos);
    }

    public static event Action<Vector3> OnMouseInputStay;

    public static void Invoke_OnMouseInputStay(Vector3 mousePos)
    {
        OnMouseInputStay?.Invoke(mousePos);
    }

    public static event Action<Vector3> OnMouseInputUp;

    public static void Invoke_OnMouseInputUp(Vector3 mousePos)
    {
        OnMouseInputUp?.Invoke(mousePos);
    }

    #endregion
    
    #region Gameplay

    public static event Action<Collider> OnCollectiblePlayerCollision;

    public static void Invoke_OnCollectiblePlayerCollision(Collider collectible)
    {
        OnCollectiblePlayerCollision?.Invoke(collectible);
    }

    public static event Action<int> OnScoreIncrement;

    public static void Invoke_OnScoreIncrement(int score)
    {
        OnScoreIncrement.Invoke(score);
    }

    public static event Action<int> OnScoreDecrement;

    public static void Invoke_OnScoreDecrement(int score)
    {
        OnScoreDecrement.Invoke(score);
    }

    public static event Action OnScoreChange;

    public static void Invoke_OnScoreChange()
    {
        OnScoreChange.Invoke();
    }

    public static event Action<Collectible, Collectible.CollectibleType> OnCollectibleUpgrade;

    public static void Invoke_OnCollectibleUpgrade(Collectible collectible, Collectible.CollectibleType type)
    {
        OnCollectibleUpgrade.Invoke(collectible, type);
    }

    public static event Action<int> OnATMTrigger;

    public static void Invoke_OnATMTrigger(int scoreFactor)
    {
        OnATMTrigger.Invoke(scoreFactor);
    }

    public static event Action<int> OnCollectionSpread;

    public static void Invoke_OnCollectionSpread(int index)
    {
        OnCollectionSpread.Invoke(index);
    }

    #endregion

    #region Finish

    public static event Action OnLevelFinish;

    public static void Invoke_OnLevelFinish()
    {
        OnLevelFinish.Invoke();
    }

    #endregion
}