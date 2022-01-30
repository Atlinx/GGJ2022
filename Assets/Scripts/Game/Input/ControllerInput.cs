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
            if (joyAimAction.triggered)
            {
                var aim = joyAimAction.ReadValue<Vector2>();
                if(aim.magnitude > 0.6) shipCore.InputValues.AimDir = aim;
            }
            
            base.Update();
        }
    }
}