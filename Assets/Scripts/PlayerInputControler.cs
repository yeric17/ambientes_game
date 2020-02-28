using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  System;

public class PlayerInputControler : MonoBehaviour
{
    public bool Sprint = false;
    public bool AxisPressed = false;

    private void Update()
    {
        AxisPressed = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||
                    Input.GetKey(KeyCode.W);
        Sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.LeftShift);
    }
}
