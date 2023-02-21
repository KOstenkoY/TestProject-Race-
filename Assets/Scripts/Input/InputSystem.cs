using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static event Action OnMove;
    public static event Action OnStop;

    protected void MovePressed()
    {
        OnMove?.Invoke();
    }

    protected void StopPressed()
    {
        OnStop?.Invoke();
    }
}
