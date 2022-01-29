using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Input
{
    public class ControllerInput : InputBase
    {
        protected override void Update()
        {
            shipCore.InputValues.AimDir = playerControls.Player.JoyAim.ReadValue<Vector2>();
        }
    }
}