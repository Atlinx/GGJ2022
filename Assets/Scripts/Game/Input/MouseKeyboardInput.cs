using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Input
{
    public class MouseKeyboardInput : InputBase
    {
        protected InputAction mouseAimAction;

        protected override void Awake()
        {
            base.Awake();
            mouseAimAction = playerInput.currentActionMap.FindAction("Mouse Aim");
        }

        protected override void Update()
        {
            shipCore.InputValues.AimDir = (mouseAimAction.ReadValue<Vector2>() - (Vector2)shipCore.transform.position).normalized;
        }
    }
}