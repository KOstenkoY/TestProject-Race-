using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetection : InputSystem
{
    public void OnMovePressed()
    {
        MovePressed();
    }

    public void OnStopButtonPressed()
    {
        StopPressed();
    }
}
