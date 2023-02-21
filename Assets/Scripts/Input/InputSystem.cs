using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static event Action<bool> OnMove;
    public static event Action<bool> OnStop;

    public static event Action OnRestartGame;
    public static event Action OnExitGame;

    protected void MovePressed(bool isPressed)
    {
        OnMove?.Invoke(isPressed);
    }

    protected void StopPressed(bool isPressed)
    {
        OnStop?.Invoke(isPressed);
    }

    protected void RestartPressed()
    {
        OnRestartGame?.Invoke();
    }

    protected void ExitGame()
    {
        OnExitGame?.Invoke();
    }
}
