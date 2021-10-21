using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
     #region Mouse Inputs

     public static event Action<Vector3> OnMouseInputDown;
     public static void Invoke_OnMouseInputDown(Vector3 mousePos){OnMouseInputDown?.Invoke(mousePos);}
     
     public static event Action<Vector3> OnMouseInputStay;
     public static void Invoke_OnMouseInputStay(Vector3 mousePos){OnMouseInputStay?.Invoke(mousePos);}
     
     public static event Action<Vector3> OnMouseInputUp;
     public static void Invoke_OnMouseInputUp(Vector3 mousePos){OnMouseInputUp?.Invoke(mousePos);}

     #endregion
     
}
