using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetection : InputSystem
{
    public void OnMovePressed(bool isPressed)
    {
        MovePressed(isPressed);
    }

    public void OnStopButtonPressed(bool isPressed)
    {
        StopPressed(isPressed);
    }
}
