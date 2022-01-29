using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Input
{
    public class MouseKeyboardInput : InputBase
    {
        protected override void Update()
        {
            shipCore.InputValues.AimDir = (playerControls.Player.MouseAim.ReadValue<Vector2>() - (Vector2)shipCore.transform.position).normalized;
        }
    }
}