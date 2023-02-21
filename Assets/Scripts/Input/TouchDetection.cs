using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetection : InputSystem
{
    public void OnMoveButtonPressed(bool isPressed)
    {
        MovePressed(isPressed);
    }

    public void OnStopButtonPressed(bool isPressed)
    {
        StopPressed(isPressed);
    }

    public void OnRestartButtonPressed()
    {
        RestartPressed();
    }

    public void OnExitButtonPressed()
    {
        ExitGame();
    }

    public void OnPauseButtonPressed(bool isPressed)
    {
        SetPause(isPressed);
    }
}
