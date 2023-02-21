using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    private static event Action<bool> OnMove;
    private static event Action<bool> OnStop;

    protected void MovePressed(bool isPressed)
    {
        OnMove?.Invoke(isPressed);
    }

    protected void StopPressed(bool isPressed)
    {
        OnStop?.Invoke(isPressed);
    }
}
