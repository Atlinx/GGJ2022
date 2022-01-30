using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Input
{
    public class ControllerInput : InputBase
    {
        protected InputAction joyAimAction;

        protected override void Awake()
        {
            base.Awake();
            joyAimAction = playerInput.currentActionMap.FindAction("Joy Aim");
        }

        protected override void Update()
        {
            base.Update();
            shipCore.InputValues.AimDir = joyAimAction.ReadValue<Vector2>();
        }
    }
}